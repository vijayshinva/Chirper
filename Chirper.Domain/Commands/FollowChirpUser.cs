using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain.Commands
{
    public sealed class FollowChirpUser : INotification
    {
        public FollowChirpUser(long requestId, string chirpUserId)
        {
            RequestId = requestId;
            ChirpUserId = chirpUserId;
        }

        public long RequestId { get; }
        public string ChirpUserId { get; }
    }
}
