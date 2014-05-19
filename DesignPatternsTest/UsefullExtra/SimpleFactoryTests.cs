using DesignPatterns.Patterns.UsefullExtra.SimpleFactory;
using NUnit.Framework;

namespace DesignPatternsTest.UsefullExtra
{   
    [TestFixture]
    public class SimpleFactoryTests
    {
        [Test]
        public void SimpleFactoryTestCase()
        {
            var auto = GearBoxFactory.Create(GearBoxFactory.Type.Automatic);
            var manual = GearBoxFactory.Create(GearBoxFactory.Type.Manual);

            Assert.IsInstanceOf<AutomaticGearbox>(auto);
        }
    }
}
