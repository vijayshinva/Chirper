using Chirper.Domain.Entities;
using MediatR;
using System;

namespace Chirper.Domain.Commands
{
    public sealed class PostMessage : INotification
    {
        public PostMessage(long requestId, string chirpUserId, string message)
        {
            ChirpUserId = Guid.Parse(chirpUserId);
            Message = new Message
            {
                Id = Guid.NewGuid(),
                ChirpUserId = ChirpUserId,
                Text = message,
                Time = DateTime.UtcNow,
                Deleted = false
            };
            RequestId = requestId;
        }
        public Guid ChirpUserId { get; }
        public Message Message { get; }
        public long RequestId { get; }
    }
}
