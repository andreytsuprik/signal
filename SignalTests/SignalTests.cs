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
            var exception = Assert.Catch<Exception>(() => new Signal.Signal(null, new LaunchTimeStub()));
            StringAssert.Contains("Action to perform at launch time could not be set as a null value", exception.Message);
        }

        [Test]
        public void Signal_OnSettingNullLaunchTimeStubCollection_ThrowsException()
        {
            var exception = Assert.Catch<Exception>(() => new Signal.Signal(() => Console.WriteLine(), null));
            StringAssert.Contains("Collection of launch times could not be set as a null value", exception.Message);
        }

        [Test]
        public void Signal_OnSettingEmptyLaunchTimeStubCollection_ThrowsException()
        {
            var exception = Assert.Catch<Exception>(() => new Signal.Signal(() => Console.WriteLine(), new ILaunchTime[] { } ));
            StringAssert.Contains("Collection of launch times could not be empty", exception.Message);
        }
    }
}
