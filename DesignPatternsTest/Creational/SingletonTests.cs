using System;
using DesignPatterns.Patterns.Creational.Singleton;
using NUnit.Framework;

namespace DesignPatternsTest.Creational
{   
    [TestFixture]
    class SingletonTests
    {
        [Test]
        public void SingletonCallTestCase()
        {
            var serial = SerialNumberGenerator.Instance;
            var serial2 = SerialNumberGenerator.Instance;
            var a = serial.NextSerial;
            var b = serial2.NextSerial;
            //log
            Console.WriteLine(@"{0} != {1}", a, b);
            Assert.AreEqual(a+1, b);
        }
    }
}
