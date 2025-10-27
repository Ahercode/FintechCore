using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.userGroup;
using Microsoft.AspNetCore.Mvc;

namespace FintechCore.WebAPI.Controllers.Setups;

[ApiController]
[Route("api/v1/[controller]")]
public class UserGroupsController : ControllerBase
{
    private readonly IUserGroupService _userGroupService;

    public UserGroupsController(IUserGroupService userGroupService)
    {
        _userGroupService = userGroupService;
    }
    
    // get all
    [HttpGet]
    public async Task<IActionResult> GetAllUserGroups()
    {
        var userGroups = await _userGroupService.GetAllUserGroupsAsync();
        return Ok(userGroups);
    }
    
    // get by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserGroupById(int id)
    {
        var userGroup = await _userGroupService.GetUserGroupByIdAsync(id);
        return Ok(userGroup);
    }
    
    // create new 
    [HttpPost]
    public async Task<IActionResult> CreateUserGroup([FromBody] CreateUserGroupDto dto)
    {
        var userGroup = await _userGroupService.CreateUserGroupAsync(dto);
        return CreatedAtAction(nameof(GetUserGroupById), new { id = userGroup.Id }, userGroup);
    }
    
    // update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserGroup(int id, [FromBody] UpdateUserGroupDto dto)
    {
        var userGroup = await _userGroupService.UpdateUserGroupAsync(id, dto);
        return Ok(userGroup);
    }
    
    // delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserGroup(int id)
    {
        await _userGroupService.DeleteUserGroupAsync(id);
        return Ok("User Group deleted successfully");
    }
}