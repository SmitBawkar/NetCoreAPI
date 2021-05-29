using Core.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Data seeding
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Title = "Project1", Description ="Demo Project 1"},
                new Project { ProjectId = 2, Title = "Project2", Description = "Demo Project 2" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, Title = "Bug #1", ProjectId = 1 },
                new Ticket { TicketId = 2, Title = "Bug #2", ProjectId = 1 },
                new Ticket { TicketId = 3, Title = "Bug #2", ProjectId = 2 }
                );
        }
    }
}
