using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Structural.Decorator
{
    /* 
     * permite extender funcionalidad a un objeto
     * dinamicamente sin necesidad de herencia
     */
    
    // este es el decorator!
    public abstract class AbstractVehicleOption : AbstractVehicle
    {
        // este es el decorado! 
        protected internal readonly IVehicle DecoratedVehicle;

        public AbstractVehicleOption(IVehicle vehicle) :
            base(vehicle.Engine)
        {
            DecoratedVehicle = vehicle;
        }
    }

    public class AirConditionedVehicle : AbstractVehicleOption
    {
        public AirConditionedVehicle(IVehicle vehicle) : base(vehicle)
        {
        }

        public override int Price
        {
            get { return DecoratedVehicle.Price + 600; }
        }

        public virtual int Temperature
        {
            set
            {
                //set temp
            }
        }
    }

    public class AlloyWheeledVehicle : AbstractVehicleOption
    {
        public AlloyWheeledVehicle(IVehicle vehicle) : base(vehicle)
        {
        }

        public override int Price
        {
            get { return DecoratedVehicle.Price + 250; }
        }
    }

    public class MetallicPaintedVehicle : AbstractVehicleOption
    {
        public MetallicPaintedVehicle(IVehicle vehicle) : base(vehicle)
        {
        }

        public override int Price
        {
            get { return DecoratedVehicle.Price + 750; }
        }
    }
    public class SatNavVehicle : AbstractVehicleOption
    {
        public SatNavVehicle(IVehicle vehicle)
            : base(vehicle)
        {
        }

        public override int Price
        {
            get { return DecoratedVehicle.Price + 1500; }
        }

        public virtual string Destination
        {
            set
            {
                //set destination
            }
        }
    }
}
