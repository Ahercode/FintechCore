using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories.Setups;

public class FormRepository : GenericRepository<Form>, IFormRepository
{
    public FormRepository(FintechCoreContext context, ILogger<GenericRepository<Form>> logger) : base(context, logger)
    {
    }
}