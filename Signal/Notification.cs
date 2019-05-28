using System;

namespace Signal
{
    public class Notification: Signal
    {
        private string notificationMessage;

        private string NotificationMessage
        {
            get
            {
                return notificationMessage;
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new Exception("Notification message could not be set as an empty string");
                }

                notificationMessage = value ?? throw new Exception("Notification message could not be set as null value");
            }
        }

        public Notification(string notificationMessage, params ILaunchTime[] launchTimes): base(launchTimes)        
        {
            NotificationMessage = notificationMessage;
            ActionToPerformAtLaunchTime = () => Console.WriteLine(NotificationMessage);
        }
    }
}
