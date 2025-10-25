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

    public Task<IEnumerable<FormDto>> GetAllFormesAsync()
    {
        _logger.LogInformation("Getting all forms");
        var forms = _unitOfWork.FormRepository.GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<FormDto>>(forms));
    }

    public Task<FormDto> GetFormByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting form with id {Id}", id);
        var form = _unitOfWork.FormRepository.GetById(id);
        if (form == null)
        {
            _logger.LogWarning("Form with id {Id} not found", id);
            throw new KeyNotFoundException($"Form with id {id} not found");
        }
        return Task.FromResult(_mapper.Map<FormDto>(form));
    }

    public Task<FormDto> CreateFormAsync(CreateFormDto dto)
    {
        _logger.LogInformation("Creating a new form");
        var form = _mapper.Map<Form>(dto);
        _unitOfWork.FormRepository.Add(form);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<FormDto>(form));
    }

    public Task<FormDto> UpdateFormAsync(Guid id, UpdateFormDto dto)
    {
        _logger.LogInformation("Updating form with id {Id}", id);
        var form = _unitOfWork.FormRepository.GetById(id);
        if (form == null)
        {
            _logger.LogWarning("Form with id {Id} not found", id);
            throw new KeyNotFoundException($"Form with id {id} not found");
        }
        var updatedForm = _mapper.Map<Form>(form);
        _unitOfWork.FormRepository.Update(updatedForm);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<FormDto>(updatedForm));
    }

    public Task<bool> DeleteFormAsync(Guid id)
    {
        _logger.LogInformation("Deleting form with id {Id}", id);
        var form = _unitOfWork.FormRepository.GetById(id);
        if (form == null)
        {
            _logger.LogWarning("Form with id {Id} not found", id);
            throw new KeyNotFoundException($"Form with id {id} not found");
        }
        var deletedForm = _mapper.Map<Form>(form);
        _unitOfWork.FormRepository.Delete(deletedForm);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(true);
    }
}