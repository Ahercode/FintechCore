using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.lov;
using Microsoft.AspNetCore.Mvc;

namespace FintechCore.WebAPI.Controllers.Setups;

[ApiController]
[Route("api/v1/[controller]")]
public class LovsController : ControllerBase
{
    private readonly ILovService _lovService;

    public LovsController(ILovService lovService)
    {
        _lovService = lovService;
    }
    
    // get all lovs
    [HttpGet]
    public async Task<IActionResult> GetAllLovs()
    {
        var lovs = await _lovService.GetAllLovsAsync();
        return Ok(lovs);
    }
    
    // get lov by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLovById(Guid id)
    {
        var lov = await _lovService.GetLovByIdAsync(id);
        return Ok(lov);
    }
    
    // create lov
    [HttpPost]
    public async Task<IActionResult> CreateLov([FromBody] CreateLovDto dto)
    {
        var lov = await _lovService.CreateLovAsync(dto);
        return Ok(lov);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLov(Guid id)
    {
        await _lovService.DeleteLovAsync(id);
        return Ok("Lov deleted successfully");
    }
}