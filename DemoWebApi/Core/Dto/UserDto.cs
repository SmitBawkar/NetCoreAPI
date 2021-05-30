using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Core.Dto
{
        public class UserDto: LoginDto
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public  string PhoneNumber { get; set; }

        [Required]       
        public ICollection<string> Roles { get; set; }
    }
}
