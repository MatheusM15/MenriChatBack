using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebApplication1.services
{
    public class ChatHub : Hub
    {
        private int userOnline = 0;
        public async Task senMensagem(string teste)
        {
            try
            {
                if(!string.IsNullOrEmpty(teste))
                    await Clients.All.SendAsync("Menssagem",teste);

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
