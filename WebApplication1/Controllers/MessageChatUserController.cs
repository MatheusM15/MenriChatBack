using InfraMenriChat.Entity;
using InfraMenriChat.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("MessageChatUser")]
    public class MessageChatUserController : Controller
    {
        private readonly IMessageChatUserRepository _messageChatUserRepository;
        private readonly UserManager<User> _userManager;
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _configuration;
        public MessageChatUserController(IMessageChatUserRepository messageChatUserRepository, UserManager<User> userManager, IConfiguration configuration)
        {
            _messageChatUserRepository = messageChatUserRepository;
            _userManager = userManager;
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["tokenKey"]));
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            try
            {
                var menssagem = _messageChatUserRepository.GetAll();
                return Ok(menssagem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                return Ok(_messageChatUserRepository.GetById(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost()]
        public IActionResult Post(MessageChatUser messageChat)
        {
            try
            {
                _messageChatUserRepository.InsertOrReplace(messageChat);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                return Ok(_messageChatUserRepository.Delete(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
