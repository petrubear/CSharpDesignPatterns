using DesignPatterns.Patterns.Behavioural.Template;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class TemplateTests
    {
        [Test]
        public void TemplateTestCase()
        {
            AbstractBookletPrinter saloonBooklet =
                new SaloonBooklet();
            saloonBooklet.Print();

            AbstractBookletPrinter serviceBooklet =
                new ServiceHistoryBooklet();
            serviceBooklet.Print();

            //todo define tests
        }
    }
}