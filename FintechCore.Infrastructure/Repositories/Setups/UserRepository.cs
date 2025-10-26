using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories.Setups;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(FintechCoreContext context, ILogger<GenericRepository<User>> logger) : base(context, logger)
    {
    }
}