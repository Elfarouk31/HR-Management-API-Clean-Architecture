using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveAllocation.Validator
{
    public class LeaveAllocationCreateDtoValidator : AbstractValidator<LeaveAllocationCreateDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveAllocationCreateDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

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
