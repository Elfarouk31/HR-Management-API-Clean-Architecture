using HR.LeaveManagement.Application.Dtos.LeaveType;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Command
{
    public class CreateLeaveTypeCommandRequest : IRequest<BaseCommandResponse>
    {
        public LeaveTypeCreateDto LeaveTypeCreateDto { get; set; }
    }
}
