
using CleanArchitect.Persistence.EF;
using Xunit;

namespace CleanArchitect.TestTools.Infrastructure.DataBaseConfig.Integration.Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    public IQueryable<T> X<T>(IQueryable<T> query) => query;

    protected EFDataContext CreateDataContext(string tenantId)
    {
        var connectionString = new ConfigurationFixture().Value.ConnectionString;


        return new EFDataContext(
            connectionString);
    }
}