using AutoMapper;
using Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;        
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<IdentityUser> userManager,  IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;            
            _mapper = mapper;
            _authManager = authManager ;
    }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user,user.PasswordHash);

            if (!result.Succeeded)
                return BadRequest();
            await _userManager.AddToRolesAsync(user, userDto.Roles);
            return Accepted(userDto);
        }


        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userManager.Users.ToListAsync());
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {            
            if (!await _authManager.ValidateUser(loginDto))
                return Unauthorized();
            else
                return Accepted( new { token = await _authManager.CreateToken() });                      
        }
    }
}
