using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Authentication
{
    public interface IAuthManager
    {
        Task<string> CreateToken();
        Task<bool> ValidateUser(LoginDto loginDto);
    }
}
