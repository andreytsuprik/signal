using System;

namespace Signal
{
    public class LaunchTime: ILaunchTime
    {
        private int launchHour;
        private int launchMinute;
        private int launchSecond;

        private int LaunchHour
        {
            get
            {
                return launchHour;
            }

            set
            {
                var isValidValue = value >= 0 && value < 24;
                if (!isValidValue)
                {
                    throw new Exception("Launch hour should be an integer value from 0 to 23");
                }

                launchHour = value;
            }
        }

        private int LaunchMinute
        {
            get
            {
                return launchMinute;
            }

            set
            {
                var isValidValue = value >= 0 && value < 60;
                if (!isValidValue)
                {
                    throw new Exception("Launch minute should be an integer value from 0 to 59");
                }

                launchMinute = value;
            }
        }

        private int LaunchSecond
        {
            get
            {
                return launchSecond;
            }

            set
            {
                var isValidValue = value >= 0 && value < 60;
                if (!isValidValue)
                {
                    throw new Exception("Launch second should be an integer value from 0 to 59");
                }

                launchSecond = value;
            }
        }

        public LaunchTime(int launchHour, int launchMinute)
        {
            LaunchHour = launchHour;
            LaunchMinute = launchMinute;
            LaunchSecond = 0;
        }

        public LaunchTime(int launchHour, int launchMinute, int launchSecond)
        {
            LaunchHour = launchHour;
            LaunchMinute = launchMinute;
            LaunchSecond = launchSecond;
        }

        public bool IsNow()
        {
            var currentTime = DateTime.Now;
            return currentTime.Hour == LaunchHour 
                   && currentTime.Minute == LaunchMinute 
                   && currentTime.Second == LaunchSecond;
        }
    }
}
