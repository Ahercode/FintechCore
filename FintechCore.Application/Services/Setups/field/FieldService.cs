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

    public async Task<IEnumerable<FieldDto>> GetAllFieldesAsync()
    {
        _logger.LogInformation("Getting all fields");
        var fields = await  _unitOfWork.FieldRepository.GetAll();
        return _mapper.Map<IEnumerable<FieldDto>>(fields);
    }

    public async Task<FieldDto> GetFieldByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting field with id {Id}", id);
        var field = await _unitOfWork.FieldRepository.GetById(id);
        if (field == null)
        {
            _logger.LogWarning("Field with id {Id} not found", id);
            throw new KeyNotFoundException($"Field with id {id} not found");
        }
        return _mapper.Map<FieldDto>(field);
    }

    public async Task<FieldDto> CreateFieldAsync(CreateFieldDto dto)
    {
        _logger.LogInformation("Creating a new field");
        var field = _mapper.Map<Field>(dto);
        
        field.FieldId=Guid.NewGuid();
        field.DateCreated=DateTime.UtcNow;
        
        _unitOfWork.FieldRepository.Add(field);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<FieldDto>(field);
    }

    public async Task<FieldDto> UpdateFieldAsync(Guid id, UpdateFieldDto dto)
    {
        _logger.LogInformation("Updating field with id {Id}", id);
        var field =await  _unitOfWork.FieldRepository.GetById(id);
        if (field == null)
        {
            _logger.LogWarning("Field with id {Id} not found", id);
            throw new KeyNotFoundException($"Field with id {id} not found");
        }
        _mapper.Map(dto, field);
        
        field.DateModified = DateTime.UtcNow;
        
        _unitOfWork.FieldRepository.Update(field);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<FieldDto>(field);
    }

    public async Task<bool> DeleteFieldAsync(Guid id)
    {
        _logger.LogInformation("Deleting field with id {Id}", id);
        var field = await  _unitOfWork.FieldRepository.GetById(id);
        if (field == null)
        {
            _logger.LogWarning("Field with id {Id} not found", id);
            throw new KeyNotFoundException($"Field with id {id} not found");
        }
     
        _unitOfWork.FieldRepository.Delete(field);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}