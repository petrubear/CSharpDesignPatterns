using System;
using DesignPatterns.Patterns.Behavioural.State;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class StateTests
    {
        [Test]
        public void StateTestCase()
        {
            var clockSetup = new ClockSetup();
            //set year
            clockSetup.RotateKnobRight();
            clockSetup.PushKnob();
            //month
            clockSetup.RotateKnobRight();
            clockSetup.RotateKnobRight();
            clockSetup.PushKnob();
            //day
            clockSetup.RotateKnobRight();
            clockSetup.RotateKnobRight();
            clockSetup.RotateKnobRight();
            clockSetup.PushKnob();
            //hour
            clockSetup.RotateKnobLeft();
            clockSetup.RotateKnobLeft();
            clockSetup.PushKnob();
            //minute
            clockSetup.RotateKnobRight();
            clockSetup.PushKnob();
            //finished
            clockSetup.PushKnob();

            var day = DateTime.Now.Day + 3;
            //awas wey!! podria dar false si el dia pasa del maximo del mes
            Assert.AreEqual(day, clockSetup.DaySetupState.SelectedValue);
        }
    }
}
