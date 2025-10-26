using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.form;
using Microsoft.AspNetCore.Mvc;

namespace FintechCore.WebAPI.Controllers.Setups;

[ApiController]
[Route("api/v1/[controller]")]
public class FormsController: ControllerBase
{
    private readonly IFormService _formService;

    public FormsController(IFormService formService)
    {
        _formService = formService;
    }
    
    // get all forms
    [HttpGet]
    public async Task<IActionResult> GetAllForms()
    {
        var forms = await _formService.GetAllFormesAsync();
        return Ok(forms);
    }
    
    // get form by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFormById(Guid id)
    {
        var form = await _formService.GetFormByIdAsync(id);
        return Ok(form);
    }
    
    // create form
    [HttpPost]
    public async Task<IActionResult> CreateForm([FromBody] CreateFormDto dto )
    {
        var form = await _formService.CreateFormAsync(dto);
        return CreatedAtAction(nameof(GetFormById), new { id = form.FormId }, form);
    }
    
    // update form
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateForm(Guid id, [FromBody] UpdateFormDto dto)
    {
        var form = await _formService.UpdateFormAsync(id, dto);
        return Ok(form);
    }
    
    // delete form
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteForm(Guid id)
    {
        await _formService.DeleteFormAsync(id);
        return Ok("Form deleted successfully");
    }
}