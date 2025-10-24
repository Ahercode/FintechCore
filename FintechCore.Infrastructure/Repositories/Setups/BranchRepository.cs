using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories.Setups;

public class BranchRepository: GenericRepository<Branch>, IBranchRepository
{
    public BranchRepository(FintechCoreContext context, ILogger<GenericRepository<Branch>> logger) : base(context, logger)
    {
    }
}