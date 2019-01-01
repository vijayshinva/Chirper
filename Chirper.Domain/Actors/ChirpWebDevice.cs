using Akka.Actor;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain.Actors
{
    public class ChirpWebDevice : UntypedActor
    {
        private readonly string chirpUserId;
        private readonly IClientProxy client;

        public ChirpWebDevice(string chirpUserId, IClientProxy client)
        {
            this.chirpUserId = chirpUserId;
            this.client = client;
        }

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}
