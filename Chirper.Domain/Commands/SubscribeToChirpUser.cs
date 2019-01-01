using Chirper.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain.Commands
{
    public sealed class SubscribeToChirpUser : INotification
    {
        public long RequestId { get; }
        public string ChirpUserId { get; }
        public SubscribeToChirpUser(long requestId, string chirpUserId)
        {
            RequestId = requestId;
            ChirpUserId = chirpUserId;
        }
    }
}
