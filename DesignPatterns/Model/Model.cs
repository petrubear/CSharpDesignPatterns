using System;
using System.Threading;
using DesignPatterns.Patterns.Behavioural.Strategy;
using DesignPatterns.Patterns.Behavioural.Visitor;

namespace DesignPatterns.Model
{

    #region Engine Hierarchy

    #region Diagnostics

    public interface IDiagnosticTool
    {
        void RunDiagnosis(object obj);
    }

    public class EngineDiagnosticTool : IDiagnosticTool
    {
        public virtual void RunDiagnosis(object obj)
        {
            Console.WriteLine(@"Starting engine diagnosis for {0}",
                obj);
            Thread.Sleep(5000);
            Console.WriteLine(@"Engine Diagnosis complete");
        }
    }

    #endregion

    public interface IEngine : IVisitable
    {
        int Size { get; }
        bool Turbo { get; }
        int Power { get; }

        void Start();
        void Stop();
        void IncreasePower();
        void DecreasePower();
        void Diagnose(IDiagnosticTool tool);
    }

    public abstract class AbstractEngine : IEngine
    {
        private readonly int _size;
        private readonly bool _turbo;
        private bool _running;
        private int _power;
        private Camshaft _camshaft;
        private Piston _piston;
        private SparkPlug[] _sparkPlugs;

        protected AbstractEngine(int size, bool turbo)
        {
            _size = size;
            _turbo = turbo;
            _running = false;
            _power = 0;
            _camshaft = new Camshaft();
            _piston = new Piston();
            _sparkPlugs = new SparkPlug[]
                          {
                              new SparkPlug(), 
                              new SparkPlug(), 
                              new SparkPlug() 
                          };
        }

        public virtual void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            //visit each component
            _camshaft.AcceptEngineVisitor(visitor);
            _piston.AcceptEngineVisitor(visitor);

            foreach (var sparkPlug in _sparkPlugs)
            {
                sparkPlug.AcceptEngineVisitor(visitor);
            }

            visitor.Visit(this);
        }
        public virtual int Size
        {
            get { return _size; }
        }

        public virtual bool Turbo
        {
            get { return _turbo; }
        }

        public virtual int Power
        {
            get { return _power; }
        }

        public virtual void Start()
        {
            _running = true;
        }

        public virtual void Stop()
        {
            _running = false;
            _power = 0;
        }

        public virtual void IncreasePower()
        {
            if (_running && _power < 10) _power++;
        }

        public virtual void DecreasePower()
        {
            if (_running && _power > 0) _power--;
        }

        public void Diagnose(IDiagnosticTool tool)
        {
            tool.RunDiagnosis(this);
        }

