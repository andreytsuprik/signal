using System;
using System.Collections.Generic;

namespace Signal
{
    public interface ISignal : IDisposable
    {
        Action ActionToPerformAtLaunchTime { get; }
        ICollection<ILaunchTime> LaunchTimes { get; }
    }
}
