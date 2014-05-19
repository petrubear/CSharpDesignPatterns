using DesignPatterns.Patterns.Behavioural.ChainOfResponsibility;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class ChainOfResponsibilityTests
    {
        [Test]
        public static void ChainOfResponsibilityTestCase()
        {
            const string email = @"Sample mail to buy something";
            AbstractEmailHandler.Handle(email); //debe ser sales
            //todo: define test
        }
    }
}
