using InfraMenriChat.Entity;
using InfraMenriChat.Interface.common;
using InfraMenriChat.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Interface
{
    public interface IUserRepository
    {
        Task<UserViewModel> Register(UserViewModel userviewmodel);
       
        IEnumerable<User> GetAll();
        Task<SignInResult> Login(UserViewModel userViewModel);
    }
}
