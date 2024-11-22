﻿using Microsoft.EntityFrameworkCore;

namespace CleanArchitect.Persistence.Ef;

public class EfDataContext : DbContext
{
    public EfDataContext(
        string connectionString)
        : this(
            new DbContextOptionsBuilder<EfDataContext>()
                .UseSqlServer(connectionString).Options)
    {
    }

    public EfDataContext(
        DbContextOptions<EfDataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }
}