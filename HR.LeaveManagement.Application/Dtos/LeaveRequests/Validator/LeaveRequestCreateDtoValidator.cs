using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Dtos.LeaveRequests.Validator
{
    public class LeaveRequestCreateDtoValidator : AbstractValidator<LeaveRequestCreateDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveRequestCreateDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

        }
    }
}
