using NUnit.Framework;
using System;
using DesignPatterns.Patterns.Behavioural.Mediator;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture()]
    public class MediatorTests
    {
        [Test()]
        public void MediatorTestCase()
        {
            var ems = new EngineManagementSystem();
            var ignition = new Ignition(ems);
            var accelerator = new Accelerator(ems);
            var brake = new Brake(ems);
            var gearbox = new GearBox(ems);

            //Log
            ignition.Start();
            accelerator.AccelerateToSpeed(40);
            accelerator.AccelerateToSpeed(80);
            brake.Apply();
            ignition.Stop();
            //todo: define tests
        }
    }
}

