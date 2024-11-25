using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command
{
    public class CreateLeaveAllocationCommandRequest : IRequest<BaseCommandResponse>
    {
        public LeaveAllocationCreateDto LeaveAllocationCreateDto;
    }
}
