using Core.Models;
using DataStore.EF.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataStore.EF
{
    public class BugsContext : IdentityDbContext<IdentityUser>
    {
        public BugsContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new ProjectEntityConfiguration());
            builder.ApplyConfiguration(new TicketEntityConfiguration());

            //builder.Entity<IdentityUser>().HasData(
            //    new IdentityUser
            //    {
            //        UserName = "Admin",
            //        PasswordHash = "@Dm1n",
            //        Email="admin@Iamtheboss.com",
            //    });
        }
    }
}
