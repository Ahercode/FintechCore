using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FintechCore.Application.Services.Setups.branch;

public class BranchService : IBranchService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BranchService> _logger;
    private readonly IMapper _mapper;

    public BranchService(IUnitOfWork unitOfWork, ILogger<BranchService> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public async  Task<IEnumerable<BranchDto>> GetAllBranchesAsync()
    {
        _logger.LogInformation("Getting all branches");
        var branches = await _unitOfWork.BranchRepository.GetAll();
        return _mapper.Map<IEnumerable<BranchDto>>(branches);
    }

    public async Task<BranchDto> GetBranchByIdAsync(int id)
    {
        _logger.LogInformation("Getting branch with id {Id}", id);
        var branch = await _unitOfWork.BranchRepository.GetById(id);
        if (branch == null)
        {
            _logger.LogWarning("Branch with id {Id} not found", id);
            throw new KeyNotFoundException($"Branch with id {id} not found");
        }
        return _mapper.Map<BranchDto>(branch);
    }

    public async Task<BranchDto> CreateBranchAsync(CreateBranchDto dto)
    {
        _logger.LogInformation("Creating a new branch");
        var branch = _mapper.Map<Branch>(dto);
        
        branch.CreatedAt=DateTime.UtcNow;
        branch.IsActive=true;
        
        _unitOfWork.BranchRepository.Add(branch);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<BranchDto>(branch);
    }

    public async Task<BranchDto> UpdateBranchAsync(int id, UpdateBranchDto dto)
    {
        _logger.LogInformation("Updating branch with id {Id}", id);
        var branch = await  _unitOfWork.BranchRepository.GetById(id);
        if (branch == null)
        {
            _logger.LogWarning("Branch with id {Id} not found", id);
            throw new KeyNotFoundException($"Branch with id {id} not found");
        }
       
        _mapper.Map(dto, branch);
        branch.UpdatedAt=DateTime.UtcNow;

        _unitOfWork.BranchRepository.Update(branch);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<BranchDto>(branch);
    }

    public async Task<bool> DeleteBranchAsync(int id)
    {
        _logger.LogInformation("Deleting branch with id {Id}", id);
        var branch = await _unitOfWork.BranchRepository.GetById(id);
        if (branch == null)
        {
            _logger.LogWarning("Branch with id {Id} not found", id);
            throw new KeyNotFoundException($"Branch with id {id} not found");
        }
        
        _unitOfWork.BranchRepository.Delete(branch);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}