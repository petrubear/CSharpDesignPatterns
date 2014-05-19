using System;
using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Structural.Adapter
{
    /* convierte la interfaz 1 de una clase 
     * en la interfaz 2 que el cliente espera
     * 
     * util para trabajar con clases que 
     * tienen interfaces incompatibles
     * 
     * la formula general es:
     * 1. extender la clase "A" la que se queire adaptar
     * 2. agrear una referencia en el constructor de
     *      la clase "DE" la que queremos adaptar
     * 3.el constructor obtiene lo que necesita de la 
     *      referencia 2 y la pasa al constructor de la 
     *      superclase
     */
    #region External class

    public class SuperGreenEngine
    {
        public int EngineSize
        {
            get;
            private set;
        }
        public SuperGreenEngine(int engineSize)
        {
            EngineSize = engineSize;
        }
        public override string ToString()
        {
            return String.Format(@"SUPER ENGINE {0}", EngineSize);
        }
    }
    #endregion
    public class SuperGreenEngineAdapter : AbstractEngine
    {
        public SuperGreenEngineAdapter(SuperGreenEngine greenEngine) :
            base(greenEngine.EngineSize, false)
        {

        }
    }

    /* generic adapter 

    public class ObjectAdapter : ClassAdaptingTo
    {
        private ClassAdaptingFrom fromObject;

        public ObjectAdapter(ClassAdaptingFrom fromObject)
        {
            this.fromObject = fromObject;
        }
        //override methods
        public override void MethodInToClass()
        {
            fromObject.MethodInFromClass();
        }
    }
    */
}
