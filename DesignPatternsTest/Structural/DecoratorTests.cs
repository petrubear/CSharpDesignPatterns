using DesignPatterns.Model;
using DesignPatterns.Patterns.Structural.Decorator;
using NUnit.Framework;
using System;

namespace DesignPatternsTest.Structural
{
    [TestFixture]
    public class DecoratorTests
    {
        [Test]
        public void DecoratorTestCase()
        {
            IVehicle vehicle = new Saloon(new StandardEngine(1200));
            vehicle.Paint(VehicleColour.Silver);
            //add extras
            vehicle = new AirConditionedVehicle(vehicle);
            vehicle = new AlloyWheeledVehicle(vehicle);
            vehicle = new MetallicPaintedVehicle(vehicle);
            vehicle = new SatNavVehicle(vehicle);

            //Log 
            Console.WriteLine(@"Price: {0:C}", vehicle.Price);
            const int totalPrice = 9100;
            Assert.AreEqual(totalPrice, vehicle.Price);
        }
    }
}