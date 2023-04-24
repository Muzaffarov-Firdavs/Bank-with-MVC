using Bank.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Bank.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server=(localdb)\\mssqllocaldb;Database=Bank;Trusted_Connection=True;";
        }

        DbSet<User> Users { get; set; }

    }
}
