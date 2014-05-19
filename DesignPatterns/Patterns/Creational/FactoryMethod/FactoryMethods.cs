
using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Creational.FactoryMethod
{
    /* 
     * define una interfaz para crear un objeto
     * pero permite a sus subclases decidir
     * que clase instanciar
     */
    public abstract class VehicleFactory
    {
        public enum DrivingStyle
        {
            Economical,
            Midrange,
            Powerful
        }

        public enum Category
        {
            Car,
            Van
        }

        public virtual IVehicle Build(DrivingStyle style, VehicleColour colour)
        {
            var vehicle = SelectVehicle(style);
            vehicle.Paint(colour);
            return vehicle;
        }

        protected internal abstract IVehicle SelectVehicle(DrivingStyle style);

        public static IVehicle MakeVehicle(Category category, DrivingStyle style,
            VehicleColour colour)
        {
            return category == Category.Van
                ? new VanFactory().Build(style, colour)
                : new CarFactory().Build(style, colour);
        }
    }

    public class CarFactory : VehicleFactory
    {
        protected internal override IVehicle SelectVehicle(DrivingStyle style)
        {
            switch (style)
            {
                case DrivingStyle.Economical:
                    return new Saloon(new StandardEngine(1200));
                case DrivingStyle.Midrange:
                    return new Coupe(new StandardEngine(1800));
                case DrivingStyle.Powerful:
                    return new Sport(new TurboEngine(4000));
                default:
                    return null;
            }
        }
    }

    public class VanFactory : VehicleFactory
    {
        protected internal override IVehicle SelectVehicle(DrivingStyle style)
        {
            switch (style)
            {
                case DrivingStyle.Midrange:
                    return new BoxVan(new StandardEngine(200));
                case DrivingStyle.Powerful:
                    return new Pickup(new TurboEngine(3000));
                default:
                    return null;
            }
        }
    }
}
