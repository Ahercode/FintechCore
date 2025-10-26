using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.lov;
using FintechCore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FintechCore.Application.Services.Setups.user;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserGroupDto>> GetAllUserGroupsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserGroupDto> GetUserGroupByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserGroupDto> CreateUserGroupAsync(CreateUserGroupDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserGroupDto> UpdateUserGroupAsync(int id, UpdateUserGroupDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserGroupAsync(int id)
    {
        throw new NotImplementedException();
    }
}