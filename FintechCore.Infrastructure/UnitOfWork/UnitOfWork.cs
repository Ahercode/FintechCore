using FintechCore.Domain.Entities.Setups;
using FintechCore.Domain.Interfaces;
using FintechCore.Domain.Interfaces.Setups;
using FintechCore.Infrastructure.DBContext;
using FintechCore.Infrastructure.Repositories;
using FintechCore.Infrastructure.Repositories.Setups;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly FintechCoreContext _context;
    private readonly IConfiguration _config;
    private readonly ILogger _logger;

    public UnitOfWork(FintechCoreContext context, ILoggerFactory loggerFactory, IConfiguration config)
    {
        _context = context;
        _config = config;
        _logger = loggerFactory.CreateLogger("logs");
            
        BranchRepository = new BranchRepository(_context, loggerFactory.CreateLogger<GenericRepository<Branch>>());
        CategoryRepository = new CategoryRepository(_context, loggerFactory.CreateLogger<GenericRepository<Category>>());
        FieldRepository = new FieldRepository(_context, loggerFactory.CreateLogger<GenericRepository<Field>>());
        FormRepository = new FormRepository(_context, loggerFactory.CreateLogger<GenericRepository<Form>>());
        LovRepository = new LovRepository(_context, loggerFactory.CreateLogger<GenericRepository<Lov>>());
    }

    public IBranchRepository BranchRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IFieldRepository FieldRepository { get; }
    public IFormRepository FormRepository { get; }
    public ILovRepository LovRepository { get; }
        
    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        _logger.LogInformation("Saved successfully with {Count} changes", result);
        return result > 0;
    }
        
    public void Dispose()
    {
        _context.Dispose();
    }
}