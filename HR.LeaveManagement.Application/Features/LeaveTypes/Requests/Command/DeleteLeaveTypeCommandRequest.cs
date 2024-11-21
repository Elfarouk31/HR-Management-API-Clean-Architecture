using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Command
{
    public class DeleteLeaveTypeCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
