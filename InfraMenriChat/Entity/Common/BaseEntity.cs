using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime DtAlteracao { get; set; }
        public DateTime DtInclusao { get; set; }
        public bool Ativo { get; set; }
    }
}
