using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Handler.Queries;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Queries;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domian;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var command = new GetLeaveAllocationListRequest();
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocation>> Get(int id)
        {
            var command = new GetLeaveAllocationDetailesRequest {Id = id};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] LeaveAllocationCreateDto leaveAllocationCreateDto)
        {
            var command = new CreateLeaveAllocationCommandRequest { LeaveAllocationCreateDto = leaveAllocationCreateDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] LeaveAllocationUpdateDto leaveAllocationUpdateDto)
        { 
            var command = new UpdateLeaveAllocationCommandRequest 
                   { LeaveAllocationUpdateDto = leaveAllocationUpdateDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommandRequest { Id = id };
            var response = await _mediator.Send(command);
            return Ok();
        }

    }
}
