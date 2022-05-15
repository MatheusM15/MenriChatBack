using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Entity.Common
{
    public class Conversa : BaseEntity
    {
        [ForeignKey("UsuarioPrimario")]
        public Guid UsuarioPrimarioId { get; set; }
        [ForeignKey("UsuarioSecundario")]
        public Guid UsuarioSecundarioId { get; set; }
       

        public virtual User UsuarioPrimario { get; set; }
        public virtual User UsuarioSecundario { get; set; }
    }
}
