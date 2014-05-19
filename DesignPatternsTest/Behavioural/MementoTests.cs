using System;
using DesignPatterns.Patterns.Behavioural.Memento;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class MementoTests
    {
        [Test]
        public void MementoTestCase()
        {
            var speedo = new Speedometer
                         {
                             CurrentSpeed = 50
                         };
            speedo.CurrentSpeed = 100;
            //Log
            Console.WriteLine(@"Current speed: {0}",
                speedo.CurrentSpeed);

            //guardar el estado
            var memento = new SpeedometerMemento(speedo);

            //cambiar el objeto
            speedo.CurrentSpeed = 180;
            //Log
            Console.WriteLine(@"Current speed: {0}",
                speedo.CurrentSpeed);

            // restarurar estado
            memento.RestoreState();

            Assert.AreEqual(100, speedo.CurrentSpeed);
        }
        [Test]
        public void MementoSerialTestCase()
        {
            var speedo = new SpeedometerSerial
            {
                CurrentSpeed = 50
            };
            speedo.CurrentSpeed = 100;
            //Log
            Console.WriteLine(@"Current speed: {0}",
                speedo.CurrentSpeed);

            //guardar el estado
            var memento = new SpeedometerMementoSerial(speedo);

            //cambiar el objeto
            speedo.CurrentSpeed = 180;
            //Log
            Console.WriteLine(@"Current speed: {0}",
                speedo.CurrentSpeed);

            // restarurar estado
            speedo = memento.RestoreState();

            Assert.AreEqual(100, speedo.CurrentSpeed);
        }
    }
}
