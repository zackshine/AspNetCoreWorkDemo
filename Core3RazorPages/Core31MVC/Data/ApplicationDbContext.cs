using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Core31MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core31MVC.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<ParentCategory> ParentCategories { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieVersion> MovieVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new MovieConfiguration());
            //modelBuilder.ApplyConfiguration(new MovieVersionConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Movie>()
            //           .HasKey(m => m.Id);

            //modelBuilder.Entity<Movie>()
            //           .HasMany(b => b.MovieVersions)
            //           .WithOne();
            //modelBuilder.Entity<Movie>().Property(m => m.Id).ValueGeneratedOnAdd();

            //modelBuilder.Entity<MovieVersion>()
            //          .HasKey(m => m.Id);

            //modelBuilder.Entity<MovieVersion>().Property(m => m.Id).ValueGeneratedOnAdd();

        }
    }

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.HasMany(m => m.MovieVersions)
                .WithOne();
           
        }
    }

    public class MovieVersionConfiguration : IEntityTypeConfiguration<MovieVersion>
    {
        public void Configure(EntityTypeBuilder<MovieVersion> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();
        }
    }
}
