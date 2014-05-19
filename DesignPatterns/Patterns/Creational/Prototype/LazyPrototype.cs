using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Creational.Prototype
{
    /*
     * lo mismo que prototype, pero lazy
     */
    public class VehicleManagerLazy
    {
        private IVehicle _saloon;
        private IVehicle _coupe;
        private IVehicle _sport;
        private IVehicle _boxVan;
        private IVehicle _pickup;

         public virtual IVehicle CreateSaloon()
        {
             _saloon = _saloon ?? new Saloon(new StandardEngine(1200));
            return (IVehicle) _saloon.Clone();
        }
        public virtual IVehicle CreateCoupe()
        {
            _coupe = _coupe ?? new Coupe(new StandardEngine(1200));
            return (IVehicle) _coupe.Clone();
        }
        public virtual IVehicle CreateSport()
        {
            _sport = _sport ?? new Sport(new StandardEngine(1200));
            return (IVehicle) _sport.Clone();
        }
        public virtual IVehicle CreateBoxVan()
        {
            _boxVan = _boxVan ?? new BoxVan(new StandardEngine(1200));
            return (IVehicle) _boxVan.Clone();
        }
        public virtual IVehicle CreatePickup()
        {
            _pickup = _pickup ?? new Pickup(new StandardEngine(1200));
            return (IVehicle) _pickup.Clone();
        }
    }
}
