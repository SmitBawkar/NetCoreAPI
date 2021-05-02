using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.ModelValidations
{
    public class EnsureTicketDueDateAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket?.Owner != null && !String.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (!ticket.DueDate.HasValue)
                    return new ValidationResult("Due date should not be null if ticket has owner");
            }

            return ValidationResult.Success;
        }
    }
}
