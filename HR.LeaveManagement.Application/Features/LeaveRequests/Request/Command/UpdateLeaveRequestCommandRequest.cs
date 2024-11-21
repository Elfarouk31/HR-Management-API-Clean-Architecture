using HR.LeaveManagement.Application.Dtos.LeaveRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command
{
    public class UpdateLeaveRequestCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveRequestChangeApprovalDto ChangeApproval { get; set; }
        public LeaveRequestUpdateDto LeaveRequestUpdateDto { get; set; }
    }
}
