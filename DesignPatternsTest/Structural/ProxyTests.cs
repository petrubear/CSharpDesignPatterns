using DesignPatterns.Model;
using DesignPatterns.Patterns.Structural.Proxy;
using NUnit.Framework;

namespace DesignPatternsTest.Structural
{
    [TestFixture]
    public class ProxyTests
    {
        [Test]
        public void ProxyTestCase()
        {
            var proxy = new EngineProxy(1200, false);
            var tool = new EngineDiagnosticTool();
            //diagnosticos tardan, comentado
            //proxy.Diagnose(tool);
            //todo: define test 
        }
    }
}
