using Bank.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Bank.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server=(localdb)\\MSSQLLocalDB; Database=Bank.DataBas;Trusted_Connection = true;";
            optionsBuilder.UseSqlServer(path);
        }

        DbSet<User> Users { get; set; }
    }
}
