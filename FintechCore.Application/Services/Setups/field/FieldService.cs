using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.field;

public class FieldService: IFieldService
{
    public Task<IEnumerable<FieldDto>> GetAllFieldesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FieldDto> GetFieldByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<FieldDto> CreateFieldAsync(CreateFieldDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<FieldDto> UpdateFieldAsync(Guid id, UpdateFieldDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFieldAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}