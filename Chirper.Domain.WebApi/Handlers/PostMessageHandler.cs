using Chirper.Domain.Actors;
using Chirper.Domain.Commands;
using MediatR;
using Orleans;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chirper.Domain.WebApi.Handlers
{
    public class PostMessageHandler : INotificationHandler<PostMessage>
    {
        public async Task Handle(PostMessage notification, CancellationToken cancellationToken)
        {
            try
            {
                var client = new ClientBuilder().UseLocalhostClustering().Build();
                await client.Connect();
                var chirpUser = client.GetGrain<IChirpUser>(notification.ChirpUserId);
                await chirpUser.ChirpMessage(notification.Message);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
    }
}
