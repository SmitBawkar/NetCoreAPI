using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string UserName { get { return Email; } }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
