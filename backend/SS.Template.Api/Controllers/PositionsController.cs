using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.Template.Application.Commands;
using SS.Template.Application.Features.Positions;
using SS.Template.Application.Features.Positions.Commands;
using SS.Template.Application.Features.Positions.Commands.Add;
using SS.Template.Application.Features.Positions.Commands.Remove;
using SS.Template.Application.Features.Positions.Queries.Get;
using SS.Template.Application.Features.Positions.Queries.GetPage;
using SS.Template.Application.Queries;

namespace SS.Template.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<PositionsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPage([FromQuery] GetPositionPageQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PositionsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetPositionQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(AddPositionsModel command)
        {
            await _mediator.Send(new AddPositionsCommand(new System.Collections.Generic.List<AddPositionsModel> { command }));
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, AddPositionsModel command)
        {
            await _mediator.Send(Edit.For(id, command));
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new RemovePositionsCommand(id));
            return Ok();
        }
    }
}
