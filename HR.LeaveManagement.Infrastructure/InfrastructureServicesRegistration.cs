using HR.LeaveManagement.Application.Model;
using HR.LeaveManagement.Application.Persistence.Infrastructure;
using HR.LeaveManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration 
    {
        public static IServiceCollection ConfigurationInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            service.AddTransient<IEmailSender, EmailSender>();

            return service;
        }
    }
}
