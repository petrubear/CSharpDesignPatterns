using System;
using System.Data.SqlClient;

namespace DesignPatterns.Patterns.Behavioural.Mediator
{
    //mediator
    public class EngineManagementSystem
    {
        private  Ignition _ignition;
        private  GearBox _gearbox;
        private  Accelerator _accelerator;
        private  Brake _brake;
        private int _currentSpeed;

        public EngineManagementSystem()
        {
            _currentSpeed = 0;
        }
        // registration
        public virtual void RegisterIgnition(Ignition ignition)
        {
            _ignition = ignition;
        }

        public virtual void RegisterGearBox(GearBox gearbox)
        {
            _gearbox = gearbox;
        }

        public virtual void RegisterAccelerator(Accelerator accelerator)
        {
            _accelerator = accelerator;
        }

        public virtual void RegisterBrake(Brake brake)
        {
            _brake = brake;
        }
        // metodos que manejan las interacciones
        public void IgnitionTurnedOn()
        {
            _gearbox.Enable();
            _accelerator.Enable();
            _brake.Enable();
        }

        public void IgnitionTurnedOff()
        {
            _gearbox.Disable();
            _accelerator.Disable();
            _brake.Disable();
        }

        public virtual void GearBoxEnabled()
        {
            Console.WriteLine(@"EMS now controlling the gearbox");
        }

        public virtual void GearBoxDisabled()
        {
            Console.WriteLine(@"EMS no longer controlling the gearbox");
        }

        public virtual void GearChanged()
        {
            Console.WriteLine(@"EMS dissengaging revs while gear changing");
        }

        public virtual void AcceleratorEnabled()
        {
            Console.WriteLine(@"EMS now controlling the accelerator");
        }

        public virtual void AcceleratorDisabled()
        {
            Console.WriteLine(@"EMS no longer controlling the accelerator");
        }

        public virtual void AcceleratorPressed()
        {         
            _brake.Disable(); 
            while (_currentSpeed < _accelerator.Speed)
            {
                _currentSpeed++;           
                Console.WriteLine("Speed currentlt " + _currentSpeed);  
                // Set gear according to speed
                if (_currentSpeed <= 10)
                {
                    _gearbox.Gear = Gear.First;
                }
                else if (_currentSpeed <= 20)
                {
                    _gearbox.Gear = Gear.Second;
                }
                else if (_currentSpeed <= 30)
                {
                    _gearbox.Gear = Gear.Third;
                }
                else if (_currentSpeed <= 50)
                {
                    _gearbox.Gear = Gear.Fourth;
                }
                else
                {
                    _gearbox.Gear = Gear.Fifth;
                }
            }
            _brake.Enable();
        }

        public virtual void BrakeEnabled()
        {
            Console.WriteLine(@"EMS now controlling the brake");
        }

        public virtual void BrakeDisabled()
        {
            Console.WriteLine(@"EMS no longer controlling the brake");
        }

        public virtual void BrakePressed()
        {
            _accelerator.Disable();
            _currentSpeed = 0;
        }

        public virtual void BrakeReleased()
        {
            _gearbox.Gear = Gear.First;
            _accelerator.Enable();
        }
    }
    #region Clases para el ejemplo
    /*
     * las diferentes clases conocen sobre el mediator
     * pero no conocen sobre las demas. el mediator
     * conoce a todas las clases y gestiona sus interacciones
     */
    public enum Gear
    {
        Neutral,
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Reverse
    }

    public class Ignition
    {
        private readonly EngineManagementSystem _mediator;
        private bool _on;

        public Ignition(EngineManagementSystem mediator)
        {
            _mediator = mediator;
            _on = false;

            mediator.RegisterIgnition(this);
        }

        public virtual void Start()
        {
            _on = true;
            _mediator.IgnitionTurnedOn();
            Console.WriteLine(@"Ignition ON");
        }

        public virtual void Stop()
        {
            _on = false;
            _mediator.IgnitionTurnedOff();
            Console.WriteLine(@"Ignition OFF");
        }

        public virtual bool On
        {
            get { return _on; }
        }
    }

    public class GearBox
    {
        private readonly EngineManagementSystem _mediator;
        private bool _enabled;
        private Gear _currentGear;

        public GearBox(EngineManagementSystem mediator)
        {
            _mediator = mediator;
            _enabled = false;
            _currentGear = Gear.Neutral;
            _mediator.RegisterGearBox(this);
        }

        public virtual void Enable()
        {
            _enabled = true;
            _mediator.GearBoxEnabled();
            Console.WriteLine(@"GearBox enabled");
        }

        public virtual void Disable()
        {
            _enabled = false;
            _mediator.GearBoxDisabled();
            Console.WriteLine(@"GearBox disabled");
        }

        public virtual bool Enabled
        {
            get { return _enabled; }
        }

        public virtual Gear Gear
        {
            set
            {
                if ((Enabled) && (Gear != value))
                {
                    _currentGear = value;
                    _mediator.GearChanged();
                    Console.WriteLine(@"Now in {0} gear", _currentGear);
                }
            }
            get
            {
                return _currentGear;
            }
        }
    }

    public class Accelerator
    {
        private readonly EngineManagementSystem _mediator;
        private bool _enabled;
        private int _speed;

        public Accelerator(EngineManagementSystem mediator)
        {
            _mediator = mediator;
            _enabled = false;
            _speed = 0;
            _mediator.RegisterAccelerator(this);
        }

        public virtual void Enable()
        {
            _enabled = true;
            _mediator.AcceleratorEnabled();
            Console.WriteLine(@"Accelerator enabled");
        }

        public virtual void Disable()
        {
            _enabled = false;
            _mediator.AcceleratorDisabled();
            Console.WriteLine(@"Accelerator disabled");
        }

        public virtual bool Enabled
        {
            get
            {
                return _enabled;
            }
        }

        public virtual void AccelerateToSpeed(int speed)
        {
            if (Enabled)
            {
                _speed = speed;
                Console.WriteLine(@"Speed now {0}", _speed);
            }
        }

        public virtual int Speed
        {
            get
            {
                return _speed;
            }
        }
    }

    public class Brake
    {
        private readonly EngineManagementSystem _mediator;
        private bool _enabled;
        private bool _applied;

        public Brake(EngineManagementSystem mediator)
        {
            _mediator = mediator;
            _enabled = false;
            _applied = false;
            _mediator.RegisterBrake(this);
        }

        public virtual void Enable()
        {
            _enabled = true;
            _mediator.BrakeEnabled();
            Console.WriteLine(@"Brakes enabled");
        }

        public virtual void Disable()
        {
            _enabled = true;
            _mediator.BrakeDisabled();
            Console.WriteLine(@"Brakes disabled");
        }

        public virtual bool Enabled
        {
            get { return _enabled; }
        }

        public virtual void Apply()
        {
            if (Enabled)
            {
                _applied = true;
                _mediator.BrakePressed();
                Console.WriteLine(@"Now breaking");
            }
        }

        private void Release()
        {
            if (Enabled)
            {
                _applied = false;
            }
        }
    }
    #endregion
}

