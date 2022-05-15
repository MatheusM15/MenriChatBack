using InfraMenriChat.Context;
using InfraMenriChat.Entity.Common;
using InfraMenriChat.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Repository
{
    public class ConversaRepository : BaseEntityRespository<Conversa>, IConversaRepository
    {
        public ConversaRepository(MenriChatContext context )  : base(context){}

        public IEnumerable<Conversa> GetAllConversaoByUsuairo(Guid Usuario)
        {
            try
            {
                return _DbSet.AsNoTracking().Include(d => d.UsuarioPrimario).Include(d => d.UsuarioSecundario)
                    .Where(d => d.Ativo && (d.UsuarioPrimarioId == Usuario || d.UsuarioSecundarioId == Usuario));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Conversa VerificarConversa(Guid UsuairoPrimarioId, Guid UsuarioSecundarioId)
        {
            try
            {
                var convesa = _DbSet.AsNoTracking().FirstOrDefault(d => d.Ativo && 
                (d.UsuarioPrimarioId == UsuairoPrimarioId || d.UsuarioPrimarioId == UsuarioSecundarioId) &&
                (d.UsuarioSecundarioId == UsuairoPrimarioId || d.UsuarioSecundarioId == UsuarioSecundarioId));

                if (convesa != null) return convesa;
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
