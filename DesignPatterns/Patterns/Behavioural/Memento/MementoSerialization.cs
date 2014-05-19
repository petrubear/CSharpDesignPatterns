using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesignPatterns.Patterns.Behavioural.Memento
{
    public class SpeedometerMementoSerial
    {
        public SpeedometerMementoSerial(SpeedometerSerial speedometer)
        {
            //Serial...
            var stream = File.Open(@"spidometer.ser", FileMode.Create);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, speedometer);
            stream.Close();
        }

        public virtual SpeedometerSerial RestoreState()
        {
            //deserializar
            var stream = File.Open(@"spidometer.ser", FileMode.Open);
            var formatter = new BinaryFormatter();
            var speedometer = (SpeedometerSerial)formatter.Deserialize(stream);
            stream.Close();
            return speedometer;
        }
    }

    #region Clases para el ejemplo
    [Serializable]
    public class SpeedometerSerial
    {
        private int _currentSpeed;
        private int _previousSpeed;

        public SpeedometerSerial()
        {
            _currentSpeed = 0;
            _previousSpeed = 0;
        }

        public virtual int CurrentSpeed
        {
            set
            {
                _previousSpeed = _currentSpeed;
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
