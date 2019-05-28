using System;
using System.Collections.Generic;

namespace Signal
{
    public interface ISignal
    {
        Action ActionToPerformAtLaunchTime { get; }
        ICollection<ILaunchTime> LaunchTimes { get; }
    }
}
