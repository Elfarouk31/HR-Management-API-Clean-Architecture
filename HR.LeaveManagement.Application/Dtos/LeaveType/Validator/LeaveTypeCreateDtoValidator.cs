using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveType.Validator
{
    public class LeaveTypeCreateDtoValidator : AbstractValidator<LeaveTypeCreateDto>
    {
        public LeaveTypeCreateDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
