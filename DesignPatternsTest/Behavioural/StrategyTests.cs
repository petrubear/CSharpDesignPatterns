using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.Model;
using DesignPatterns.Patterns.Behavioural.Strategy;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class StrategyTests
    {
        [Test]
        public void StrategyTestCase()
        {
            AbstractCar absCar = new Sport(
                new StandardEngine(2000));
            absCar.Speed = 20;
            absCar.Speed = 40;

            absCar.GearboxStrategy = new SportGearboxStrategy();
            absCar.Speed = 20;
            absCar.Speed = 40;

            //todo define test!
        }
    }
}
