using System;
using DesignPatterns.Model;
using DesignPatterns.Patterns.Creational.Prototype;
using NUnit.Framework;

namespace DesignPatternsTest.Creational
{   
    [TestFixture]
    class PrototypeTests
    {
        [Test]
        public void CreatePrototypeCase()
        {
            var manager = new VehicleManager();
            var vehicle = manager.CreateCoupe();
            //log
            Console.WriteLine(vehicle.ToString());
            Assert.IsInstanceOf<Coupe>(vehicle);
        }
        [Test]
        public void CreateLazyPrototypeCase()
        {
            var manager = new VehicleManagerLazy();
            var vehicle = manager.CreateSaloon();
            //log
            Console.WriteLine(vehicle.ToString());
            Assert.IsInstanceOf<Saloon>(vehicle);
        }
    }
}
