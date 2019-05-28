using System;

namespace Signal
{
    public class AlarmClock : Signal
    {  
        public AlarmClock(params ILaunchTime[] launchTimes)
               :base(() => Console.WriteLine("Wake up! It's time!"), launchTimes)
        {
            
        }        
    }
}
