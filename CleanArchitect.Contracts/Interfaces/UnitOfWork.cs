namespace CleanArchitect.Services.UnitOfWorks;

public interface UnitOfWork
{
    Task Complete();
     void Save();
    Task Begin();
    Task Rollback();
    Task Commit();
}