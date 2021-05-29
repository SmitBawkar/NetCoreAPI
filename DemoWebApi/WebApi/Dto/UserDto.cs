using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto;

namespace WebApi.DTO
{
        public class UserDto: LoginDto
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public  string PhoneNumber { get; set; }                        
    }
}
