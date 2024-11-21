using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveRequests.Validator
{
    public class LeaveRequestUpdateDtoValidator : AbstractValidator<LeaveRequestUpdateDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveRequestUpdateDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("{PropertyName must be persent}");
        }
    }
}
