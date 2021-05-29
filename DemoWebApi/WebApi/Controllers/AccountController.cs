using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;        
        private readonly IMapper _mapper;

        public AccountController(UserManager<IdentityUser> userManager,  IMapper mapper)
        {
            _userManager = userManager;            
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user,user.PasswordHash);

            if (!result.Succeeded)
                return BadRequest();
            
            return Accepted(userDto);
        }


        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            return Ok(await _userManager.Users.ToListAsync());
            
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.PasswordHash, false, false);

        //    if (!result.Succeeded)
        //        return Unauthorized(loginDto);

        //    return Accepted();

        //}
    }
}
