using Chirper.Domain;
using Chirper.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Chirper.WebApi.Wall
{
    public class WallObserver : IWallObserver
    {
        private IClientProxy user;
        public WallObserver(IClientProxy user)
        {
            this.user = user;
        }

        public async void WallUpdate(Message message)
        {
            await user.SendAsync("WallUpdate", message.ChirpUserId.ToString("N"), message.Text);
        }
    }
}
