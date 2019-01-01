using Akka.Cluster.Sharding;

namespace Chirper.Domain.WebApi.Cluster
{
    public class MessageExtractor : HashCodeMessageExtractor
    {
        public MessageExtractor() : base(13) { }
        public override string EntityId(object message)
        {
            return (message as ShardEnvelope)?.EntityId;
        }

        public override object EntityMessage(object message)
        {
            return (message as ShardEnvelope)?.Message;
        }
    }
}
