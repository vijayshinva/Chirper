using Chirper.Domain.Responses;
using MediatR;

namespace Chirper.Domain.Commands
{
    public sealed class PostMessage : INotification
    {
        public long RequestId { get; }
        public string ChirpUserId { get; }
        public string Message { get; }
        public PostMessage(long requestId, string chirpUserId, string message)
        {
            RequestId = requestId;
            ChirpUserId = chirpUserId;
            Message = message;
        }
    }
}
