using DesignPatterns.Patterns.UsefullExtra.NullObject;
using NUnit.Framework;

namespace DesignPatternsTest.UsefullExtra
{
    [TestFixture]
    public class NullObjectTests
    {
        [Test]
        public void NullObjectTestCase()
        {
            var lights = new IWarningLight[3];
            lights[0] = new OilLevelLight();
            lights[1] = new BrakeFluidLight();
            lights[2] = new NullObjectLight();

            foreach (var warningLight in lights)
            {
                //no requiere validar si es o no null
                warningLight.TurnOn();
                warningLight.TurnOff();
            }

            //todo define tests
        }
    }
}
