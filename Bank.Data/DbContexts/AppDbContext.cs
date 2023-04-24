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
        }

        DbSet<User> Users { get; set; }
    }
}
