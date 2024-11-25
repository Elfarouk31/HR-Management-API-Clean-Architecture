using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveAllocation.Validator
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be more than 0");

            RuleFor(p => p.Period)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("{PropertyName} Period must be Grater than or Equal current year");

            RuleFor(p => p.LeaveTypeId)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                    return !leaveTypeExist;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
