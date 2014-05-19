
using System;
using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Behavioural.Strategy
{
    /* 
     * define una familia de algoritmos, los encapsula
     * y los hace intercambiables
     */
    public interface IGearboxStrategy
    {
        void EnsureCorrectGear(IEngine engine, int speed);
    }

    public class StandardGearboxStrategy : IGearboxStrategy
    {
        public virtual void EnsureCorrectGear(IEngine engine, int speed)
        {
            var engineSize = engine.Size;
            var turbo = engine.Turbo;

            //codigo para determinar el gear bla bla
            Console.WriteLine(@"correct gear Standard box is...");
        }
    }
    public class SportGearboxStrategy : IGearboxStrategy
    {
        public virtual void EnsureCorrectGear(IEngine engine, int speed)
        {
            var engineSize = engine.Size;
            var turbo = engine.Turbo;

            //codigo para determinar el gear bla bla
            Console.WriteLine(@"correct gear Sport box is...");
        }
    }
}
