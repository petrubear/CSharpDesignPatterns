using System;
using DesignPatterns.Patterns.Creational.AbstractFactory;
using DesignPatterns.Model;
using NUnit.Framework;

namespace DesignPatternsTest.Creational
{
    [TestFixture]
    public class AbstractFactoryTests
    {
        [Test]
        public void CreateCarTestCase()
        {
            var vehicle = CreateVehicle(@"car");
            var vehicleBody = vehicle.CreateBody();
            var vehicleChasis = vehicle.CreateChasis();
            var vehicleGlassware = vehicle.CreateGlassware();

            //Log
            Console.WriteLine(vehicleBody);
            Console.WriteLine(vehicleChasis);
            Assert.IsInstanceOf<CarGlassware>(vehicleGlassware);
        }
        [Test]
        public void CreateVanTestCase()
        {
            var vehicle = CreateVehicle(@"van");
            var vehicleBody = vehicle.CreateBody();
            Assert.IsInstanceOf<VanBody>(vehicleBody);
        }
        private static AbstractVehicleFactory CreateVehicle(string type)
        {
            AbstractVehicleFactory factory = null;
            //get factory
            switch (type)
            {
                case @"car":
                    factory = new CarFactory();
                    break;
                case @"van":
                    factory = new VanFactory();
                    break;
            }

            return factory;
        }
    }
}
