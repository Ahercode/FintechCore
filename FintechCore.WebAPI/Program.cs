using FintechCore.Application.MappingProfiles;
using FintechCore.Domain.Interfaces;
using FintechCore.Infrastructure.DBContext;
using FintechCore.Infrastructure.UnitOfWork;
using FintechCore.WebAPI.Extentions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("FintechCoreConnection");
builder.Services.AddDbContext<FintechCoreContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(DomainToResponse).Assembly);
builder.Services.AddAutoMapper(typeof(RequestToDomain).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddApplicationServices();


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