using System;
using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Creational.Builder
{
    /* 
     * separa la construccion de objetos complejos
     * de su representacion
     * requiere un builder y un director
     */
    #region Builder

    public abstract class VehicleBuilder
    {
        public virtual void BuildBody()
        {
        }

        public virtual void BuildBoot()
        {
        }

        public virtual void BuildChasis()
        {
        }

        public virtual void BuildPassengerArea()
        {
        }

        public virtual void BuildReinforcedStorageArea()
        {
        }

        public virtual void BuildWindows()
        {
        }

        public abstract IVehicle Vehicle { get; }
    }

    public class CarBuilder : VehicleBuilder
    {
        private readonly AbstractCar _carInProgress;

        public CarBuilder(AbstractCar car)
        {
            _carInProgress = car;
        }

        public override void BuildBody()
        {
            Console.WriteLine("building car body");
        }

        public override void BuildBoot()
        {
            Console.WriteLine("building car boot");
        }

        public override void BuildChasis()
        {
            Console.WriteLine("building car chasis");
        }

        public override void BuildPassengerArea()
        {
            Console.WriteLine("building car pasenger area");
        }

        public override void BuildWindows()
        {
            Console.WriteLine("building car windows");
        }

        public override IVehicle Vehicle
        {
            get { return _carInProgress; }
        }
    }

    public class VanBuilder : VehicleBuilder
    {
        private readonly AbstractVan _vanInProgress;

        public VanBuilder(AbstractVan van)
        {
            _vanInProgress = van;
        }

        public override void BuildBody()
        {
            Console.WriteLine("building van body");
        }

        public override void BuildChasis()
        {
            Console.WriteLine("building van chasis");
        }

        public override void BuildReinforcedStorageArea()
        {
            Console.WriteLine("building van reinforced area");
        }

        public override void BuildWindows()
        {
            Console.WriteLine("building van windows");
        }

        public override IVehicle Vehicle
        {
            get { return _vanInProgress; }
        }
    }

    #endregion

    #region Director

    public abstract class VehicleDirector
    {
        public abstract IVehicle Build(VehicleBuilder builder);
    }

    public class CarDirector : VehicleDirector
    {
        public override IVehicle Build(VehicleBuilder builder)
        {
            builder.BuildBody();
            builder.BuildBoot();
            builder.BuildChasis();
            builder.BuildPassengerArea();
            builder.BuildWindows();
            return builder.Vehicle;
        }
    }

    public class VanDirector : VehicleDirector
    {
        public override IVehicle Build(VehicleBuilder builder)
        {
            builder.BuildBody();
            builder.BuildChasis();
            builder.BuildReinforcedStorageArea();
            builder.BuildWindows();
            return builder.Vehicle;
        }
    }

    #endregion
}
