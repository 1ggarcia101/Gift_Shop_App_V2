using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.Template.Application.Commands;
using SS.Template.Application.Features.Interviews;
using SS.Template.Application.Features.Interviews.Commands;
using SS.Template.Application.Features.Interviews.Commands.Add;
using SS.Template.Application.Features.Interviews.Commands.Remove;
using SS.Template.Application.Features.Interviews.Queries.Get;
using SS.Template.Application.Features.Interviews.Queries.GetCardList;
using SS.Template.Application.Features.Interviews.Queries.GetCVPDF;
using SS.Template.Application.Features.Interviews.Queries.GetPage;
using SS.Template.Application.Queries;

namespace SS.Template.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InterviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<InterviewsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPage([FromQuery] GetInterviewsPageQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(InterviewsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetInterviewQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(AddInterviewsModel command)
        {
            await _mediator.Send(new AddInterviewsCommand(command));
            return Ok();
        }
        [HttpPost("uploadCV")]
        [DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "CV");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length> 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { dbPath });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("cv/{id:guid}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> GetCV(Guid id)
        {
            var result = await _mediator.Send(new GetInterviewQuery(id));
            var stream = new FileStream(@result.CV, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");

        }


        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, AddInterviewsModel command)
        {
            await _mediator.Send(Edit.For(id, command));
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new RemoveInterviewsCommand(id));
            return Ok();
        }
        [HttpGet("cardlist")]
        [ProducesResponseType(typeof(PaginatedResult<InterviewsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCardListPage([FromQuery] GetCardListPageQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("getCVPdf/{id:guid}")]
        [ProducesResponseType(typeof(PaginatedResult<InterviewsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCvPdf(Guid id)
        {
            var result = await _mediator.Send(new GetInterviewCVPDFQuery(id));

            return File(result, "application/octet-stream");
        }
    }
}
