using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageViewModel = PTSchool.Web.Models.Chat.MessageViewModel;

namespace PTSchool.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new MessageViewModel { User = this.Context.User.Identity.Name.Split("@").ToList().First().ToString(), Text = message, });
        }
    }
}
