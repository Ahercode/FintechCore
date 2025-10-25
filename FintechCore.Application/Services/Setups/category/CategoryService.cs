using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FintechCore.Application.Services.Setups.category;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoryService> _logger;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, ILogger<CategoryService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<IEnumerable<CategoryDto>> GetAllCategoryesAsync()
    {
        _logger.LogInformation("Getting all categories");
        var categories = _unitOfWork.CategoryRepository.GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<CategoryDto>>(categories));
    }

    public Task<CategoryDto> GetCategoryByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting category with id {Id}", id);
        var category = _unitOfWork.CategoryRepository.GetById(id);
        if (category == null)
        {
            _logger.LogWarning("Category with id {Id} not found", id);
            throw new KeyNotFoundException($"Category with id {id} not found");
        }
        return Task.FromResult(_mapper.Map<CategoryDto>(category));
    }

    public Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
    {
        _logger.LogInformation("Creating a new category");
        var category = _mapper.Map<Category>(dto);
        _unitOfWork.CategoryRepository.Add(category);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<CategoryDto>(category));
    }

    public Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto dto)
    {
        _logger.LogInformation("Updating category with id {Id}", id);
        var category = _unitOfWork.CategoryRepository.GetById(id);
        if (category == null)
        {
            _logger.LogWarning("Category with id {Id} not found", id);
            throw new KeyNotFoundException($"Category with id {id} not found");
        }
        var updatedCategory = _mapper.Map<Category>(category);
        _unitOfWork.CategoryRepository.Update(updatedCategory);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<CategoryDto>(updatedCategory));
    }

    public Task<bool> DeleteCategoryAsync(Guid id)
    {
        _logger.LogInformation("Deleting category with id {Id}", id);
        var category = _unitOfWork.CategoryRepository.GetById(id);
        if (category == null)
        {
            _logger.LogWarning("Category with id {Id} not found", id);
            throw new KeyNotFoundException($"Category with id {id} not found");
        }
        
        var categoryToDelete = _mapper.Map<Category>(category);
        _unitOfWork.CategoryRepository.Delete(categoryToDelete);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(true);
    }
}