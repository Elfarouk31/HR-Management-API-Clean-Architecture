using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveAllocation.Validator
{
    public class LeaveAllocationUpdateDtoValidator : AbstractValidator<LeaveAllocationUpdateDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveAllocationUpdateDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("{PropertyName} must have Id");
        }
    }
}
