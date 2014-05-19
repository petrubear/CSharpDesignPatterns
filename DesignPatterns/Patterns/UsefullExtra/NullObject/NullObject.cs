
using System;

namespace DesignPatterns.Patterns.UsefullExtra.NullObject
{
    public interface IWarningLight
    {
        void TurnOn();
        void TurnOff();
        bool On { get; }
    }

    public class OilLevelLight : IWarningLight
    {
        private bool _on;

        public virtual void TurnOn()
        {
            _on = true;
            Console.WriteLine(@"oil light On");
        }
        public virtual void TurnOff()
        {
            _on = false;
            Console.WriteLine(@"oil light Off");
        }

        public virtual bool On
        {
            get { return _on; }
        }
    }
    public class BrakeFluidLight : IWarningLight
    {
        private bool _on;

        public virtual void TurnOn()
        {
            _on = true;
            Console.WriteLine(@"brake light On");
        }
        public virtual void TurnOff()
        {
            _on = false;
            Console.WriteLine(@"brake light Off");
        }

        public virtual bool On
        {
            get { return _on; }
        }
    }
    public class NullObjectLight : IWarningLight
    {
        public virtual void TurnOn()
        {
            //do nothing
        }
        public virtual void TurnOff()
        {
            //do nothing
        }

        public virtual bool On
        {
            get { return false; }
        }
    }
}
