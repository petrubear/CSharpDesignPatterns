namespace DesignPatterns.Patterns.Creational.Singleton
{
    /* 
     * asegura que solamente existira 1 objeto
     * instancia de la clase, el que se devuelve
     * con un unico metodo de acceso (Instance)
     */
    public class SerialNumberGenerator
    {
        private static volatile SerialNumberGenerator _instance;
        private static readonly object SyncLock = new object();
        private int _count;
        private SerialNumberGenerator()
        {
            _count = 0;
        }
        public static SerialNumberGenerator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncLock)
                    {
                        _instance = _instance ?? new SerialNumberGenerator();
                    }
                }
                return _instance;
            }
        }
        public virtual int NextSerial
        {
            get { return ++_count; }
        }
    }
}
