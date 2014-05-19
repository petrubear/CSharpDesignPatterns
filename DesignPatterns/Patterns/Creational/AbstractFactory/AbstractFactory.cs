using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Creational.AbstractFactory
{
    /* 
     * interfaz para crear familias de objetos
     * relacionados sin especificar la clase concreta
     * no recomendado cuando los objetos pueden cambiar 
     * por que se hace un coñazo actualizar 
     */
    public abstract class AbstractVehicleFactory
    {
        public abstract IBody CreateBody();
        public abstract IChasis CreateChasis();
        public abstract IGlassware CreateGlassware();
    }

    public class CarFactory : AbstractVehicleFactory
    {
        public override IBody CreateBody()
        {
            return new CarBody();
        }

        public override IChasis CreateChasis()
        {
            return new CarChasis();
        }

        public override IGlassware CreateGlassware()
        {
            return new CarGlassware();
        }
    }
    public class VanFactory : AbstractVehicleFactory
    {
        public override IBody CreateBody()
        {
            return new VanBody();
        }

        public override IChasis CreateChasis()
        {
            return new VanChasis();
        }

        public override IGlassware CreateGlassware()
        {
            return new VanGlassware();
        }
    }
}
