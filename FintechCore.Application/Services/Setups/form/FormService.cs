using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.form;

public class FormService : IFormService
{
    public Task<IEnumerable<FormDto>> GetAllFormesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FormDto> GetFormByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<FormDto> CreateFormAsync(CreateFormDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<FormDto> UpdateFormAsync(Guid id, UpdateFormDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFormAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}