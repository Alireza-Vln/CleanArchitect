using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace Contractors.TestTools.Infrastructure.DataBaseConfig.Unit;

public class EFInMemoryDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;

        public EFInMemoryDatabase()
        {
            _connection = new SqliteConnection("filename=:memory:");
            _connection.Open();
        }

        private ConstructorInfo? FindSuitableConstructor<TDbContext>() where TDbContext : DbContext
        {
            var flags = BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.InvokeMethod;

            var constructor =
                typeof(TDbContext).GetConstructor(
                    flags,
                    binder: null,
                    new[] {
                        typeof(DbContextOptions<TDbContext>)},
                    modifiers: null);

            if (constructor == null)
            {
                constructor = typeof(TDbContext).GetConstructor(
                    flags,
                    binder: null,
                    new[] { typeof(DbContextOptions)},
                    modifiers: null);
            }

            return constructor;
        }
        
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }

    public static class DbContextHelper
    {
        public static void Manipulate<TDbContext>(
            this TDbContext dbContext,
            Action<TDbContext> manipulate)
            where TDbContext : DbContext
        {
            manipulate(dbContext);
            dbContext.SaveChanges();
        }
    }