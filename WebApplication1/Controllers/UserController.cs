using InfraMenriChat.Context;
using InfraMenriChat.Entity;
using InfraMenriChat.Interface;
using InfraMenriChat.Interface.Common;
using InfraMenriChat.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Route("User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;


        public UserController(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;

        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }
        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            var teste = await _userRepository.Register(user);
            return Ok(teste);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                var statusLogin = await _userRepository.Login(user);
                if (statusLogin.Succeeded)
                {
                    user.Token = await _tokenRepository.GenerateToken(user);
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
