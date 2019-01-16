using Akka.Actor;
using Akka.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chirper.Domain.Host
{
    internal class Program
    {
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static void Main(string[] args)
        {
            string port = Environment.GetEnvironmentVariable("CHIRPER_PORT");
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
                            port = 8090
                            hostname = localhost
                        }
                    }
                    cluster {
                        seed-nodes = [""akka.tcp://chirper@localhost:8090""]
                        roles = [""chirper""]
                    }
                    cluster.sharding {
                        journal-plugin-id = ""akka.persistence.journal.sharding""
                        snapshot-plugin-id = ""akka.persistence.snapshot-store.sharding""
                    }
                    persistence {
                        journal {
                            plugin = ""cassandra-journal""
                            sharding {
                                auto-initialize = on
                                plugin-dispatcher = ""akka.actor.default-dispatcher""
                                class = ""Akka.Persistence.Cassandra.Journal.CassandraJournal, Akka.Persistence.Cassandra""
                                connection-timeout = 30s
                                schema-name = dbo
                                table-name = ShardingJournal
                                metadata-table-name = ShardingMetadata
                            }
                        }
                        snapshot-store {
                            plugin = ""cassandra-snapshot-store""
                            sharding {
                                class = ""Akka.Persistence.Cassandra.Snapshot.CassandraSnapshotStore, Akka.Persistence.Cassandra
                                plugin-dispatcher = ""akka.actor.default-dispatcher""
                                connection-timeout = 30s
                                schema-name = dbo
                                table-name = ShardingSnapshotStore
                                auto-initialize = on
                            }
                        }
                        cassandra-sessions{
                            default {
                                contact-points = [ ""192.168.56.101"" ]
                                port = 9042
                            }
                        }
                    }
                }
            ");

            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Server exit.");
                waitHandle.Set();
            };

            Task.Run(() =>
            {
                using (ActorSystem system = ActorSystem.Create("chirper", config))
                {
                    Console.WriteLine("Server start. Press Ctrl+C to exit.");
                    waitHandle.WaitOne();
                }
            });
            waitHandle.WaitOne();
        }
    }
}
