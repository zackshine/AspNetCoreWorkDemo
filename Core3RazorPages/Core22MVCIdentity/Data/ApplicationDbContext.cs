using System;
using System.Collections.Generic;
using System.Text;
using Core22MVCIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core22MVCIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<PanelFrames> PaneFrames { get; set; }
        public DbSet<Panels> Panels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SpecialCard>().HasBaseType<Card>();

        }

    }


}
