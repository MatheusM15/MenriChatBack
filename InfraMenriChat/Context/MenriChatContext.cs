using InfraMenriChat.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Context
{
    public class MenriChatContext : IdentityDbContext<User,Roles,Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public MenriChatContext(DbContextOptions<MenriChatContext> options) : base(options)
        {

        }
        public DbSet<MessageChat> MessageChats { get; set; }
        public DbSet<MessageChatUser> MenssageChatUsers { get; set; }
    }
}
