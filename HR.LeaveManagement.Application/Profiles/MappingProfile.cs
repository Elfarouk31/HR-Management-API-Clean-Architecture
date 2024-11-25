using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using HR.LeaveManagement.Application.Dtos.LeaveRequests;
using HR.LeaveManagement.Application.Dtos.LeaveType;
using HR.LeaveManagement.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region LeaveRequest Mappings
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateCreated))
                .ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestCreateDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestUpdateDto>().ReverseMap();
            #endregion LeaveRequest

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationCreateDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationUpdateDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeCreateDto>().ReverseMap();
        }
    }
}
