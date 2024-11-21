using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command
{
    public class DeleteLeaveRequestCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
