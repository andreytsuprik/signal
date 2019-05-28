using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Signal;

namespace SignalTests
{
    public class SignalMock : ISignal
    {
        private ICollection<ILaunchTime> launchTimes;
        protected Action actionToPerformAtLaunchTime;

        public virtual Action ActionToPerformAtLaunchTime
        {
            get
            {
                return actionToPerformAtLaunchTime;
            }

            private set
            {
                actionToPerformAtLaunchTime = value ?? throw new Exception("Action to perform at launch time could not be set as a null value");
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
                    throw new Exception("Collection of launch times could not be set as a null value");
                }

                if (value.Count == 0)
                {
                    throw new Exception("Collection of launch times could not be empty");
                }

                launchTimes = value;
            }
        }

        public SignalMock(Action actionToPerformAtLaunchTime, params ILaunchTime[] launchTimes)
        {
            ActionToPerformAtLaunchTime = actionToPerformAtLaunchTime;
            LaunchTimes = launchTimes;

            PerformAction();
        }        

        private void PerformAction()
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
