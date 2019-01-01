using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Domain.WebApi.Cluster
{
    public class ShardEnvelope
    {
        public readonly string EntityId;
        public readonly object Message;

        public ShardEnvelope(string EntityId, object Message)
        {
            this.EntityId = EntityId;
            this.Message = Message;
        }
    }
}
