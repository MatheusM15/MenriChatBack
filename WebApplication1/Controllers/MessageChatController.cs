using InfraMenriChat.Entity;
using InfraMenriChat.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.services;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("MessageChat")]
    public class MessageChatController : Controller
    {
        private readonly IMessageChatRepository _messageChatRepository;
        private readonly ChatHub _chatHub;
        public MessageChatController(IMessageChatRepository messageChatRepository, ChatHub chatHub)
        {
            _messageChatRepository = messageChatRepository;
            _chatHub = chatHub;
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetAll()
        {
            try
            {
                var menssagem = _messageChatRepository.GetAll();
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
                return Ok(_messageChatRepository.GetById(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Post(MessageChat messageChat)
        {
            try
            {
                _messageChatRepository.InsertOrReplace(messageChat);
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
                return Ok(_messageChatRepository.Delete(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
