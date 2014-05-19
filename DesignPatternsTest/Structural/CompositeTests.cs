using DesignPatterns.Patterns.Structural.Composite;
using NUnit.Framework;
using System;

namespace DesignPatternsTest.Structural
{
    [TestFixture]
    public class CompositeTests
    {
        [Test]
        public void CompositeTestCase()
        {
            var nut = new Part(@"Nut", 5);
            var bolt = new Part(@"Bolt", 9);
            var panel = new Part(@"Panel", 35);

            var gizmo = new Assembly(@"Gizmo");
            gizmo.AddItem(nut);
            gizmo.AddItem(panel);
            gizmo.AddItem(bolt);

            var widget = new Assembly(@"Widget");
            widget.AddItem(gizmo);
            widget.AddItem(nut);

            const int totalCost = 54;

            //Log
            Console.WriteLine(widget.ToString());
            Assert.AreEqual(totalCost, widget.Cost);
        }
    }
}
