using HR.LeaveManagement.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveRequests
{
    public class LeaveRequestChangeApprovalDto : BaseDto
    {
        public bool Approved { get; set; }
    }
}
