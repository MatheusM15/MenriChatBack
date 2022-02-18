using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Interface.common
{
    public interface IBaseEntityRespository<Tentity>
    {
        IEnumerable<Tentity> GetAll();
        Tentity GetById(Guid Id);
        bool InsertOrReplace(Tentity entity);
        bool Delete(Guid Id);

    }
}
