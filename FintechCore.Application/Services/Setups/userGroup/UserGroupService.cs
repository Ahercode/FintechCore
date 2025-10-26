using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.lov;
using FintechCore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FintechCore.Application.Services.Setups.userGroup;

public class UserGroupService : IUserGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserGroupService> _logger;
    private readonly IMapper _mapper;

    public UserGroupService(IUnitOfWork unitOfWork, ILogger<UserGroupService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> CreateUserAsync(CreateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}