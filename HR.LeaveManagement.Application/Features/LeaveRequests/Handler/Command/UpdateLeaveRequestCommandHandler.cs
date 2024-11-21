using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommandRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if(request.ChangeApproval is not null)
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
