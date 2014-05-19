using DesignPatterns.Model;
using DesignPatterns.Patterns.Behavioural.Visitor;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class VisitorTests
    {
        [Test]
        public void VisitorTestCase()
        {
            IEngine engine = new StandardEngine(1500);
            //diagnostics
            engine.AcceptEngineVisitor(new EngineDiagnostics());
            //inventory
            engine.AcceptEngineVisitor(new EngineInventory());
        }
    }
}
