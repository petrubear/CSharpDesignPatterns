using DesignPatterns.Model;
using DesignPatterns.Patterns.Structural.Adapter;
using NUnit.Framework;
using System;

namespace DesignPatternsTest.Structural
{
    [TestFixture]
    public class AdapterTests
    {
        [Test]
        public void AdapterTestCase()
        {
            var engine1 = new StandardEngine(1200);
            var engine2 = new SuperGreenEngine(1500);
            var adapter = new SuperGreenEngineAdapter(engine2);

            //Log
            Console.WriteLine(engine1.ToString());
            Console.WriteLine(engine2.ToString());
            Console.WriteLine(adapter.ToString());
            Assert.IsInstanceOf<IEngine>(adapter);
        }
    }
}
