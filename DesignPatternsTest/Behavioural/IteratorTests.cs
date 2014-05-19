using DesignPatterns.Patterns.Behavioural.Iterator;
using NUnit.Framework;
using System;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void IteratorTestCase()
        {
            var carRange = new CarRange();
            var vanRange = new VanRange();

            //Log
            foreach (var vehicle in carRange)
            {
                Console.WriteLine(vehicle);
            }
            foreach (var vehicle in vanRange)
            {
                Console.WriteLine(vehicle);
            }

            //todo: define test
            Assert.IsNotNull(carRange.GetEnumerator());
        }

    }
}
