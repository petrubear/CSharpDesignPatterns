using DesignPatterns.Patterns.Behavioural.Observer;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class ObserverTests
    {
        [Test]
        public void ObserverTestCase()
        {
            var speedometer = new Speedometer();
            var speedMonitor = new SpeedMonitor(speedometer);
            var autogear = new AutomaticGearBox(speedometer);

            //Log
            speedometer.CurrentSpeed = 50;
            speedometer.CurrentSpeed = 10;
            speedometer.CurrentSpeed = 20;
            speedometer.CurrentSpeed = 150;

            Assert.IsTrue(speedMonitor.HasAlerts);
        }
    }
}
