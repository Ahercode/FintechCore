using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.userGroup;

public interface IUserGroupService
{
    Task<IEnumerable<UserGroupDto>> GetAllUserGroupsAsync();
    Task<UserGroupDto> GetUserGroupByIdAsync(int id);
    Task<UserGroupDto> CreateUserGroupAsync(CreateUserGroupDto dto);
    Task<UserGroupDto> UpdateUserGroupAsync(int id, UpdateUserGroupDto dto);
    Task<bool> DeleteUserGroupAsync(int id);
}