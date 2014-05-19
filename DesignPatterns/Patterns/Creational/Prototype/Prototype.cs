using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Creational.Prototype
{
    /* 
     * especifica los tipos de objeto que se
     * pueden crear con una instancia prototipo
     * 
     * los nuevos objetos se crean clonando 
     * el prototipo correspondiente
     */
    public class VehicleManager
    {
        private readonly IVehicle _saloon;
        private readonly IVehicle _coupe;
        private readonly IVehicle _sport;
        private readonly IVehicle _boxVan;
        private readonly IVehicle _pickup;

        public VehicleManager()
        {
            _saloon = new Saloon(new StandardEngine(1200));
            _coupe = new Coupe(new StandardEngine(1200));
            _sport = new Sport(new StandardEngine(1200));
            _boxVan = new BoxVan(new StandardEngine(1200));
            _pickup = new Pickup(new StandardEngine(1200));
        }

        public virtual IVehicle CreateSaloon()
        {
            return (IVehicle) _saloon.Clone();
        }
        public virtual IVehicle CreateCoupe()
        {
            return (IVehicle) _coupe.Clone();
        }
        public virtual IVehicle CreateSport()
        {
            return (IVehicle) _sport.Clone();
        }
        public virtual IVehicle CreateBoxVan()
        {
            return (IVehicle) _boxVan.Clone();
        }
        public virtual IVehicle CreatePickup()
        {
            return (IVehicle) _pickup.Clone();
        }
    }
}
