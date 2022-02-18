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
        //[ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        [ForeignKey("MessageChat")]
        public Guid MensagemId { get; set; }



        //FK
        //public virtual User Usuario { get; set; }
        public virtual MessageChat Mensagem { get; set; }
    }
}
