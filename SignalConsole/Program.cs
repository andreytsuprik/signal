using Signal;
using System;

namespace SignalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Signal.Signal simpleSignal = null;
            Signal.Signal alarmClock = null;
            Signal.Signal notificationAboutGarbage = null;
            Signal.Signal notificationsAboutCat = null;

            try
            {                
                simpleSignal = new Signal.Signal(() => Console.WriteLine("Some signal"), new LaunchTime(14, 04, 05));
                alarmClock = new AlarmClock(new LaunchTime(07, 00));
                notificationAboutGarbage = new Notification("Don't forget to throw the garbage away!", new LaunchTime(08, 00));
                notificationsAboutCat = new Notification("Don't forget to feed your cat!", new LaunchTime(07, 30), new LaunchTime(13, 30), new LaunchTime(19, 30));

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            finally
            {
                if (simpleSignal != null)
                {
                    simpleSignal.Dispose();
                }

                if (alarmClock != null)
                {
                    alarmClock.Dispose();
                }

                if (notificationAboutGarbage != null)
                {
                    notificationAboutGarbage.Dispose();
                }

                if (notificationsAboutCat != null)
                {
                    notificationsAboutCat.Dispose();
                }
            }            
        }
    }
}
