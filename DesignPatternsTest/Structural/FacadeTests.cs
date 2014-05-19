using DesignPatterns.Model;
using DesignPatterns.Patterns.Structural.Facade;
using NUnit.Framework;

namespace DesignPatternsTest.Structural
{
    [TestFixture]
    public class FacadeTests
    {
        [Test]
        public void FacadeTestCase()
        {
            var facade = new VehicleFacade();
            var vehicle = new Coupe(new StandardEngine(1200));
            facade.PrepareForSale(vehicle);
            //no tests, log only XD 
        }
    }
}
