using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories.Setups;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(FintechCoreContext context, ILogger<GenericRepository<Category>> logger) : base(context, logger)
    {
    }
}