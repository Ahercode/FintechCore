using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories.Setups;

public class UserGroupRepository : GenericRepository<UserGroup>, IUserGroupRepository
{
    public UserGroupRepository(FintechCoreContext context, ILogger<GenericRepository<UserGroup>> logger) : base(context, logger)
    {
    }
}