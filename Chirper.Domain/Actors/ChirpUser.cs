using Chirper.Domain.Entities;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chirper.Domain.Actors
{
    public interface IChirpUser : IGrainWithGuidKey
    {
        Task ChirpMessage(Message message);
        Task FollowChirpUser(Guid chirpUserId);
        Task UnFollowChirpUser(Guid chirpUserId);
    }
    public class ChirpUser : Grain, IChirpUser
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        public List<string> Wall { get; set; } = new List<string>();

        public Task ChirpMessage(Message message)
        {
            Messages.Add(message);
            return Task.CompletedTask;
        }

        public Task FollowChirpUser(Guid chirpUserId)
        {
            var chirpUser = GrainFactory.GetGrain<IChirpUser>(chirpUserId);
            return Task.CompletedTask;
        }

        public Task UnFollowChirpUser(Guid chirpUserId)
        {
            var chirpUser = GrainFactory.GetGrain<IChirpUser>(chirpUserId);
            return Task.CompletedTask;
        }
    }
}
