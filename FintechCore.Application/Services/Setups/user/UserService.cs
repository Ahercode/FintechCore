using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.lov;
using FintechCore.Domain.Entities.Setups;
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

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        _logger.LogInformation("Getting all user groups");
        var users = await _unitOfWork.UserRepository.GetAll();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        _logger.LogInformation("Getting user with id {Id}", id);
        var user = await _unitOfWork.UserRepository.GetById(id);
        if (user == null)
        {
            _logger.LogWarning("User with id {Id} not found", id);
            throw new KeyNotFoundException($"User with id {id} not found");
        }
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
    {
        _logger.LogInformation("Creating a new user");
        var user = _mapper.Map<User>(dto);

        user.DateCreated = DateTime.UtcNow;
        user.Status= 1;
        user.Disabled = 0;
        
        _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        _logger.LogInformation("Updating user with id {Id}", id);
        var user = await _unitOfWork.UserRepository.GetById(id);
        if (user == null)
        {
            _logger.LogWarning("User with id {Id} not found", id);
            throw new KeyNotFoundException($"User with id {id} not found");
        }
        
        _mapper.Map(dto, user);
        
        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        _logger.LogInformation("Deleting user with id {Id}", id);
        var user = await _unitOfWork.UserRepository.GetById(id);
        if (user == null)
        {
            _logger.LogWarning("User with id {Id} not found", id);
            throw new KeyNotFoundException($"User with id {id} not found");
        }
        
        _unitOfWork.UserRepository.Delete(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}