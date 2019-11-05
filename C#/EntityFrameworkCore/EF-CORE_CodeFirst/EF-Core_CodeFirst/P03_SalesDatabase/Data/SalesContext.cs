
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
    
{
    public class SalesContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseSettings.connectionString);
            }
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(p => p.CreditCardNumber)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Quantity)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("getdate()");


        }
    }
}
