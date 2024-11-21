using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveType.Validator
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName must Not exceed 60 char}");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyDefaultDays} is required")
                .GreaterThan(0).WithMessage("{PropertyDefaultDays} must be greater than 0")
                .LessThan(100).WithMessage("{PropertyDefaultDays} must be less than 100");
        }
    }
}
