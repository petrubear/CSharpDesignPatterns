using DesignPatterns.Model;
using System;

namespace DesignPatterns.Patterns.Behavioural.Visitor
{
    /*
     * permite definir un nuevo metodo
     * sin cambiar las clases de los elementos
     * en los que opera
     */
    public interface IEngineVisitor
    {
        void Visit(Camshaft camshaft);
        void Visit(IEngine engine);
        void Visit(Piston piston);
        void Visit(SparkPlug sparkPlug);
    }

    public interface IVisitable
    {
        void AcceptEngineVisitor(IEngineVisitor visitor);
    }

    public class Camshaft : IVisitable
    {
        public void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            visitor.Visit(this);            
        }
    }
    public class Piston : IVisitable
    {
        public void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class SparkPlug : IVisitable
    {
        public void AcceptEngineVisitor(IEngineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    //implementation
    public class EngineDiagnostics : IEngineVisitor
    {
        public virtual void Visit(Camshaft camshaft)
        {
            Console.WriteLine(@"diagnosing camshaft");
        }
        public virtual void Visit(IEngine engine)
        {
            Console.WriteLine(@"diagnosing engine");
        }
        public virtual void Visit(Piston piston)
        {
            Console.WriteLine(@"diagnosing piston");
        }
        public virtual void Visit(SparkPlug sparkPlug)
        {
            Console.WriteLine(@"diagnosing sparkPlug");
        }
    }
    public class EngineInventory : IEngineVisitor
    {
        private int _camshaftCount;
        private int _pistonCount;
        private int _sparkPlugCount;

        public EngineInventory()
        {
            _camshaftCount = 0;
            _pistonCount = 0;
            _sparkPlugCount = 0;
        }
        public virtual void Visit(Camshaft camshaft)
        {
            _camshaftCount++;
        }
        public virtual void Visit(IEngine engine)
        {
            Console.WriteLine(@"Engine has {0} camshaft(s), {1} piston(s), {2} sparkPlug(s)",
                _camshaftCount, _pistonCount, _sparkPlugCount);
        }
        public virtual void Visit(Piston piston)
        {
            _pistonCount++;
        }
        public virtual void Visit(SparkPlug sparkPlug)
        {
            _sparkPlugCount++;
        }
    }
}
