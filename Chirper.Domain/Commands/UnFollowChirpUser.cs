using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain.Commands
{
    public sealed class UnFollowChirpUser : INotification
    {
        public UnFollowChirpUser(long requestId, string chirpUserId)
        {
            RequestId = requestId;
            ChirpUserId = chirpUserId;
        }

        public long RequestId { get; }
        public string ChirpUserId { get; }
    }
}
