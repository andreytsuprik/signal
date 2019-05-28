# signal
Signal is a C# class that is used to perform some actions by schedule.

Signal class provides functionality that allows users to perform any Action type delegate 
according to a schedule. 
The core of the system is represented by common System.Timers.Timer instance which starts every second and appeals to the schedule of the class.
The schedule itself is a collection of LaunchTime class instances, which
checks whether current time is an appropriate moment to call the Action by comparison current time's hour, minute and second values 
with corresponding properties from a LaunchTime class instance.
