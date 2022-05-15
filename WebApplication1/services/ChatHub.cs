using InfraMenriChat.Entity;
using InfraMenriChat.Entity.Common;
using InfraMenriChat.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebApplication1.services
{
    public class ChatHub : Hub
    {
        private readonly IMessageChatRepository _messageChatRepository;
        private readonly IMessageChatUserRepository _messageChatUserRepository;
        private readonly IConversaRepository _conversaRepository;

        public ChatHub(IMessageChatRepository messageChatRepository, IMessageChatUserRepository messageChatUserRepository, IConversaRepository conversaRepository)
        {
            _messageChatRepository = messageChatRepository;
            _messageChatUserRepository = messageChatUserRepository;
            _conversaRepository = conversaRepository;

        }

        public async Task senMensagem(Guid UsuarioLogado, Guid Usuairofinal, string teste)
        {
            try
            {
                var conversa = _conversaRepository.VerificarConversa(Usuairofinal, UsuarioLogado);
                if (conversa != null)
                {
                    var menssagem = new MessageChat
                    {
                        Message = teste,
                    };
                    _messageChatRepository.InsertOrReplace(menssagem);

                    var messagemUser = new MessageChatUser
                    {
                        UsuarioEnvioId = UsuarioLogado,
                        DtAlteracao = DateTime.Now,
                        DtInclusao = DateTime.Now,
                        ConversaId = conversa.Id,
                        MensagemId = menssagem.Id
                    };
                    _messageChatUserRepository.InsertOrReplace(messagemUser);
                    var MenssagemUserRetorno = _messageChatUserRepository.GetByIdWithUsuarioEnviado(messagemUser.Id);
                    await Clients.All.SendAsync(conversa.Id.ToString(), MenssagemUserRetorno);


                }
                else
                {
                    var newconversa = new Conversa
                    {
                        UsuarioPrimarioId = UsuarioLogado,
                        UsuarioSecundarioId = Usuairofinal,
                    };
                    _conversaRepository.InsertOrReplace(newconversa);
                    var menssagem = new MessageChat
                    {
                        Message = teste,
                    };
                    _messageChatRepository.InsertOrReplace(menssagem);


                    var menssagemUser = new MessageChatUser
                    {
                        UsuarioEnvioId = UsuarioLogado,
                        DtAlteracao = DateTime.Now,
                        DtInclusao = DateTime.Now,
                        ConversaId = newconversa.Id,
                        MensagemId = menssagem.Id
                    };
                    _messageChatUserRepository.InsertOrReplace(menssagemUser);
                    var MenssagemUserRetorno = _messageChatUserRepository.GetByIdWithUsuarioEnviado(menssagemUser.Id);
                    await Clients.All.SendAsync(Usuairofinal.ToString() + UsuarioLogado.ToString(), MenssagemUserRetorno);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task EscrevendoWith(bool teste)
        {
            if (teste)
                await Clients.All.SendAsync("escrevendo", teste);
        }
        public async Task GetNotiCon(Guid conversaId,Guid UsuarioLogado)
        {
            try
            {
                var conversaMenssagemCount = _messageChatUserRepository.GetCountMenssagemNaolidaByConversa(conversaId, UsuarioLogado);
                await Clients.All.SendAsync("info-count" + conversaId.ToString(), conversaMenssagemCount);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
