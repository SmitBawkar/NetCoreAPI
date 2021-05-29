using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.EF.Configuration
{
    class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project { ProjectId = 1, Title = "Project1", Description = "Demo Project 1" },
                new Project { ProjectId = 2, Title = "Project2", Description = "Demo Project 2" });
        }
    }
}
