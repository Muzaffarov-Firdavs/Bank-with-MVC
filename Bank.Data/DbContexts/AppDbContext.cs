using Bank.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Bank.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }


        DbSet<User> Users { get; set; }
    }
}
