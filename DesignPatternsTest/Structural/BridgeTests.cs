using DesignPatterns.Model;
using DesignPatterns.Patterns.Structural.Bridge;
using NUnit.Framework;

namespace DesignPatternsTest.Structural
{
    [TestFixture]
    public class BridgeTests
    {
        [Test]
        public void BridgeTestCase()
        {
            IEngine engine = new TurboEngine(2000);
            var controls = new SportControls(engine);
            controls.IgnitionOn();
            controls.AccelerateHard();
            const int actualPower = 2;
            //controls.IgnitionOff(); //power 0
            Assert.AreEqual(actualPower, engine.Power);
        }
    }
}
