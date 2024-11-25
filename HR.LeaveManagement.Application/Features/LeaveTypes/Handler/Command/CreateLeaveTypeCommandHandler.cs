using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveType.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Command;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domian;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handler.Command
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommandRequest, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var Validator = new LeaveTypeCreateDtoValidator();
            var ValidateResult = await Validator.ValidateAsync(request.LeaveTypeCreateDto);

            if (ValidateResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Create falid";
                response.Errors = ValidateResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var leaveType= _mapper.Map<LeaveType>(request.LeaveTypeCreateDto);

            await _leaveTypeRepository.Add(leaveType);

            response.Success = true;
            response.Message = "Create Success";
            response.Id = leaveType.Id;

            return response;
        }
    }
}
