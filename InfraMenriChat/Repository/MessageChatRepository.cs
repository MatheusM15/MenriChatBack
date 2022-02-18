using InfraMenriChat.Context;
using InfraMenriChat.Entity;
using InfraMenriChat.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMenriChat.Repository
{
    public class MessageChatRepository : BaseEntityRespository<MessageChat>, IMessageChatRepository
    {
        public MessageChatRepository(MenriChatContext context) : base(context){}
    }
}
