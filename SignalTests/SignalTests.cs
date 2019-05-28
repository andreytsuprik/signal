using NUnit.Framework;
using Signal;
using System;

namespace SignalTests
{
    [TestFixture]
    public class SignalTests
    {
        [Test]
        public void Signal_AtLaunchTime_PerformsAnyAction()
        {
            var testString = "Alice";
            var controlString = "Bob";

            var signalFake = new SignalMock(() => testString = controlString, new LaunchTimeStub());

            Assert.AreEqual(testString, controlString);        
        }       

        [Test]
        public void Signal_OnSettingNullAction_ThrowsException()
        {
            Action testAction = null;
            var exception = Assert.Catch<Exception>(() => new Signal.Signal(testAction, new LaunchTimeStub()));
            StringAssert.Contains("Action to perform at launch time could not be set as null", exception.Message);
        }

        [Test]
        public void Signal_OnSettingNullLaunchTimeCollection_ThrowsException()
        {
            var exception = Assert.Catch<Exception>(() => new Signal.Signal(() => Console.WriteLine(), null));
            StringAssert.Contains("Collection of launch times could not be set as null", exception.Message);
        }

        [Test]
        public void Signal_OnSettingEmptyLaunchTimeCollection_ThrowsException()
        {
            var exception = Assert.Catch<Exception>(() => new Signal.Signal(() => Console.WriteLine(), new ILaunchTime[] { } ));
            StringAssert.Contains("Collection of launch times could not be empty", exception.Message);
        }

        [Test]
        public void Notification_OnSettingEmptyNotificationMessage_ThrowsException()
        {
            var exception = Assert.Catch<Exception>(() => new Notification(String.Empty, new LaunchTimeStub()));
            StringAssert.Contains("Notification message could not be set as an empty string", exception.Message);
        }

        [Test]
        public void Notification_OnSettingNullNotificationMessage_ThrowsException()
        {
            var exception = Assert.Catch<Exception>(() => new Notification(null, new LaunchTimeStub()));
            StringAssert.Contains("Notification message could not be set as null value", exception.Message);
        }
    }
}
