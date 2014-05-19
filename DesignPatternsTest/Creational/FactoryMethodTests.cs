using System;
using DesignPatterns.Model;
using DesignPatterns.Patterns.Creational.FactoryMethod;
using NUnit.Framework;

namespace DesignPatternsTest.Creational
{
    [TestFixture]
    class FactoryMethodTest
    {
        [Test]
        public void BuildCarTestCase()
        {
            VehicleFactory factory = new CarFactory();
            var vehicle = factory.Build(VehicleFactory.DrivingStyle.Economical, 
                VehicleColour.Blue);
            //log 
            Console.WriteLine(vehicle.ToString());
            Assert.IsInstanceOf<Saloon>(vehicle);
        }

        [Test]
        public void StaticBuildTestCase()
        {
            var vehicle = VehicleFactory.MakeVehicle(VehicleFactory.Category.Van, 
                VehicleFactory.DrivingStyle.Powerful, VehicleColour.Silver);
            //log
            Console.WriteLine(vehicle.ToString());
            Assert.IsInstanceOf<Pickup>(vehicle);
        }
    }
}
