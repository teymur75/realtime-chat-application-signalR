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
    }
}
