using System;

namespace Signal
{
    public class AlarmClock : Signal
    {  
        public AlarmClock(params LaunchTime[] launchTimes)
               :base(() => Console.WriteLine("Wake up! It's time!"), launchTimes)
        {
            
        }        
    }
}
