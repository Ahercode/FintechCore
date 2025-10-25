using FintechCore.Domain.Entities.Setups;
using Microsoft.EntityFrameworkCore;

namespace FintechCore.Infrastructure.DBContext;

public partial class FintechCoreContext : DbContext
{
    public  FintechCoreContext()
    {}
    
    public FintechCoreContext(DbContextOptions<FintechCoreContext> options) : base(options)
    {
        
    }
    
    public virtual DbSet<Branch> Branches { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Form> Forms { get; set; }
    public virtual DbSet<Field> Fields { get; set; }
    public virtual DbSet<Lov> Lovs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I am using database first approach so I don't need all the columns like we do when we need to run a migration
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.ToTable("Branch");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
            entity.HasKey(e => e.CatId);
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.ToTable("Form");
            entity.HasKey(e => e.FormId);
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.ToTable("Field");
            entity.HasKey(e => e.FieldId);
        });

        modelBuilder.Entity<Lov>(entity =>
        {
            entity.ToTable("Lov");
            entity.HasKey(e => e.LovId);
        });
        
    }
    
}