using Microsoft.EntityFrameworkCore;

namespace CleanArchitect.Persistence.EF;

public class EFDataContext : DbContext
{

    public EFDataContext(
        string connectionString)
        : this(
            new DbContextOptionsBuilder<EFDataContext>()
                .UseSqlServer(connectionString).Options)
    {
    }

    public EFDataContext(
        DbContextOptions<EFDataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext)
            .Assembly);
    }
}