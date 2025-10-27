using FintechCore.Application.MappingProfiles;
using FintechCore.Domain.Interfaces;
using FintechCore.Infrastructure.DBContext;
using FintechCore.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FintechCore.WebAPI.Extensions;

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


// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(
    options =>
    {
        const string devUrl = "http://localhost:3000";
        const string devUrl2 = "http://localhost:5174";
        const string devUrl3 = "http://localhost:5173";
        const string proUurl = "";
        const string proUurls = "";
        const string proUurls2 = "";
        options.WithOrigins(devUrl, devUrl2,devUrl3, proUurl, proUurls, proUurls2)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    }
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();