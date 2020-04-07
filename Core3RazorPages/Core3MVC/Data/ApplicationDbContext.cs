using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core3MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core3MVC.Data
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string,
            ApplicationUserClaim, IdentityUserRole<string>, IdentityUserLogin<string>,
            IdentityRoleClaim<string>, IdentityUserToken<string>>
    //public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string, ApplicationUserClaim<int>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TestUser> TestUsers { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }

        public DbSet<Api> Apis { get; set; }
        public DbSet<ApiApplicant> ApiApplicants { get; set; }

        public DbSet<Gate> Gates { get; set; }
        public DbSet<App> Apps { get; set; }

        public DbSet<Article> Articles { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Room> Room { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<ReservationGuestDetail> ReservationGuestDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApiApplicant>()
                .HasKey(t => new { t.ApiId, t.ApplicantId });

            modelBuilder.Entity<ApiApplicant>()
                 .HasOne(pt => pt.Api)
                 .WithMany(p => p.ApiApplicants)
                 .HasForeignKey(pt => pt.ApiId);

            modelBuilder.Entity<ApiApplicant>()
                .HasOne(pt => pt.Applicant)
                .WithMany(t => t.ApiApplicants)
                .HasForeignKey(pt => pt.ApplicantId);

            modelBuilder.Entity<Api>()
            .HasMany(i => i.ApiApplicants)
            .WithOne(c => c.Api)
            .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Grade>()
            //    .HasKey(t => new { t.StudentId, t.SubjectId });

            modelBuilder.Entity<Grade>()
                 .HasOne(pt => pt.Student)
                 .WithMany(p => p.Grades)
                 .HasForeignKey(pt => pt.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(pt => pt.Subject)
                .WithMany(t => t.Grades)
                .HasForeignKey(pt => pt.SubjectId);

            modelBuilder.Entity<TestUser>()
                .HasMany(i => i.Items)
                .WithOne(u => u.User);

            //modelBuilder.Entity<OrderDetail>().HasKey(detail => new { detail.OrderID, detail.OrderDetailID });
            //modelBuilder.Entity<OrderDetail>().HasOne(detail => detail.Order)
            //                                            .WithMany(order => order.Details)
            //                                            .HasForeignKey(detail => detail.OrderID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.ApplyConfiguration(new ArticleEntityTypeConfiguration());
        }

        public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
        {
            public void Configure(EntityTypeBuilder<Article> builder)
            {
                builder.ToTable("Articles");

                builder.HasKey(table => table.Id);
                builder.Property(table => table.Id).ValueGeneratedOnAdd();

                builder.HasOne(table => table.Previous).WithOne().HasForeignKey<Article>(table => table.PreviousId);
                builder.HasOne(table => table.Next).WithOne().HasForeignKey<Article>(table => table.NextId);
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {


            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Deleted)
                {
                    if (entry.Entity is Api )
                    {
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["isDeleted"] = true;
                        foreach (var c in entry.Collections)
                        {
                            if(c.Metadata.Name == "ApiApplicants")
                            {
                                foreach (var item in (IEnumerable)c.CurrentValue)
                                {
                                        ((ApiApplicant)item).isDeleted = true;
                                }
                            }
                            //foreach (var item in (IEnumerable)c.CurrentValue)
                            //{
                            //    if (item is ApiApplicant)
                            //    {
                            //        ((ApiApplicant)item).isDeleted = true;
                            //    }

                            //}
                        }

                    }
                }
            }
        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                                 || e.State == EntityState.Modified
                           select e.Entity;

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChanges();
        }
        public DbSet<Core3MVC.Models.Article> Article { get; set; }
    }
}

