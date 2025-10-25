using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.category;

public class CategoryService : ICategoryService
{
    public Task<IEnumerable<CategoryDto>> GetAllCategoryesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> GetCategoryByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}