using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{    
    public class Ticket
    {                
        public int TicketId { get; set; }

        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

    }
}
