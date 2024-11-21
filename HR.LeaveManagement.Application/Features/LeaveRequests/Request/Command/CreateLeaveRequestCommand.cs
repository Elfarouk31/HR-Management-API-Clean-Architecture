using HR.LeaveManagement.Application.Dtos.LeaveRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public LeaveRequestCreateDto leaveRequestCreateDto;
    }
}
