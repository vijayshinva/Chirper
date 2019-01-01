using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain.Responses
{
    public sealed class PostMessageResponse
    {
        public long RequestId { get; }
        public bool Success { get; }
        public PostMessageResponse(long requestId, bool success)
        {
            RequestId = requestId;
            Success = success;
        }
    }
}
