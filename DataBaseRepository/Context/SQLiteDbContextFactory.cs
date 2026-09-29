using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataBaseRepository.Context
{
    public class SQLiteDbContextFactory : IDesignTimeDbContextFactory<SQLiteDbContext>
    {
        public SQLiteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLiteDbContext>();
            
            // Укажи здесь путь для design-time. Можно тот же, что и в приложении,
            // или временный, главное — чтобы строка была валидной.
            optionsBuilder.UseSqlite("Data Source=app.db");

            return new SQLiteDbContext(optionsBuilder.Options);
        }
    }
}