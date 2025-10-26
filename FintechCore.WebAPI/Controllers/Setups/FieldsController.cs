using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.field;
using Microsoft.AspNetCore.Mvc;

namespace FintechCore.WebAPI.Controllers.Setups;

[ApiController]
[Route("api/v1/[controller]")]
public class FieldsController : ControllerBase
{
    private readonly IFieldService _fieldService;

    public FieldsController(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }
    
    // get all fields
    [HttpGet]
    public async Task<IActionResult> GetAllFields()
    {
        var fields = await _fieldService.GetAllFieldesAsync();
        return Ok(fields);
    }
    
    // get field by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFieldById(Guid id)
    {
        var field = await _fieldService.GetFieldByIdAsync(id);
        return Ok(field);
    }
    
    // create field
    [HttpPost]
    public async Task<IActionResult> CreateField([FromBody] CreateFieldDto dto)
    {
        var field = await _fieldService.CreateFieldAsync(dto);
        return CreatedAtAction(nameof(GetFieldById), new { id = field.FieldId }, field);
    }
    
    // update field
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateField(Guid id, [FromBody] UpdateFieldDto dto)
    {
        var field = await _fieldService.UpdateFieldAsync(id, dto);
        return Ok(field);
    }
    
    // delete field
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteField(Guid id)
    {
        await _fieldService.DeleteFieldAsync(id);
        return Ok("Field deleted successfully");
    }
}