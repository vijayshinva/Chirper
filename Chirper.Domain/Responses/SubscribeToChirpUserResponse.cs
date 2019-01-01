using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain.Responses
{
    public sealed class SubscribeToChirpUserResponse
    {
        public long RequestId { get; }
        public bool Success { get; }
        public SubscribeToChirpUserResponse(long requestId, bool success)
        {
            RequestId = requestId;
            Success = success;
        }
    }
}
