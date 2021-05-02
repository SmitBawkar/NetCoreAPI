using DemoWebApi.ModelValidations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{    
    public class Ticket
    {                
        public int? TicketId { get; set; }
        
        [Required]
        public int? ProjectId { get; set; }

        [Required]        
        public string Title { get; set; }

        public string Description { get; set; }

        [MaxLength(10)]
        public string Owner { get; set; }

        [EnsureTicketDueDate]
        public DateTime? DueDate { get; set; }

        public DateTime? EnterDate { get; set; }

    }
}
