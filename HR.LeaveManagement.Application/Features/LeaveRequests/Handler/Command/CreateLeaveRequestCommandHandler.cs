using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveRequests;
using HR.LeaveManagement.Application.Dtos.LeaveRequests.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command;
using HR.LeaveManagement.Application.Model;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Persistence.Infrastructure;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handler.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender,  IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new LeaveRequestCreateDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveRequestCreateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Create Faild";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.leaveRequestCreateDto);

            await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Create Success";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your Leave Request For {request.leaveRequestCreateDto.StartDate:D} to" +
                $" {request.leaveRequestCreateDto.EndDate:D} has been sumitted successfully",
                subject  = "Leave Request Submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
            }

            return response;
        }
    }
}
