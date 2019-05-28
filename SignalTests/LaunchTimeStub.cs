using Signal;

namespace SignalTests
{
    internal class LaunchTimeStub: ILaunchTime
    {
        private bool isCalled = false;

        public bool IsNow()
        {
            if (!isCalled)
            {
                isCalled = true;
                return true;
            }

            return false;
        }
    }
}
