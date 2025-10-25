using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Application.Services.Setups.category;
using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FintechCore.Application.Services.Setups.field;

public class FieldService: IFieldService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<FieldService> _logger;
    private readonly IMapper _mapper;

    public FieldService(IUnitOfWork unitOfWork, ILogger<FieldService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<IEnumerable<FieldDto>> GetAllFieldesAsync()
    {
        _logger.LogInformation("Getting all fields");
        var fields = _unitOfWork.FieldRepository.GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<FieldDto>>(fields));
    }

    public Task<FieldDto> GetFieldByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting field with id {Id}", id);
        var field = _unitOfWork.FieldRepository.GetById(id);
        if (field == null)
        {
            _logger.LogWarning("Field with id {Id} not found", id);
            throw new KeyNotFoundException($"Field with id {id} not found");
        }
        return Task.FromResult(_mapper.Map<FieldDto>(field));
    }

    public Task<FieldDto> CreateFieldAsync(CreateFieldDto dto)
    {
        _logger.LogInformation("Creating a new field");
        var field = _mapper.Map<Field>(dto);
        _unitOfWork.FieldRepository.Add(field);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<FieldDto>(field));
    }

    public Task<FieldDto> UpdateFieldAsync(Guid id, UpdateFieldDto dto)
    {
        _logger.LogInformation("Updating field with id {Id}", id);
        var field = _unitOfWork.FieldRepository.GetById(id);
        if (field == null)
        {
            _logger.LogWarning("Field with id {Id} not found", id);
            throw new KeyNotFoundException($"Field with id {id} not found");
        }
        var updatedField = _mapper.Map<Field>(field);
        _unitOfWork.FieldRepository.Update(updatedField);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<FieldDto>(updatedField));
    }

    public Task<bool> DeleteFieldAsync(Guid id)
    {
        _logger.LogInformation("Deleting field with id {Id}", id);
        var field = _unitOfWork.FieldRepository.GetById(id);
        if (field == null)
        {
            _logger.LogWarning("Field with id {Id} not found", id);
            throw new KeyNotFoundException($"Field with id {id} not found");
        }
        var deletedField = _mapper.Map<Field>(field);
        _unitOfWork.FieldRepository.Delete(deletedField);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(true);
    }
}