using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveAllocation.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handler.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommandRequest, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new LeaveAllocationCreateDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveAllocationCreateDto);
            
            if (validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Crate Faild";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationCreateDto);

            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            response.Success = true;
            response.Message = "Crate Successful";
            response.Id = leaveAllocation.Id;

            return response;
        }
    }
}
