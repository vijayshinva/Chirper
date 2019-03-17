using Chirper.Domain.Entities;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chirper.Domain
{
    public interface IWallObserver : IGrainObserver
    {
        void WallUpdate(Message message);
    }
}
