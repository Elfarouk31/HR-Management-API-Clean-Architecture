using HR.LeaveManagement.Application.Dtos.LeaveRequests;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public LeaveRequestCreateDto leaveRequestCreateDto;
    }
}
