using FintechCore.Application.Services.Setups.branch;
using FintechCore.Application.Services.Setups.category;
using FintechCore.Application.Services.Setups.field;
using FintechCore.Application.Services.Setups.lov;
using FintechCore.Application.Services.Setups.user;
using FintechCore.Application.Services.Setups.userGroup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FintechCore.WebAPI.Extentions;

public static class ServiceCollectionConfig
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFieldService, FieldService>();
        services.AddScoped<IFieldService, FieldService>();
        services.AddScoped<ILovService, LovService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserGroupService, UserGroupService>();
    }
}