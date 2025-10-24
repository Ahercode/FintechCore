using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories.Setups;

public class FieldRepository : GenericRepository<Field>, IFieldRepository
{
    public FieldRepository(FintechCoreContext context, ILogger<GenericRepository<Field>> logger) : base(context, logger)
    {
    }
}