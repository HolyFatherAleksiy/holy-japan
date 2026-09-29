using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRepository.Context
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Language> Languages {get;set; } = null!;
        public DbSet<UserData> UserDatas {get;set; } = null!;

        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options)
            : base(options)
        {
        }
    }
}