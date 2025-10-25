using FintechCore.Application.Dtos.Setups;

namespace FintechCore.Application.Services.Setups.branch;

public interface IBranchService
{
    Task<IEnumerable<BranchDto>> GetAllBranchesAsync();
    Task<BranchDto> GetBranchByIdAsync(int id);
    Task<BranchDto> CreateBranchAsync(CreateBranchDto dto);
    Task<BranchDto> UpdateBranchAsync(int id, UpdateBranchDto dto);
    Task<bool> DeleteBranchAsync(int id);
}