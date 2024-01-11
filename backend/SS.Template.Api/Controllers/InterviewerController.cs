using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.Template.Application.Features.Examples.Queries.GetPage;
using SS.Template.Application.Features.Examples;
using SS.Template.Application.Features.Interviewers.Commands.Add;
using SS.Template.Application.Features.Interviewers.Commands.Remove;
using SS.Template.Application.Features.Interviewers.Commands.Update;
using SS.Template.Application.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using SS.Template.Application.Features.Interviewers.Queries.GetPage;
using SS.Template.Application.Features.Interviewers;
using System;
using SS.Template.Application.Features.Interviewers.Queries.Get;
using SS.Template.Application.Features.Interviewers.Commands.Activate;

namespace SS.Template.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InterviewerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<InterviewerModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPage([FromQuery] GetInterviewersPageQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(InterviewerModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var result = await _mediator.Send(new GetInterviewerDetailQuery(id));
            return Ok(result);

        }

        [HttpPost("Sync")]
        public async Task<IActionResult> SyncInterviewer(AddInterviewerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateInterviewer(UpdateInterviewerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveInterviewer(Guid id)
        {
            await _mediator.Send(new RemoveInterviewerCommand(id));
            return Ok();
        }
        [HttpDelete("Activate/{id:guid}")]
        public async Task<IActionResult> ActionToActivateInterviewers(Guid id)
        {
            await _mediator.Send(new ActivateInterviewerCommand(id));
            return Ok();
        }
    }
}
