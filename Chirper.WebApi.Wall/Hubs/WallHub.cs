using Chirper.Domain;
using Chirper.Domain.Actors;
using Microsoft.AspNetCore.SignalR;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.WebApi.Wall.Hubs
{
    public class WallHub : Hub
    {
        public WallHub(IClusterClient client)
        {
            Client = client;
        }

        private IClusterClient Client { get; }
        public async Task RegisterForWallUpdate(string chirpUserId)
        {
            var chirpUser = Client.GetGrain<IChirpUser>(Guid.Parse(chirpUserId));
            var wallObserver = new WallObserver(Clients.Caller);
            var wallObserverReference = await Client.CreateObjectReference<IWallObserver>(wallObserver);
            await chirpUser.Subscribe(wallObserverReference);
        }
    }
}
