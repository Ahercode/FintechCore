using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.form;

public interface IFormService
{
    Task<IEnumerable<FormDto>> GetAllFormesAsync();
    Task<FormDto> GetFormByIdAsync(Guid id);
    Task<FormDto> CreateFormAsync(CreateFormDto dto);
    Task<FormDto> UpdateFormAsync(Guid id, UpdateFormDto dto);
    Task<bool> DeleteFormAsync(Guid id);
}