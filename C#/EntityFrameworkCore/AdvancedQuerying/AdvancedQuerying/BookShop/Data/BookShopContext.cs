using BookShop.Data.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext( DbContextOptions options) : base(options)
        {
        }

        public BookShopContext()
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.AuthorId);

                entity.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

                entity.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);

                entity.Property(x => x.Title)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

                entity.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsUnicode()
                .IsRequired();

                entity.HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(a => a.AuthorId);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.CategoryId);

                entity.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode();
            });
            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.BookId);

                entity.HasOne(b => b.Category)
                .WithMany(bc => bc.CategoryBooks)
                .HasForeignKey(b => b.BookId);

                entity.HasKey(x => new{ x.BookId,x.CategoryId});
            });
        }
    }
}
