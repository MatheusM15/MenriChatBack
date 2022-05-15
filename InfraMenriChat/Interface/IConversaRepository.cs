using InfraMenriChat.Entity.Common;
using InfraMenriChat.Interface.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Interface
{
    public interface IConversaRepository : IBaseEntityRespository<Conversa>
    {
        IEnumerable<Conversa> GetAllConversaoByUsuairo(Guid Usuario);

        Conversa VerificarConversa(Guid UsuairoPrimarioId, Guid UsuarioSecundarioId);
    }
}
