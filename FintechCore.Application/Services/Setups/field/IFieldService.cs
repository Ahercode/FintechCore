using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.field;

public interface IFieldService
{
    Task<IEnumerable<FieldDto>> GetAllFieldesAsync();
    Task<FieldDto> GetFieldByIdAsync(Guid id);
    Task<FieldDto> CreateFieldAsync(CreateFieldDto dto);
    Task<FieldDto> UpdateFieldAsync(Guid id, UpdateFieldDto dto);
    Task<bool> DeleteFieldAsync(Guid id);
}