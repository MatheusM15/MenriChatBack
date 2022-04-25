using InfraMenriChat.Context;
using InfraMenriChat.Entity;
using InfraMenriChat.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Repository
{
    public class MessageChatUserRepository : BaseEntityRespository<MessageChatUser>, IMessageChatUserRepository
    {
        public MessageChatUserRepository(MenriChatContext context) : base(context) { }

        public IEnumerable<MessageChat> GetAllByusuario(Guid UsuarioId)
        {
            try
            {
                return _Context.MenssageChatUsers.AsNoTracking().Include(d => d.Mensagem).Where(d => d.UsuarioId == UsuarioId).ToList().Select(d => d.Mensagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    }
