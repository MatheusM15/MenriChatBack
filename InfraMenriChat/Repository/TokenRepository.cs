using AutoMapper;
using InfraMenriChat.Entity;
using InfraMenriChat.Interface.Common;
using InfraMenriChat.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public TokenRepository(IConfiguration configuration,IMapper mapper,UserManager<User> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["tokenKey"]));
        }
        public async Task<string> GenerateToken(UserViewModel userViewModel)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(u => u.UserName.ToUpper() == userViewModel.Username.ToUpper());
                var Roles = await _userManager.GetRolesAsync(user);
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userViewModel.Username),
                    new Claim(ClaimTypes.Role,String.Join(",",Roles))
                };

                var credatial = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
                var tokenDecription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claim),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credatial
                };
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDecription);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
