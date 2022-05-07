using AutoMapper;
using InfraMenriChat.Entity;
using InfraMenriChat.Repository;
using InfraMenriChat.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace Teste
{
    public class UnitTest1
    {
        private TokenRepository _tokenRepository;
        public UnitTest1()
        {
            _tokenRepository = new TokenRepository(new Mock<IConfiguration>().Object,new Mock<IMapper>().Object,new Mock<UserManager<User>>().Object);
        }
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public async void Teste()
        {
            var teste = new UserViewModel()
            {
                Username = "Admin",
                Password = "Admin11@"
            };
           await _tokenRepository.GenerateToken(teste);
            Assert.True(true);
        }
    }
}
