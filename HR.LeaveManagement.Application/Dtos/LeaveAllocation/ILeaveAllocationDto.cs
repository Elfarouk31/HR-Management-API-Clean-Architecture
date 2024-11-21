using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveAllocation
{
    public interface ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTyeId { get; set; }
        public int Period { get; set; }
    }
}
