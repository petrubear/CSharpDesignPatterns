using System;
using DesignPatterns.Model;
using DesignPatterns.Patterns.Creational.Builder;
using NUnit.Framework;

namespace DesignPatternsTest.Creational
{
    [TestFixture]
    class BuilderTests
    {
        [Test]
        public void BuildCarTestCase()
        {
            AbstractCar car = new Saloon(new StandardEngine(1300), 
                VehicleColour.Yellow);
            VehicleBuilder builder = new CarBuilder(car);
            VehicleDirector director = new CarDirector();
            var vehicle = director.Build(builder);
            //Log
            Console.WriteLine(vehicle.ToString());
            Assert.IsInstanceOf<Saloon>(vehicle);
        }

        [Test]
        public void VanBuilderCase()
        {
            var van = new BoxVan(new TurboEngine(2500), 
                VehicleColour.Black);
            var builder = new VanBuilder(van);
            var director = new VanDirector();
            var vehicle = director.Build(builder);
            //Log
            Console.WriteLine(vehicle.ToString());
            Assert.IsInstanceOf<AbstractVan>(vehicle);
        }
    }
}
