using CRM.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services
//  .AddScoped<IAppointmentService, AppointmentService>()
//  .AddScoped<IAvailabilityService, AvailabilityService >()
//  .AddScoped<ICompanyService, CompanyService >()
//  .AddScoped<ICompanyWorkerService, CompanyWorkerService >()
//  .AddScoped<ICustomerService, CustomerService >()
//  .AddScoped<IOfferedServicesService, OfferedServicesService >()


// Configure Entity Framework with PostgreSQL
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DB")));

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
