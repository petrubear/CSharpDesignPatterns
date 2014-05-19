using System;
using System.Threading;
using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Structural.Proxy
{
    /* 
     * ergo proxy!
     */
    public class EngineProxy
    {
        private readonly IEngine _engine;

        public EngineProxy(int size, bool turbo)
        {
            if (turbo)
            {
                _engine = new TurboEngine(size);
            }
            else
            {
                _engine = new StandardEngine(size);
            }
        }

        public virtual int Size
        {
            get { return _engine.Size; }
        }

        public virtual bool Turbo
        {
            get { return _engine.Turbo; }
        }

        public virtual void Diagnose(IDiagnosticTool tool)
        {
            Console.WriteLine(@"new diagnose thread");
            var t = new Thread(() => RunDiagnosticTool(tool));
            t.Start();
            Console.WriteLine(@"Proxy diagnose finished.");
        }

        protected virtual void RunDiagnosticTool(IDiagnosticTool tool)
        {
            tool.RunDiagnosis(this);
        }
    }
}
