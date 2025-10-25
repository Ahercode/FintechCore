using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FintechCore.Application.Services.Setups.lov;

public class LovService : ILovService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<LovService> _logger;
    private readonly IMapper _mapper;

    public LovService(IUnitOfWork unitOfWork, ILogger<LovService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<IEnumerable<LovDto>> GetAllLovsAsync()
    {
        _logger.LogInformation("Getting all lovs");
        var lovs = _unitOfWork.LovRepository.GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<LovDto>>(lovs));
    }

    public Task<LovDto> GetLovByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting lov with id {Id}", id);
        var lov = _unitOfWork.LovRepository.GetById(id);
        if (lov == null)
        {
            _logger.LogWarning("Lov with id {Id} not found", id);
            throw new KeyNotFoundException($"Lov with id {id} not found");
        }
        return Task.FromResult(_mapper.Map<LovDto>(lov));
    }

    public Task<LovDto> CreateLovAsync(CreateLovDto dto)
    {
        _logger.LogInformation("Creating a new lov");
        var lov = _mapper.Map<Lov>(dto);
        _unitOfWork.LovRepository.Add(lov);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<LovDto>(lov));
    }

    public Task<LovDto> UpdateLovAsync(Guid id, UpdateLovDto dto)
    {
        _logger.LogInformation("Updating lov with id {Id}", id);
        var lov = _unitOfWork.LovRepository.GetById(id);
        if (lov == null)
        {
            _logger.LogWarning("Lov with id {Id} not found", id);
            throw new KeyNotFoundException($"Lov with id {id} not found");
        }
        var updatedLov = _mapper.Map<Lov>(lov);
        _unitOfWork.LovRepository.Update(updatedLov);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<LovDto>(updatedLov));
    }

    public Task<bool> DeleteLovAsync(Guid id)
    {
        _logger.LogInformation("Deleting lov with id {Id}", id);
        var lov = _unitOfWork.LovRepository.GetById(id);
        if (lov == null)
        {
            _logger.LogWarning("Lov with id {Id} not found", id);
            throw new KeyNotFoundException($"Lov with id {id} not found");
        }
        var deletedLov = _mapper.Map<Lov>(lov);
        _unitOfWork.LovRepository.Delete(deletedLov);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(true);
    }
}