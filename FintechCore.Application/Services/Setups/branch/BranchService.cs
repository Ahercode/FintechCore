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

    public Task<IEnumerable<BranchDto>> GetAllBranchesAsync()
    {
        _logger.LogInformation("Getting all branches");
        var branches = _unitOfWork.BranchRepository.GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<BranchDto>>(branches));
    }

    public Task<BranchDto> GetBranchByIdAsync(int id)
    {
        _logger.LogInformation("Getting branch with id {Id}", id);
        var branch = _unitOfWork.BranchRepository.GetById(id);
        if (branch == null)
        {
            _logger.LogWarning("Branch with id {Id} not found", id);
            throw new KeyNotFoundException($"Branch with id {id} not found");
        }
        return Task.FromResult(_mapper.Map<BranchDto>(branch));
    }

    public Task<BranchDto> CreateBranchAsync(CreateBranchDto dto)
    {
        _logger.LogInformation("Creating a new branch");
        var branch = _mapper.Map<Branch>(dto);
        _unitOfWork.BranchRepository.Add(branch);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<BranchDto>(branch));
        
    }

    public Task<BranchDto> UpdateBranchAsync(int id, UpdateBranchDto dto)
    {
        _logger.LogInformation("Updating branch with id {Id}", id);
        var branch = _unitOfWork.BranchRepository.GetById(id);
        if (branch == null)
        {
            _logger.LogWarning("Branch with id {Id} not found", id);
            throw new KeyNotFoundException($"Branch with id {id} not found");
        }
        var updatedBranch = _mapper.Map<Branch>(branch);
        
        _unitOfWork.BranchRepository.Update(updatedBranch);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(_mapper.Map<BranchDto>(branch));
    }

    public Task<bool> DeleteBranchAsync(int id)
    {
        _logger.LogInformation("Deleting branch with id {Id}", id);
        var branch = _unitOfWork.BranchRepository.GetById(id);
        if (branch == null)
        {
            _logger.LogWarning("Branch with id {Id} not found", id);
            throw new KeyNotFoundException($"Branch with id {id} not found");
        }
        
        var branchToDelete = _mapper.Map<Branch>(branch);
        
        _unitOfWork.BranchRepository.Delete(branchToDelete);
        _unitOfWork.CompleteAsync();
        return Task.FromResult(true);
    }
}