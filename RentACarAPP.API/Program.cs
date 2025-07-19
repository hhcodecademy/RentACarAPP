using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RentACarAPP.API.ExceptionHandlers;
using RentACarAPP.Application.Extensions;
using RentACarAPP.Application.Profiles;
using RentACarAPP.Application.Validotor;
using RentACarAPP.Persistance.DBContext;
using RentACarAPP.Persistance.Extensions;
using Serilog;
using RentACarAPP.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RentACarDB>(options =>
    
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentACarApp")),ServiceLifetime.Singleton);

builder.Services.AddRepositoryRegistration();
builder.Services.AddServiceRegistration();
builder.Services.AddInfrastructureServices();

builder.Services.AddAutoMapper(typeof(CustomProfile));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<BrandValidator>();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler < NotFoundExceptionHandler > ();
builder.Services.AddExceptionHandler < GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use the global exception handler
app.UseExceptionHandler(options => { });

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
