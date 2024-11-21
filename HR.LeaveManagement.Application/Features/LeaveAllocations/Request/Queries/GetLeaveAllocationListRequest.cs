using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Queries
{
    public record GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>;

}
