using HR.LeaveManagement.Application.Dtos.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Command;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeListRequest());

            return Ok(leaveType);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsRequest { Id = id });
            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LeaveTypeCreateDto leaveTypeCreateDto)
        {
            var command = new CreateLeaveTypeCommandRequest { LeaveTypeCreateDto = leaveTypeCreateDto };
            var respond = await _mediator.Send(command);
            return Ok(respond);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new UpdateLeaveTypeCommandRequest { LeaveTypeDto = leaveTypeDto};
            var response = await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommandRequest { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

    }
}
