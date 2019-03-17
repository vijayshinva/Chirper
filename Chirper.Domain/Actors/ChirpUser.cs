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
        Task Subscribe(IWallObserver observer);
        Task UnSubscribe(IWallObserver observer);
    }
    public class ChirpUser : Grain, IChirpUser
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        public List<string> Wall { get; set; } = new List<string>();
        private readonly GrainObserverManager<IWallObserver> observerManager = new GrainObserverManager<IWallObserver>();

        public override async Task OnActivateAsync()
        {
            observerManager.ExpirationDuration = new TimeSpan(1, 0, 0);
            await base.OnActivateAsync();
        }

        public Task ChirpMessage(Message message)
        {
            Messages.Add(message);
            observerManager.Notify(observer => observer.WallUpdate(message));
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

        public Task Subscribe(IWallObserver observer)
        {
            observerManager.Subscribe(observer);
            return Task.CompletedTask;
        }

        public Task UnSubscribe(IWallObserver observer)
        {
            observerManager.Subscribe(observer);
            return Task.CompletedTask;
        }
    }
}
