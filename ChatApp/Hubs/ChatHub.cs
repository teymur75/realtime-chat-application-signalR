using ChatApp.Memory;
using ChatApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub:Hub
    {
        public async Task GetNickName(string nickName)
        {
            Client client = new()
            {
                ConnectionId=Context.ConnectionId,
                Nickname = nickName,
            };

            Data.Clients.Add(client);
            await Clients.Others.SendAsync("clientJoined", nickName);
            await Clients.All.SendAsync("allclients",Data.Clients);
        }

        public async Task SendMessageAsync(string message,string username)
        {
            if (username=="1")
            {
                await Clients.All.SendAsync("receiveMessage", message);
            }
            else
            {
                var existUser = Data.Clients.FirstOrDefault(c => c.Nickname == username);
                await Clients.Client(existUser.ConnectionId).SendAsync("receiveMessage", message,existUser);
            }
           
        }
    }
}
