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
                return _Context.MenssageChatUsers.AsNoTracking().ToList().Select(d => d.MessageChat);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MessageChat> GetAllMenssagemUsuarioLogadoAndUsuarioChat(Guid usuariologadoid, Guid usuarioId)
        {
            try
            {
                return _DbSet.Select(d => d.MessageChat);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public MessageChatUser GetByIdWithUsuarioEnviado(Guid id)
        {
            try
            {
                return _DbSet.AsNoTracking().Include(d => d.UsuarioEnvio).Include(d => d.MessageChat).FirstOrDefault(d => d.Ativo && d.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<MessageChatUser> GetByusuarioOnlineByChatId(Guid conversaid)
        {
            try
            {
                return _DbSet.AsNoTracking().Include(d => d.UsuarioEnvio).Include(d => d.MessageChat).Where(d => d.Ativo && d.ConversaId == conversaid)
                    .OrderBy(d => d.MessageChat.DtInclusao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetCountMenssagemNaolidaByConversa(Guid conversaId, Guid UsuarioLogadoId)
        {
            try
            {
                return _DbSet.AsNoTracking().Where(d => d.Ativo && d.ConversaId == conversaId && d.UsuarioEnvioId != UsuarioLogadoId).Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
