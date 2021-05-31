using Core.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Authentication
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private IdentityUser user; 
        public AuthManager(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
    }

        public async Task<string> CreateToken()
        {
            var signInCred = GetSignInCredentials();
            var claims = await GetClaims();
            var token = GenerateToken(signInCred, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateToken(SigningCredentials signInCred, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["Lifetime"]));
            var token = new JwtSecurityToken(
                issuer : jwtSettings["Issuer"],
                audience: jwtSettings["Issuer"],
                claims : claims,
                expires: expiration,
                signingCredentials: signInCred
                );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSignInCredentials()
        {
            //var key = Environment.GetEnvironmentVariable("KEY");
            var key = _configuration.GetSection("Jwt")["KEY"];
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginDto loginDto)
        {
            user = await _userManager.FindByNameAsync(loginDto.UserName);

            return user != null && await _userManager.CheckPasswordAsync(user, loginDto.PasswordHash);
        }
    }
}
