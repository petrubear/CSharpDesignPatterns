
namespace DesignPatterns.Patterns.Behavioural.Memento
{
    /* permite capturar el estado de un objeto
     * para poder ser restaurado a ese estado luego
     */
    public class SpeedometerMemento
    {
        private readonly Speedometer _speedometer;
        private readonly int _copyOfCurrentSpeed;
        private readonly int _copyOfPreviousSpeed;

        public SpeedometerMemento(Speedometer speedometer)
        {
            _speedometer = speedometer;
            _copyOfCurrentSpeed = speedometer.CurrentSpeed;
            _copyOfPreviousSpeed = speedometer.previousSpeed;
        }

        public virtual void RestoreState()
        {
            _speedometer.CurrentSpeed = _copyOfCurrentSpeed;
            _speedometer.previousSpeed = _copyOfPreviousSpeed;
        }
    }

    #region Clases para el ejemplo

    public class Speedometer
    {
        private int _currentSpeed;
        internal int previousSpeed;

        public Speedometer()
        {
            _currentSpeed = 0;
            previousSpeed = 0;
        }

        public virtual int CurrentSpeed
        {
            set
            {
                previousSpeed = _currentSpeed;
                _currentSpeed = value;
            }
            get
            {
                return _currentSpeed;
            }
        }
    }
    #endregion
}
