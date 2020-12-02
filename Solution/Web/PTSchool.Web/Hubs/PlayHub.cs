using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PTSchool.Web.Models.Chat;
using System.Threading.Tasks;

namespace PTSchool.Web.Hubs
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
                await this.Clients.Group(gameId).SendAsync("JoinedMessageJS", new MessageViewModel { User = nameUser, Text = joinedMessage });
            }
        }

        public async Task PlayMoveCSharp(string imgNumber, string letterOfPlayer, string gameId)
        {
            await this.Clients.Group(gameId).SendAsync("MovePlayedJS", new MessageViewModel { User = imgNumber, Text = letterOfPlayer });
        }

        public async Task RestartGameCSharp(string gameId)
        {
            await this.Clients.Group(gameId).SendAsync("GameRestartedJS");
        }

        public async Task SendMessageCSharp(string message, string gameId)
        {
            await this.Clients.Group(gameId).SendAsync("ReceiveMessageJS", new MessageViewModel { User = this.Context.User.Identity.Name, Text = message });
        }
    }
}
