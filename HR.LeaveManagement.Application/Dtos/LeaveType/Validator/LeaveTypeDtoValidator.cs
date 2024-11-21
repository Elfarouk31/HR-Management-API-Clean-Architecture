using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveType.Validator
{
    public class LeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public LeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("{PropertyName} must be persent");
        }
    }
}
