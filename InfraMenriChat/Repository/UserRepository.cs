using AutoMapper;
using InfraMenriChat.Context;
using InfraMenriChat.Entity;
using InfraMenriChat.Interface;
using InfraMenriChat.Interface.Common;
using InfraMenriChat.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly MenriChatContext _context;
        private readonly ITokenRepository _tokenRepository;
        private SignInManager<User> _signInManager;
        public UserRepository(UserManager<User> userManager, IMapper mapper, MenriChatContext context, 
            SignInManager<User> signInManager,ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
            _context = context;
            _signInManager = signInManager;
        }

        public IEnumerable<User> GetAll()
        {

            return _context.Users.AsEnumerable();
            //return _dbSet.ToList();
        }

        public User GetByName(string name)
        {
            try
            {
                return _userManager.Users.FirstOrDefault(users => users.UserName.ToUpper() == name.ToUpper());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<SignInResult> Login(UserViewModel userViewModel)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(users => users.UserName.ToUpper() == userViewModel.Username.ToUpper());
                return await _signInManager.CheckPasswordSignInAsync(user, userViewModel.Password,false);
                

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Object> Register (UserViewModel userviewmodel)
        {
            try
            {
                var user = _mapper.Map<User>(userviewmodel);
                user.EmailConfirmed = true;
                return await _userManager.CreateAsync(user, userviewmodel.Password);
                //return _mapper.Map<UserViewModel>(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
