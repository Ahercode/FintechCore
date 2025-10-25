using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.lov;

public interface ILovService
{
    Task<IEnumerable<LovDto>> GetAllLovesAsync();
    Task<LovDto> GetLovByIdAsync(Guid id);
    Task<LovDto> CreateLovAsync(CreateLovDto dto);
    Task<LovDto> UpdateLovAsync(Guid id, UpdateLovDto dto);
    Task<bool> DeleteLovAsync(Guid id);
}