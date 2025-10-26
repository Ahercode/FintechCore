using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FintechCore.Application.Services.Setups.form;

public class FormService : IFormService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<FormService> _logger;
    private readonly IMapper _mapper;

    public FormService(IUnitOfWork unitOfWork, ILogger<FormService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FormDto>> GetAllFormesAsync()
    {
        _logger.LogInformation("Getting all forms");
        var forms = await  _unitOfWork.FormRepository.GetAll();
        return _mapper.Map<IEnumerable<FormDto>>(forms);
    }

    public async Task<FormDto> GetFormByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting form with id {Id}", id);
        var form = await _unitOfWork.FormRepository.GetById(id);
        if (form == null)
        {
            _logger.LogWarning("Form with id {Id} not found", id);
            throw new KeyNotFoundException($"Form with id {id} not found");
        }
        return _mapper.Map<FormDto>(form);
    }

    public async  Task<FormDto> CreateFormAsync(CreateFormDto dto)
    {
        _logger.LogInformation("Creating a new form");
        var form = _mapper.Map<Form>(dto);
        _unitOfWork.FormRepository.Add(form);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<FormDto>(form);
    }

    public async Task<FormDto> UpdateFormAsync(Guid id, UpdateFormDto dto)
    {
        _logger.LogInformation("Updating form with id {Id}", id);
        var form = await _unitOfWork.FormRepository.GetById(id);
        if (form == null)
        {
            _logger.LogWarning("Form with id {Id} not found", id);
            throw new KeyNotFoundException($"Form with id {id} not found");
        }
        _mapper.Map(dto, form);
        
        form.DateModified = DateTime.Now;
        
        _unitOfWork.FormRepository.Update(form);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<FormDto>(form);
    }

    public async Task<bool> DeleteFormAsync(Guid id)
    {
        _logger.LogInformation("Deleting form with id {Id}", id);
        var form = await  _unitOfWork.FormRepository.GetById(id);
        if (form == null)
        {
            _logger.LogWarning("Form with id {Id} not found", id);
            throw new KeyNotFoundException($"Form with id {id} not found");
        }
        var deletedForm = _mapper.Map<Form>(form);
        _unitOfWork.FormRepository.Delete(deletedForm);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}