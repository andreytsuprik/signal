using System;

namespace Signal
{
    public class Notification: Signal
    {
        public Notification(string notificationMessage, params LaunchTime[] launchTimes)
               : base(() => Console.WriteLine(notificationMessage), launchTimes)
        {
            
        }
    }
}
