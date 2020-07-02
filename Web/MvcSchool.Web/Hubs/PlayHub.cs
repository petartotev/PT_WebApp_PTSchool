using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MvcSchool.Web.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Hubs
{
    [Authorize]
    public class PlayHub : Hub
    {
        public async Task JoinGroupCSharp(string gameId, string nameUser, string gameHost)
        {
            string joinedMessage = "joined the game!";
            await Groups.AddToGroupAsync(this.Context.ConnectionId, gameId);
            if (gameHost != nameUser)
            {
                await this.Clients.Group(gameId).SendAsync("JoinedMessageJS", new Message { User = nameUser, Text = joinedMessage });
            }
        }

        public async Task PlayMoveCSharp(string imgNumber, string letterOfPlayer, string gameId)
        {
            await this.Clients.Group(gameId).SendAsync("MovePlayedJS", new Message { User = imgNumber, Text = letterOfPlayer });
        }

        public async Task RestartGameCSharp(string gameId)
        {
            await this.Clients.Group(gameId).SendAsync("GameRestartedJS");
        }

        public async Task SendMessageCSharp(string message, string gameId)
        {
            await this.Clients.Group(gameId).SendAsync("ReceiveMessageJS", new Message { User = this.Context.User.Identity.Name, Text = message });
        }
    }
}
