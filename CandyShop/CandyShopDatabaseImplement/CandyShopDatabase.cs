using CandyShopDatabaseImplement.models;
using CandyShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CandyShopDatabaseImplement
{
    public class CandyShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CandyShopDatabaselab5;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Sweet> Sweets { set; get; }
        public virtual DbSet<Pastry> Pastrys { set; get; }
        public virtual DbSet<PastrySweet> PastrySweets { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
    }
}
