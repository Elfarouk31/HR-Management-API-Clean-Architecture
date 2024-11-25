using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagemen.Persistence.Repositories;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurationPersistenceServices(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            service.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            service.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            return service;
        }
    }
}
