using System;
using DesignPatterns.Patterns.Behavioural.Interpreter;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class InterpreterTests
    {
        [Test]
        public void InterpreterTestCase()
        {
            var evaluator = 
                new DirectionalEvaluator();

            var result = evaluator.Evaluate(@"london edinburgh manchester southerly");
            //Log
            Console.WriteLine(@"Directional result: {0}", result);
            result = evaluator.Evaluate(@"london edinburgh manchester southerly aberdeen westerly");
            Assert.AreEqual(@"Aberdeen", result.Name);
        }
    }
}
