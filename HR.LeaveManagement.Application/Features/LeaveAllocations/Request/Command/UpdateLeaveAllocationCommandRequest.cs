using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command
{
    public class UpdateLeaveAllocationCommandRequest : IRequest<Unit>
    {
        public LeaveAllocationUpdateDto LeaveAllocationUpdateDto { get; set; }
    }
}
