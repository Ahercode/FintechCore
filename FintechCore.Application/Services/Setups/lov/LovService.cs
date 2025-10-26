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

    public async Task<IEnumerable<LovDto>> GetAllLovsAsync()
    {
        _logger.LogInformation("Getting all lovs");
        var lovs = await _unitOfWork.LovRepository.GetAll();
        return _mapper.Map<IEnumerable<LovDto>>(lovs);
    }

    public async Task<LovDto> GetLovByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting lov with id {Id}", id);
        var lov = await _unitOfWork.LovRepository.GetById(id);
        if (lov == null)
        {
            _logger.LogWarning("Lov with id {Id} not found", id);
            throw new KeyNotFoundException($"Lov with id {id} not found");
        }
        return _mapper.Map<LovDto>(lov);
    }

    public async Task<LovDto> CreateLovAsync(CreateLovDto dto)
    {
        _logger.LogInformation("Creating a new lov");
        var lov = _mapper.Map<Lov>(dto);
        
        lov.LovId = Guid.NewGuid();
        lov.DateCreated = DateTime.Now;
        
        _unitOfWork.LovRepository.Add(lov);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<LovDto>(lov);
    }

    public async Task<LovDto> UpdateLovAsync(Guid id, UpdateLovDto dto)
    {
        _logger.LogInformation("Updating lov with id {Id}", id);
        var lov = await _unitOfWork.LovRepository.GetById(id);
        if (lov == null)
        {
            _logger.LogWarning("Lov with id {Id} not found", id);
            throw new KeyNotFoundException($"Lov with id {id} not found");
        }
        
        _mapper.Map(dto, lov);
        
        _unitOfWork.LovRepository.Update(lov);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<LovDto>(lov);
    }

    public async Task<bool> DeleteLovAsync(Guid id)
    {
        _logger.LogInformation("Deleting lov with id {Id}", id);
        var lov = await  _unitOfWork.LovRepository.GetById(id);
        if (lov == null)
        {
            _logger.LogWarning("Lov with id {Id} not found", id);
            throw new KeyNotFoundException($"Lov with id {id} not found");
        }
        
        _unitOfWork.LovRepository.Delete(lov);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}