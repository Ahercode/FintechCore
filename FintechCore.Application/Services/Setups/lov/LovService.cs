using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.lov;

public class LovService : ILovService
{
    public Task<IEnumerable<LovDto>> GetAllLovesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<LovDto> GetLovByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<LovDto> CreateLovAsync(CreateLovDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<LovDto> UpdateLovAsync(Guid id, UpdateLovDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteLovAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}