using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.branch;
using Microsoft.AspNetCore.Mvc;

namespace FintechCore.WebAPI.Controllers.Setups;

[ApiController]
[Route("api/v1/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchesController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBranches()
    {
        var branches = await _branchService.GetAllBranchesAsync();
        
        return Ok(branches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBranchById(int id)
    {
        var branch = await _branchService.GetBranchByIdAsync(id);
        return Ok(branch);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchDto dto)
    {
        var branch = await _branchService.CreateBranchAsync(dto);
        return CreatedAtAction(nameof(GetBranchById), new { id = branch.Id }, branch);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBranch(int id, [FromBody] UpdateBranchDto dto)
    {
        var branch = await _branchService.UpdateBranchAsync(id, dto);
        return Ok(branch);
    }

    [HttpDelete("{id}")]
    
    public async Task<IActionResult> DeleteBranch(int id)
    {
        await _branchService.DeleteBranchAsync(id);
        return NoContent();
    }
}