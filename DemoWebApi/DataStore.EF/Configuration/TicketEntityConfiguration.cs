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
    class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasData(
                   new Ticket { TicketId = 1, Title = "Bug #1", ProjectId = 1 },
                   new Ticket { TicketId = 2, Title = "Bug #2", ProjectId = 1 },
                   new Ticket { TicketId = 3, Title = "Bug #2", ProjectId = 2 }
                   );
        }
    }
}
