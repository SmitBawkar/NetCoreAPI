using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.ModelValidations
{
    public class EnsureTicketDueDateAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket !=null && ticket.EnsureTicketDueDateWhenOwnerIsNotNull())
                return ValidationResult.Success;            
            else
                return new ValidationResult("Due date should not be null if ticket has owner");
        }
    }
}
