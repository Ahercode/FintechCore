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

    public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting category with id {Id}", id);
        var category = await  _unitOfWork.CategoryRepository.GetById(id);
        if (category == null)
        {
            _logger.LogWarning("Category with id {Id} not found", id);
            throw new KeyNotFoundException($"Category with id {id} not found");
        }
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
    {
        _logger.LogInformation("Creating a new category");
        var category = _mapper.Map<Category>(dto);
        category.DateCreated= DateTime.UtcNow;
        _unitOfWork.CategoryRepository.Add(category);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto dto)
    {
        _logger.LogInformation("Updating category with id {Id}", id);
        var category = await  _unitOfWork.CategoryRepository.GetById(id);
        if (category == null)
        {
            _logger.LogWarning("Category with id {Id} not found", id);
            throw new KeyNotFoundException($"Category with id {id} not found");
        }
        _mapper.Map(dto, category);
        
        category.DateModified= DateTime.UtcNow;
        
        _unitOfWork.CategoryRepository.Update(category);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<CategoryDto>(category);
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