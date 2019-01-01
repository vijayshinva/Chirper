using Akka.Actor;
using Akka.Cluster.Sharding;
using Akka.Configuration;
using Chirper.Domain.Actors;
using System.Threading.Tasks;

namespace Chirper.Domain.WebApi.Cluster
{
    public class ActorSystemWrapper : IActorSystemWrapper
    {
        public ActorSystem ActorSystem { get; set; }
        public ActorSystemWrapper()
        {
            Config config = ConfigurationFactory.ParseString(@"
                akka {
                    actor {
                        provider = cluster
                        receive = on 
                        autoreceive = on
                        lifecycle = on
                        event-stream = on
                        unhandled = on
                        serializers {
                            akka-sharding = ""Akka.Cluster.Sharding.Serialization.ClusterShardingMessageSerializer, Akka.Cluster.Sharding""
                        }
                        serialization-bindings {
                            ""Akka.Cluster.Sharding.IClusterShardingSerializable, Akka.Cluster.Sharding"" = akka-sharding
                        }
                        serialization-identifiers {
                            ""Akka.Cluster.Sharding.Serialization.ClusterShardingMessageSerializer, Akka.Cluster.Sharding"" = 13
                        }
                    }
                    remote {
                        log-remote-lifecycle-events = DEBUG
                        log-received-messages = on

                        dot-netty.tcp {
                            port = 0
                            hostname = localhost
                        }
                    }
                    cluster {
                        seed-nodes = [""akka.tcp://chirper@localhost:8090""]
                        roles = [""webapi""]
                    }
                }
            ");
            ActorSystem = ActorSystem.Create("chirper", config);
        }

        public async Task TellChirpUser(string chirpUserId, object message)
        {
            IActorRef region = await ClusterSharding.Get(ActorSystem).StartAsync(
                typeName: "ChirpUser",
                entityProps: Props.Create(() => new ChirpUser(chirpUserId)),
                settings: ClusterShardingSettings.Create(ActorSystem).WithRole("webapi"),
                messageExtractor: new MessageExtractor());

            region.Tell(new ShardEnvelope(chirpUserId, message));
        }
    }
}
