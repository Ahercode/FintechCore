using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.lov;
using FintechCore.Domain.Entities.Setups;
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

    public async Task<IEnumerable<UserGroupDto>> GetAllUserGroupsAsync()
    {
        _logger.LogInformation("Getting all user groups");
        var userGroups = await _unitOfWork.UserGroupRepository.GetAll();
        return _mapper.Map<IEnumerable<UserGroupDto>>(userGroups);
    }

    public async Task<UserGroupDto> GetUserGroupByIdAsync(int id)
    {
        _logger.LogInformation("Getting user group with id {Id}", id);
        var userGroup = await _unitOfWork.UserGroupRepository.GetById(id);
        if (userGroup == null)
        {
            _logger.LogWarning("User group with id {Id} not found", id);
            throw new KeyNotFoundException($"User group with id {id} not found");
        }
        return _mapper.Map<UserGroupDto>(userGroup);
    }

    public async Task<UserGroupDto> CreateUserGroupAsync(CreateUserGroupDto dto)
    {
        _logger.LogInformation("Creating a new user group");
        var userGroup = _mapper.Map<UserGroup>(dto);
        
        _unitOfWork.UserGroupRepository.Add(userGroup);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<UserGroupDto>(userGroup);
    }

    public async Task<UserGroupDto> UpdateUserGroupAsync(int id, UpdateUserGroupDto dto)
    {
        _logger.LogInformation("Updating user group with id {Id}", id);
        var userGroup = await _unitOfWork.UserGroupRepository.GetById(id);
        if (userGroup == null)
        {
            _logger.LogWarning("User group with id {Id} not found", id);
            throw new KeyNotFoundException($"User group with id {id} not found");
        }
        
        _mapper.Map(dto, userGroup);
        
        _unitOfWork.UserGroupRepository.Update(userGroup);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<UserGroupDto>(userGroup);
    }

    public async Task<bool> DeleteUserGroupAsync(int id)
    {
        _logger.LogInformation("Deleting user group with id {Id}", id);
        
        var userGroup = await _unitOfWork.UserGroupRepository.GetById(id);
        if (userGroup == null)
            throw new KeyNotFoundException($"User group with id {id} not found");
        
        _unitOfWork.UserGroupRepository.Delete(userGroup);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}