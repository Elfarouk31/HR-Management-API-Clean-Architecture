using HR.LeaveManagement.Application.Persistence.Contracts;
using LeaveManagemen.Persistence.Repositories;
using LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence
{
    public class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurationPersistenceServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<LeaveManagementDbContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString"));
            });

            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            service.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            service.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            return service;
        }
    }
}
