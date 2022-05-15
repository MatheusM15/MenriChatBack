using InfraMenriChat.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("Conversa")]
    public class ConversaController : Controller
    {

        private readonly IConversaRepository _conversaRepository;
        public ConversaController(IConversaRepository conversaRepository)
        {
            _conversaRepository = conversaRepository;
        }
        
        [HttpGet("GetAllConversaoByUsuairo/{UsuarioId}")]
        public IActionResult GetAllConversaoByUsuairo(Guid UsuarioId)
        {
            try
            {
                return Ok(_conversaRepository.GetAllConversaoByUsuairo(UsuarioId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
