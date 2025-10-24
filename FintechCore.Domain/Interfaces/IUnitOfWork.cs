using FintechCore.Domain.Interfaces.Setups;

namespace FintechCore.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBranchRepository BranchRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IFieldRepository FieldRepository { get; }
    IFormRepository FormRepository { get; }
    ILovRepository LovRepository { get; }
    
    Task<bool> CompleteAsync();
}