using HR.LeaveManagement.Application.Dtos.LeaveRequests;
using HR.LeaveManagement.Application.Features.LeaveRequests.Handler.Command;
using HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command;
using HR.LeaveManagement.Application.Features.LeaveRequests.Request.Queries;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domian;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("Api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var command = new GetLeaveRequestListRequest();
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var command = new GetLeaveRequesDetailsRequest { Id = id };
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] LeaveRequestCreateDto leaveRequestCreate)
        {
            var command = new CreateLeaveRequestCommand { leaveRequestCreateDto = leaveRequestCreate };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeaveRequestUpdateDto leaveRequestUpdateDto)
        {
            var command = new UpdateLeaveRequestCommandRequest
                  { Id = id, LeaveRequestUpdateDto = leaveRequestUpdateDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("ChangeApproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] LeaveRequestChangeApprovalDto leaveRequestChangeApprovalDto)
        {
            var command = new UpdateLeaveRequestCommandRequest { Id = id, ChangeApproval = leaveRequestChangeApprovalDto }; 
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommandRequest { Id = id };
            var response = await _mediator.Send(command);   
            return Ok(response);
        }
    }
}
