using CrmApi.Services;
using Microsoft.EntityFrameworkCore;
using CrmApi.Data;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDb>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("BankDb")));
builder.Services.AddControllers();
builder.Services.AddScoped<ISegmentService, SegmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


var app=builder.Build();

app.MapControllers(); app.Run();
