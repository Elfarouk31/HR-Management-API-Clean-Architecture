using HR.LeaveManagement.Application.Dtos.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Command
{
    public class CreateLeaveTypeCommandRequest : IRequest<int>
    {
        public LeaveTypeCreateDto LeaveTypeCreateDto { get; set; }
    }
}
