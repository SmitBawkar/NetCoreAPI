using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Project
    {
        public int? ProjectId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}