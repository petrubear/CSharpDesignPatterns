using System;

namespace DesignPatterns.Patterns.Behavioural.Observer
{
    /* define una relacion 1-n entre objetos de manera que cuando
     * uno de los objetos cambia su estado, se notifica a todos 
     * los dependientes automaticamente
     */
    public class Speedometer
    {
        public event EventHandler ValueChanged;
        private int _currentSpeed;

        public Speedometer()
        {
            _currentSpeed = 0;
        }

        public virtual int CurrentSpeed
        {
            set
            {
                _currentSpeed = value;

                //avisar a los observers que el valor ha cambiado
                OnValueChanged();
            }
            get
            {
                return _currentSpeed;
            }
        }

        protected void OnValueChanged()
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }
    }

    public class SpeedMonitor
    {
        private const int SpeedAlert = 80;
        private bool _alert;

        public bool HasAlerts
        {
            get { return _alert; }
        }
        public SpeedMonitor(Speedometer speedo)
        {
            _alert = false;
            speedo.ValueChanged += SpeedoValueChanged;
        }

        private void SpeedoValueChanged(object sender, EventArgs args)
        {
            var speedometer = (Speedometer)sender;
            _alert = speedometer.CurrentSpeed > SpeedAlert;
            Console.WriteLine(_alert ? @"Alert: driving too fast!" : @"no hay problema! ");
        }
    }

    public class AutomaticGearBox
    {
        public AutomaticGearBox(Speedometer speedo)
        {
            speedo.ValueChanged += SpeedoValueChanged;
        }

        private void SpeedoValueChanged(object sender, EventArgs args)
        {
            var speedometer = (Speedometer)sender;
            if (speedometer.CurrentSpeed <= 10)
            {
                Console.WriteLine(@"First gear");
            }
            else if (speedometer.CurrentSpeed <= 20)
            {
                Console.WriteLine(@"Second gear");
            }
            else if (speedometer.CurrentSpeed <= 30)
            {
                Console.WriteLine(@"Third gear");
            }
            else
            {
                Console.WriteLine(@"Fourth gear");
            }
        }
    }
}
