using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveAllocation.Validator;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handler.Command
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommandRequest, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new LeaveAllocationUpdateDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveAllocationUpdateDto);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);


            var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationUpdateDto.Id);
            _mapper.Map(request.LeaveAllocationUpdateDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
