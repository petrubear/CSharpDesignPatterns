using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Structural.Bridge
{
    /* 
     * under the bridge, separa la abstraccion de la implementacion
     * con jerarquias distintas pero conectadas
     * que pueden variar independientemente
     */
    //DriverControls, conectado a IEngine
    public class AbstractDriverControls
    {
        private IEngine engine;

        protected AbstractDriverControls(IEngine engine)
        {
            this.engine = engine;
        }

        public virtual void IgnitionOn()
        {
            engine.Start();
        }

        public virtual void IgnitionOff()
        {
            engine.Stop();
        }

        public virtual void Accelerate()
        {
            engine.IncreasePower();
        }

        public virtual void Brake()
        {
            engine.DecreasePower();
        }
    }

    public class StandardControls : AbstractDriverControls
    {
        public StandardControls(IEngine engine) :
            base(engine)
        {
        }
    }

    public class SportControls : AbstractDriverControls
    {
        public SportControls(IEngine engine) : base(engine)
        {
        }
        /* AccelerateHard se implementa con la Abstraccion
         * de DriverControls, no con la implementacion de IEngine
         * se puede modificar la implementacion de Engine, sin afectar
         * a DriverControl - Bridge
         */ 
        public virtual void AccelerateHard()
        {
            Accelerate();
            Accelerate();
        }
    }
}
