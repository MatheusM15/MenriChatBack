using InfraMenriChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Interface.Common
{
    public interface ITokenRepository
    {
        Task<string> GenerateToken(UserViewModel userViewModel);
    }
}
