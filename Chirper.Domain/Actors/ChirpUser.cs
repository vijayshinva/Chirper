using Akka.Actor;
using Akka.Event;
using Chirper.Domain.Commands;
using Chirper.Domain.Responses;
using System;
using System.Collections.Generic;

namespace Chirper.Domain.Actors
{
    public class ChirpUser : UntypedActor
    {
        public string ChirpUserId { get; }
        public List<object> Chirps { get; set; } = new List<object>();
        public List<object> Followers { get; set; } = new List<object>();
        public List<object> Following { get; set; } = new List<object>();

        private readonly ILoggingAdapter _log = Logging.GetLogger(Context);

        public ChirpUser(string chirpUserId)
        {
            ChirpUserId = chirpUserId;
        }

        protected override void PreStart() => _log.Debug("PreStart");
        protected override void PostStop() => _log.Debug("PostStart");
        protected override void PreRestart(Exception reason, object message) => _log.Debug("PreRestart");
        protected override void PostRestart(Exception reason) => _log.Debug("PostRestart");

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case PostMessage postMessage:
                    Chirps.Add(postMessage);
                    Sender.Tell(new PostMessageResponse(postMessage.RequestId, true));
                    break;
                case SubscribeToChirpUser subscribeToChirpUser:
                    Following.Add(subscribeToChirpUser);
                    Sender.Tell(new SubscribeToChirpUserResponse(subscribeToChirpUser.RequestId, true));
                    break;
                default:
                    break;
            }
        }
        public static Props Props(string chirpUserId)
        {
            return Akka.Actor.Props.Create(() => new ChirpUser(chirpUserId));
        }
    }
}
