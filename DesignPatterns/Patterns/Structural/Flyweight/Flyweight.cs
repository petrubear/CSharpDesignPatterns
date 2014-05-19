using System.Collections.Generic;
using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Structural.Flyweight
{
    /*
     * permite instanciar objetos con el mismo estado y 
     * del mismo tipo, por medio de un pool, instanciando
     * la minima cantidad de objetos necesarios
     */

    public class EngineFlyweightFactory
    {
        private readonly IDictionary<int?, IEngine> _standardEnginePool;
        private readonly IDictionary<int?, IEngine> _turboEnginePool;

        public EngineFlyweightFactory()
        {
            _standardEnginePool = new Dictionary<int?, IEngine>();
            _turboEnginePool = new Dictionary<int?, IEngine>();
        }

        public virtual IEngine GetStandardEngine(int size)
        {
            IEngine engine;
            var found = _standardEnginePool.TryGetValue(size, out engine);
            if (found) return engine;
            engine = new StandardEngine(size);
            _standardEnginePool[size] = engine;
            return engine;
        }
        public virtual IEngine GetTurboEngine(int size)
        {
            IEngine engine;
            var found = _turboEnginePool.TryGetValue(size, out engine);
            if (found) return engine;
            engine = new StandardEngine(size);
            _turboEnginePool[size] = engine;
            return engine;
        }
    }
}
