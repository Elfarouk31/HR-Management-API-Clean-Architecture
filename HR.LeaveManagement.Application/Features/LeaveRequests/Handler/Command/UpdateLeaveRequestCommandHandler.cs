using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveRequests.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handler.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommandRequest, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommandRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.LeaveRequestUpdateDto != null)
            { 
                var validator = new LeaveRequestUpdateDtoValidator(_leaveTypeRepository);
                var validationResult = await validator.ValidateAsync(request.LeaveRequestUpdateDto);

                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);
            }

            if (request.ChangeApproval is not null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeApproval.Approved);
            }
            else if(request.LeaveRequestUpdateDto is not null)
            {
                _mapper.Map(request.LeaveRequestUpdateDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            return Unit.Value;
        }
    }
}
