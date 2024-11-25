using HR.LeaveManagement.Application;
using HR.LeaveManagement.Persistence;
using HR.LeaveManagement.Domian;
using HR.LeaveManagement.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigurationApplicationServices();
builder.Services.ConfigurationPersistenceServices(builder.Configuration);
builder.Services.ConfigurationInfrastructureServices(builder.Configuration);

builder.Services.AddDbContext<LeaveManagementDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LeaveManagementConnectionString"));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

