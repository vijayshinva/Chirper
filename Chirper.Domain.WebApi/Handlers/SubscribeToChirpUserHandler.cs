using Akka.Actor;
using Chirper.Domain.Actors;
using Chirper.Domain.Commands;
using Chirper.Domain.Responses;
using Chirper.Domain.WebApi.Cluster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chirper.Domain.WebApi.Handlers
{
    internal class SubscribeToChirpUserHandler : INotificationHandler<SubscribeToChirpUser>
    {
        private readonly ActorSystemWrapper _actorSystemWrapper;
        public SubscribeToChirpUserHandler(IActorSystemWrapper actorSystemWrapper)
        {
            _actorSystemWrapper = (ActorSystemWrapper)actorSystemWrapper;
        }

        Task INotificationHandler<SubscribeToChirpUser>.Handle(SubscribeToChirpUser notification, CancellationToken cancellationToken)
        {
            return _actorSystemWrapper.TellChirpUser(notification.ChirpUserId, notification);
        }
    }
}
