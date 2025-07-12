using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RentACarAPP.Application.Extensions;
using RentACarAPP.Application.Profiles;
using RentACarAPP.Application.Validotor;
using RentACarAPP.Persistance.DBContext;
using RentACarAPP.Persistance.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RentACarDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentACarApp")));

builder.Services.AddRepositoryRegistration();
builder.Services.AddServiceRegistration();

builder.Services.AddAutoMapper(typeof(CustomProfile));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<BrandValidator>();

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
