using Akka.Actor;
using Chirper.Domain.Actors;
using Chirper.Domain.WebApi.Cluster;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chirper.Domain.WebApi.Hubs
{
    public class ChirpHub : Hub
    {
        private ActorSystemWrapper _actorSystemWrapper;
        public ChirpHub(IActorSystemWrapper actorSystemWrapper)
        {
            _actorSystemWrapper = (ActorSystemWrapper)actorSystemWrapper;
        }
        public Task RegisterWebDevice(string chirpUserId)
        {
            var client = Clients.User(chirpUserId);
            return Task.FromResult(true);
        }
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
