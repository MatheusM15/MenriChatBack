using InfraMenriChat.Entity;
using InfraMenriChat.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebApplication1.services
{
    public class ChatHub : Hub
    {
        private int userOnline = 0;
        private readonly IMessageChatRepository _messageChatRepository;

        public ChatHub(IMessageChatRepository messageChatRepository)
        {
            _messageChatRepository = messageChatRepository;
        }

        public async Task senMensagem(string teste)
        {
            try
            {
                var menssagem = new MessageChat
                {
                    DtAlteracao = DateTime.Now,
                    DtInclusao = DateTime.Now,
                    Message = teste
                };
                if(_messageChatRepository.InsertOrReplace(menssagem))
                    await Clients.All.SendAsync("Menssagem", menssagem);



            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task EscrevendoWith(bool teste)
        {
            if(teste)
                await Clients.All.SendAsync("escrevendo", teste);
        }
    }
}
