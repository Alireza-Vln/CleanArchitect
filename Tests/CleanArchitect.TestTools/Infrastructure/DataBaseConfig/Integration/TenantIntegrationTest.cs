using CleanArchitect.Persistence.EF;
using CleanArchitect.TestTools.Infrastructure.DataBaseConfig.Integration.Fixtures;

namespace CleanArchitect.TestTools.Infrastructure.DataBaseConfig.Integration;

public class TenantIntegrationTest : EFDataContextDatabaseFixture
{
    protected EFDataContext FirstContext { get; }
    protected EFDataContext SecondContext { get; }

    protected TenantIntegrationTest(
        string firstTenantId,
        string secondTenantId)
    {
        FirstContext = CreateDataContext(firstTenantId);
        SecondContext = CreateDataContext(secondTenantId);
    }

    protected void SaveFirstContext<T>(T entity)
        where T : class
    {
        FirstContext.Manipulate(_ => _.Add(entity));
    }

    protected void SaveSecondContext<T>(T entity)
        where T : class
    {
        SecondContext.Manipulate(_ => _.Add(entity));
    }
}