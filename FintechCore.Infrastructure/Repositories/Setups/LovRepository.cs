using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories.Setups;

public class LovRepository : GenericRepository<Lov>, ILovRepository
{
    public LovRepository(FintechCoreContext context, ILogger<GenericRepository<Lov>> logger) : base(context, logger)
    {
    }
}