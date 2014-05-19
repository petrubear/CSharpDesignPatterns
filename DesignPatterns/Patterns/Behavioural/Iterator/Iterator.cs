using System.Collections.Generic;
using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Behavioural.Iterator
{
    /*
     * permite acceder a los elementos de una coleccion
     * sin exponer la representacion interna
     */
    public class CarRange
    {
        private readonly IList<IVehicle> _cars;

        public CarRange()
        {
            _cars = new List<IVehicle>
                    {
                        new Saloon(new StandardEngine(1200)),
                        new Saloon(new StandardEngine(1800)),
                        new Coupe(new StandardEngine(2000)),
                        new Sport(new TurboEngine(2200))
                    };
        }

        //expone la representacion interna (List)
        public virtual IList<IVehicle> Range
        {
            get
            {
                return _cars;
            }
        }

        //Iterator
        public virtual IEnumerator<IVehicle> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }
    }
    public class VanRange
    {
        private readonly IVehicle[] _vans;

        public VanRange()
        {
            _vans = new IVehicle[]
                    {
                        new BoxVan(new StandardEngine(1200)), 
                        new BoxVan(new StandardEngine(1800)),
                        new Pickup(new TurboEngine(2200)) 
                    };
        }

        //expone la representacion interna (Array)
        public virtual IList<IVehicle> Range
        {
            get
            {
                return _vans;
            }
        }
        //Iterator
        public virtual IEnumerator<IVehicle> GetEnumerator()
        {
            return ((IEnumerable<IVehicle>) _vans).GetEnumerator();
        }
    }
}
