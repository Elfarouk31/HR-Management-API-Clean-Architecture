using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveType.Validator;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Command;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domian;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handler.Command
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommandRequest, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var Validator = new LeaveTypeDtoValidator();
            var ValidateResult = await Validator.ValidateAsync(request.LeaveTypeCreateDto);

            if (ValidateResult.IsValid == false)
            {
                throw new Exception();
            }

            var leaveType= _mapper.Map<LeaveType>(request.LeaveTypeCreateDto);

            await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
