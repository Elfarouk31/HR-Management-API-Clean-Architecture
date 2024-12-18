﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command
{
    public class DeleteLeaveAllocationCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
