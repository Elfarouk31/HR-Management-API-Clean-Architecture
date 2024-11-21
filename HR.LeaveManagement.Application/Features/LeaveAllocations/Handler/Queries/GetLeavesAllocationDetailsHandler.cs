using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Request.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handler.Queries
{
    public class GetLeavesAllocationDetailsHandler : IRequestHandler<GetLeaveAllocationDetailesRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeavesAllocationDetailsHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailesRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<LeaveAllocationDto>(await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id));
            return leaveAllocation;
        }
    }
}
