using System;
using System.Collections.Generic;
using System.Timers;

namespace Signal
{
    public class Signal : ISignal, IDisposable
    {
        private static readonly int launchTimeCheckingIntervalInSeconds = 1;
        private static readonly int millisecondsInSecond = 1000;        

        private Timer systemTimer;
        private Action actionToPerformAtLaunchTime;
        private ICollection<ILaunchTime> launchTimes;
        

        public virtual Action ActionToPerformAtLaunchTime
        {
            get
            {
                if(actionToPerformAtLaunchTime == null)
                {
                    throw new Exception("Action to perform at launch time is null");
                }

                return actionToPerformAtLaunchTime;
            }

            protected set
            {
                actionToPerformAtLaunchTime = value ?? throw new Exception("Action to perform at launch time could not be set as null");
            }
        }

        public ICollection<ILaunchTime> LaunchTimes
        {
            get
            {
                return launchTimes;
            }

            private set
            {
                if (value == null)
                {
                    throw new Exception("Collection of launch times could not be set as null");
                }

                if (value.Count == 0)
                {
                    throw new Exception("Collection of launch times could not be empty");
                }

                launchTimes = value;
            }
        }

        private int SignalTimeCheckingIntervalInMilliseconds
        {
            get
            {
                return launchTimeCheckingIntervalInSeconds * millisecondsInSecond;
            }
        }

        public Signal(params ILaunchTime[] launchTimes)
        {            
            LaunchTimes = launchTimes;
            InitializeSystemTimer();
        }

        public Signal(Action actionToPerformAtLaunchTime, params ILaunchTime[] launchTimes)
        {
            ActionToPerformAtLaunchTime = actionToPerformAtLaunchTime;
            LaunchTimes = launchTimes;
            InitializeSystemTimer();
        }        

        public void Dispose()
        {
            systemTimer.Dispose();
        }

        private void InitializeSystemTimer()
        {
            systemTimer = new Timer(SignalTimeCheckingIntervalInMilliseconds);
            systemTimer.Elapsed += CheckOnLaunchTime;
            systemTimer.AutoReset = true;
            systemTimer.Enabled = true;
        }

        private void CheckOnLaunchTime(object source, ElapsedEventArgs e)
        {
            if (IsLaunchTimeNow())
            {
                ActionToPerformAtLaunchTime();
            }
        }

        private bool IsLaunchTimeNow()
        {
            foreach (var launchTime in LaunchTimes)
            {
                if (launchTime.IsNow())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
