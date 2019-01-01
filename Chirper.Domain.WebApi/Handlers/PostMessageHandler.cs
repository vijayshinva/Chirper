using Akka.Actor;
using Akka.Configuration;
using Chirper.Domain.Actors;
using Chirper.Domain.Commands;
using Chirper.Domain.Responses;
using Chirper.Domain.WebApi.Cluster;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Chirper.Domain.WebApi.Handlers
{
    public class PostMessageHandler : INotificationHandler<PostMessage>
    {
        private readonly ActorSystemWrapper _actorSystemWrapper;
        public PostMessageHandler(IActorSystemWrapper actorSystemWrapper)
        {
            _actorSystemWrapper = (ActorSystemWrapper)actorSystemWrapper;
        }
        public Task<PostMessageResponse> Handle(PostMessage postMessage, CancellationToken cancellationToken)
        {
            IActorRef chirpUserActor = _actorSystemWrapper.ActorSystem.ActorOf(Props.Create(() => new ChirpUser(postMessage.ChirpUserId)));
            return Task.Run(async () =>
            {
                object result = await chirpUserActor.Ask(postMessage, cancellationToken);
                return (PostMessageResponse)result;
            });
        }

        Task INotificationHandler<PostMessage>.Handle(PostMessage notification, CancellationToken cancellationToken)
        {
            return _actorSystemWrapper.TellChirpUser(notification.ChirpUserId, notification);
        }
    }
}