        public override string ToString()
        {
            return String.Format(@"{0} ({1})", GetType().Name, _size);
        }
    }

    public class StandardEngine : AbstractEngine
    {
        public StandardEngine(int size)
            : base(size, false)
        {
            //not turbo
        }
    }

    public class TurboEngine : AbstractEngine
    {
        public TurboEngine(int size)
            : base(size, true)
        {
            //turbo!!
        }
    }

    #endregion

    #region Vehicle Hierarchy

    public enum VehicleColour
    {
        Unpainted,
        Blue,
        Black,
        //Green,
        //Red,
        Silver,
        //White,
        Yellow
    }

    public interface IVehicle : ICloneable
    {
        IEngine Engine { get; }
        VehicleColour Colour { get; }
        void Paint(VehicleColour colour);
        int Price { get; }
        void CleanInterior();
        void ClearExteriorBody();
        void PolishWindows();
        void TakeForTestDrive();
    }

    public abstract class AbstractVehicle : IVehicle
    {
        private readonly IEngine _engine;
        private VehicleColour _colour;

        protected AbstractVehicle(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted)
        {
            _engine = engine;
            _colour = colour;
        }

        public virtual IEngine Engine
        {
            get { return _engine; }
        }

        public virtual VehicleColour Colour
        {
            get { return _colour; }
        }

        public virtual void Paint(VehicleColour colour)
        {
            _colour = colour;
        }

        public override string ToString()
        {
            return String.Format(@"{0} [{1}, {2}] - {3:C}",
                GetType().Name, _engine, _colour, Price);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public abstract int Price { get; }

        public void CleanInterior()
        {
            Console.WriteLine(@"Cleaning Interior");
        }

        public void ClearExteriorBody()
        {
            Console.WriteLine(@"Cleaning Exterior");
        }

        public void PolishWindows()
        {
            Console.WriteLine(@"Polish Windows");
        }

        public void TakeForTestDrive()
        {
            Console.WriteLine(@"Test Drive");
        }
    }

    public abstract class AbstractCar : AbstractVehicle
    {
        private IGearboxStrategy _gearboxStrategy;
        protected AbstractCar(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted)
            : base(engine, colour)
        {
            _gearboxStrategy = new StandardGearboxStrategy();
        }

        public virtual IGearboxStrategy GearboxStrategy
        {
            set { _gearboxStrategy = value; }
            get { return _gearboxStrategy; }
        }

        public virtual int Speed
        {
            set
            {
                _gearboxStrategy.EnsureCorrectGear(Engine, value);
            }
        }
    }

    public abstract class AbstractVan : AbstractVehicle
    {
        protected AbstractVan(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted)
            : base(engine, colour)
        {
        }
    }

    public class Saloon : AbstractCar
    {
        public Saloon(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted) :
                base(engine, colour)
        {
        }

        public override int Price
        {
            get { return 6000; }
        }
    }

    public class Coupe : AbstractCar
    {
        public Coupe(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted) :
                base(engine, colour)
        {
        }

        public override int Price
        {
            get { return 7000; }
        }
    }

    public class Sport : AbstractCar
    {
        public Sport(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted) :
                base(engine, colour)
        {
        }

        public override int Price
        {
            get { return 8000; }
        }
    }

    public class BoxVan : AbstractVan
    {
        public BoxVan(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted) :
                base(engine, colour)
        {
        }

        public override int Price
        {
            get { return 9000; }
        }
    }

    public class Pickup : AbstractVan
    {
        public Pickup(IEngine engine,
            VehicleColour colour = VehicleColour.Unpainted) :
                base(engine, colour)
        {
        }

        public override int Price
        {
            get { return 10000; }
        }
    }

    #endregion

    #region Vehicle Parts

    public interface IBody
    {
        string BodyParts { get; }
    }

    public class CarBody : IBody
    {
        public virtual string BodyParts
        {
            get { return "Body Shell parts for a car"; }
        }
    }

    public class VanBody : IBody
    {
        public virtual string BodyParts
        {
            get { return "Body Shell parts for a van"; }
        }
    }

    public interface IChasis
    {
        string ChasisParts { get; }
    }

    public class CarChasis : IChasis
    {
        public virtual string ChasisParts
        {
            get { return "Chasis parts for a car"; }
        }
    }

    public class VanChasis : IChasis
    {
        public virtual string ChasisParts
        {
            get { return "Chasis parts for a van"; }
        }
    }

    public interface IGlassware
    {
        string GlasswareParts { get; }
    }

    public class CarGlassware : IGlassware
    {
        public virtual string GlasswareParts
        {
            get { return "Window glassware for a car"; }
        }
    }

    public class VanGlassware : IGlassware
    {
        public virtual string GlasswareParts
        {
            get { return "Window glassware for a van"; }
        }
    }

    #endregion

    #region Vehicle Extras

    public class Registration
    {
        private readonly IVehicle _vehicle;

        public Registration(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public virtual void AllocateLicensePlate()
        {
            Console.WriteLine(@"Allocating license plate.");
        }

        public virtual void AllocateVehicleNumber()
        {
            Console.WriteLine(@"Vehicle number.");
        }
    }

    public class Documentation
    {
        public static void PrintBrochure(IVehicle vehicle)
        {
            Console.WriteLine(@"printing brochure for: {0}",
                vehicle);
        }
    }

    public class Radio
    {
        private const int MinVolume = 0;
        private const int MaxVolume = 10;
        private const int DefaultVolume = 5;

        private bool _switchedOn;
        private int _volume;

        public Radio()
        {
            _switchedOn = false;
            _volume = DefaultVolume;
        }

        public virtual bool On
        {
            get
            {
                return _switchedOn;
            }
        }

        public virtual int Volume
        {
            get
            {
                return _volume;
            }
        }

        public virtual void SwitchOn()
        {
            _switchedOn = true;
            Console.WriteLine(@"Radio ON. volume: {0}",
                Volume);
        }

        public virtual void SwitchOff()
        {
            _switchedOn = false;
            Console.WriteLine(@"Radio OFF");
        }

        public virtual void VolumeUp()
        {
            if (!On || Volume >= MaxVolume) return;
            _volume++;
            Console.WriteLine(@"Volume UP: {0}",
                Volume);
        }

        public virtual void VolumeDown()
        {
            if (!On || Volume < MinVolume) return;
            _volume--;
            Console.WriteLine(@"Volume Down: {0}",
                Volume);
        }
    }

    public class ElectricWindow
    {
        private bool _open;

        public ElectricWindow()
        {
            _open = false;
            Console.WriteLine(@"Window is closed");
        }

        public virtual bool Open
        {
            get
            {
                return _open;
            }
        }

        public virtual bool Closed
        {
            get
            {
                return !_open;
            }
        }

        public virtual void OpenWindow()
        {
            if (!Closed) return;
            _open = true;
            Console.WriteLine(@"Window is open");
        }

        public virtual void CloseWindow()
        {
            if (!Open) return;
            _open = false;
            Console.WriteLine(@"Window is closed");
        }
    }

    #endregion
}
