using CleanArchitect.Persistence.Ef;
using Xunit;

namespace CleanArchitect.TestTools.Infrastructure.DataBaseConfig.Integration.
    Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    public static EfDataContext CreateDataContext(string tenantId)
    {
        var connectionString =
            new ConfigurationFixture().Value.ConnectionString;
        

        return new EfDataContext(
            $"server=.;database=DataBaseName;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;");
    }
}