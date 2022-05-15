using InfraMenriChat.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Entity
{
    public class MessageChatUser : BaseEntity
    {
        [ForeignKey("Conversa")]
        public Guid ConversaId { get; set; }
        [ForeignKey("MessageChat")]
        public Guid MensagemId { get; set; }

        [ForeignKey("UsuarioRemetende")]
        public Guid UsuarioEnvioId { get; set; }
        public bool Lida { get; set; }



        //FK
        public virtual Conversa Conversa { get; set; }
        public virtual User UsuarioEnvio { get; set; }
        public virtual MessageChat MessageChat { get; set; }
    }
}
