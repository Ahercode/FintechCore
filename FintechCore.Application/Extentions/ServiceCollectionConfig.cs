using FintechCore.Application.Services.Setups.branch;
using FintechCore.Application.Services.Setups.category;
using FintechCore.Application.Services.Setups.field;
using FintechCore.Application.Services.Setups.lov;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FintechCore.Application.Extentions;

public static class ServiceCollectionConfig
{
    public static void  AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFieldService, FieldService>();
        services.AddScoped<IFieldService, IFieldService>();
        services.AddScoped<ILovService, LovService>();
    }
}