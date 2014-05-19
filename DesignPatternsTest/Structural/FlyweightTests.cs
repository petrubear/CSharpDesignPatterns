
using System;
using DesignPatterns.Model;
using DesignPatterns.Patterns.Structural.Flyweight;
using NUnit.Framework;

namespace DesignPatternsTest.Structural
{
    [TestFixture]
    public class FlyweightTests
    {
        [Test]
        public void FlyweightTestCase()
        {
            var factory = new EngineFlyweightFactory();
            var tool = new EngineDiagnosticTool();
            var standard1 = factory.GetStandardEngine(1300);
            //diagnosticos tardan, comentado
            //standard1.Diagnose(tool);
            var standard2 = factory.GetStandardEngine(1300);
            //standard2.Diagnose(tool);
            var standard3 = factory.GetStandardEngine(1300);
            //standard3.Diagnose(tool);
            var standard4 = factory.GetStandardEngine(1600);
            //standard4.Diagnose(tool);
            var standard5 = factory.GetStandardEngine(1600);
            //standard5.Diagnose(tool);

            //Log
            Console.WriteLine(@"standard1: {0}", standard1.GetHashCode());
            Console.WriteLine(@"standard2: {0}", standard2.GetHashCode());
            Console.WriteLine(@"standard3: {0}", standard3.GetHashCode());
            Console.WriteLine(@"standard4: {0}", standard4.GetHashCode());
            Console.WriteLine(@"standard5: {0}", standard5.GetHashCode());

            Assert.AreNotEqual(standard1.GetHashCode(), standard5.GetHashCode());
        }
    }
}
