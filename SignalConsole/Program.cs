using Signal;
using System;

namespace SignalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ISignal simpleSignal = null;
            ISignal alarmClock = null;
            ISignal notificationAboutGarbage = null;
            ISignal notificationsAboutCat = null;

            try
            {                
                simpleSignal = new Signal.Signal(() => Console.WriteLine("Some signal"), new LaunchTime(13, 30, 30));
                alarmClock = new AlarmClock(new LaunchTime(13, 32));
                notificationAboutGarbage = new Notification("Don't forget to throw the garbage away!", new LaunchTime(13, 31));
                notificationsAboutCat = new Notification("Don't forget to feed your cat!", new LaunchTime(13, 31), new LaunchTime(13, 32), new LaunchTime(13, 33));

                Console.ReadLine();               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                simpleSignal.Dispose();
                alarmClock.Dispose();
                notificationAboutGarbage.Dispose();
                notificationsAboutCat.Dispose();
            }
        }
    }
}
