
using System;

namespace DesignPatterns.Patterns.Behavioural.State
{
    /* 
     * permite a un objecto alterar su comportamiento
     * cuando su estado interno cambia. El objeto
     * aparentaria modificar su clase
     */
    public interface IClockSetupState
    {
        void PreviousValue();
        void NextValue();
        void SelectValue();

        string Instructions { get; }
        int SelectedValue { get; }
    }

    //Context!
    public class ClockSetup
    {
        private readonly IClockSetupState _yearSetupState;
        private readonly IClockSetupState _monthSetupState;
        private readonly IClockSetupState _daySetupState;
        private readonly IClockSetupState _hourSetupState;
        private readonly IClockSetupState _minuteSetupState;
        private readonly IClockSetupState _finishedSetupState;
        private IClockSetupState _currentState;

        public ClockSetup()
        {
            _yearSetupState = new YearSetupState(this);
            _monthSetupState = new MonthSetupState(this);
            _daySetupState = new DaySetupState(this);
            _hourSetupState = new HourSetupState(this);
            _minuteSetupState = new MinuteSetupState(this);
            _finishedSetupState = new FinishedSetupState(this);

            _currentState = _yearSetupState;
        }

        public virtual IClockSetupState State
        {
            set
            {
                _currentState = value;
                Console.WriteLine(_currentState.Instructions);
            }
        }

        public IClockSetupState YearSetupState
        {
            get { return _yearSetupState; }
        }

        public IClockSetupState MonthSetupState
        {
            get { return _monthSetupState; }
        }

        public IClockSetupState DaySetupState
        {
            get { return _daySetupState; }
        }

        public IClockSetupState HourSetupState
        {
            get { return _hourSetupState; }
        }

        public IClockSetupState MinuteSetupState
        {
            get { return _minuteSetupState; }
        }

        public IClockSetupState FinishedSetupState
        {
            get { return _finishedSetupState; }
        }

        public virtual void RotateKnobLeft()
        {
            _currentState.PreviousValue();
        }
        public virtual void RotateKnobRight()
        {
            _currentState.NextValue();
        }
        public virtual void PushKnob()
        {
            _currentState.SelectValue();
        }

        public virtual DateTime SelectedDate
        {
            get
            {
                return new DateTime(_yearSetupState.SelectedValue,
                    _monthSetupState.SelectedValue, _daySetupState.SelectedValue,
                    _hourSetupState.SelectedValue, _minuteSetupState.SelectedValue, 0);
            }
        }
    }

    #region States
    public class YearSetupState : IClockSetupState
    {
        private ClockSetup _clockSetup;
        private int _year;

        public YearSetupState(ClockSetup clockSetup)
        {
            _clockSetup = clockSetup;
            _year = DateTime.Now.Year;
        }

        public virtual void PreviousValue()
        {
            _year--;
        }

        public virtual void NextValue()
        {
            _year++;
        }

        public virtual void SelectValue()
        {
            Console.WriteLine(@"Year: {0}", _year);
            _clockSetup.State = _clockSetup.MonthSetupState;
        }

        public virtual string Instructions
        {
            get
            {
                return @"Please set year...";
            }
        }
        public virtual int SelectedValue
        {
            get
            {
                return _year;
            }
        }
    }
    public class MonthSetupState : IClockSetupState
    {
        private ClockSetup _clockSetup;
        private int _month;

        public MonthSetupState(ClockSetup clockSetup)
        {
            _clockSetup = clockSetup;
            _month = DateTime.Now.Month;
        }

        public virtual void PreviousValue()
        {
            if (_month > 1) _month--;
            else _month = 12;
        }

        public virtual void NextValue()
        {
            if (_month < 12) _month++;
            else _month = 1;
        }

        public virtual void SelectValue()
        {
            Console.WriteLine(@"Month: {0}", _month);
            _clockSetup.State = _clockSetup.DaySetupState;
        }

        public virtual string Instructions
        {
            get
            {
                return @"Please set month...";
            }
        }
        public virtual int SelectedValue
        {
            get
            {
                return _month;
            }
        }
    }
    public class DaySetupState : IClockSetupState
    {
        private ClockSetup _clockSetup;
        private int _day;

        public DaySetupState(ClockSetup clockSetup)
        {
            _clockSetup = clockSetup;
            _day = DateTime.Now.Day;
        }

        public virtual void PreviousValue()
        {
            if (_day > 1) _day--;
            else
            {
                var today = DateTime.Now;
                _day = DateTime.DaysInMonth(today.Year, today.Month);
            }
        }

        public virtual void NextValue()
        {
            var today = DateTime.Now;
            if (_day < DateTime.DaysInMonth(today.Year, today.Month))
            {
                _day++;
            }
            else
            {
                _day = 1;
            }

        }

        public virtual void SelectValue()
        {
            Console.WriteLine(@"Day: {0}", _day);
            _clockSetup.State = _clockSetup.HourSetupState;
        }

        public virtual string Instructions
        {
            get
            {
                return @"Please set day...";
            }
        }
        public virtual int SelectedValue
        {
            get
            {
                return _day;
            }
        }
    }
    public class HourSetupState : IClockSetupState
    {
        private ClockSetup _clockSetup;
        private int _hour;

        public HourSetupState(ClockSetup clockSetup)
        {
            _clockSetup = clockSetup;
            _hour = DateTime.Now.Hour;
        }

        public virtual void PreviousValue()
        {
            if (_hour > 0) _hour--;
            else _hour = 23;
        }

        public virtual void NextValue()
        {
            if (_hour < 23) _hour++;
            else _hour = 0;
        }

        public virtual void SelectValue()
        {
            Console.WriteLine(@"Hour: {0}", _hour);
            _clockSetup.State = _clockSetup.MinuteSetupState;
        }

        public virtual string Instructions
        {
            get
            {
                return @"Please set hour...";
            }
        }
        public virtual int SelectedValue
        {
            get
            {
                return _hour;
            }
        }
    }
    public class MinuteSetupState : IClockSetupState
    {
        private ClockSetup _clockSetup;
        private int _minute;

        public MinuteSetupState(ClockSetup clockSetup)
        {
            _clockSetup = clockSetup;
            _minute = DateTime.Now.Minute;
        }

        public virtual void PreviousValue()
        {
            if (_minute > 0) _minute--;
            else _minute = 59;
        }

        public virtual void NextValue()
        {
            if (_minute < 59) _minute++;
            else _minute = 0;
        }

        public virtual void SelectValue()
        {
            Console.WriteLine(@"Minute: {0}", _minute);
            _clockSetup.State = _clockSetup.FinishedSetupState;
        }

        public virtual string Instructions
        {
            get
            {
                return @"Please set minutes...";
            }
        }
        public virtual int SelectedValue
        {
            get
            {
                return _minute;
            }
        }
    }
    public class FinishedSetupState : IClockSetupState
    {
        private ClockSetup _clockSetup;

        public FinishedSetupState(ClockSetup clockSetup)
        {
            _clockSetup = clockSetup;
        }

        public virtual void PreviousValue()
        {
            Console.WriteLine(@"Ignored...");
        }

        public virtual void NextValue()
        {
            Console.WriteLine(@"Ignored...");
        }

        public virtual void SelectValue()
        {
            var selectedDate = _clockSetup.SelectedDate;
            Console.WriteLine(@"Date set to: {0}", selectedDate);
        }

        public virtual string Instructions
        {
            get
            {
                return @"Press knob to view selected date...";
            }
        }
        public virtual int SelectedValue
        {
            get
            {
                throw new NotSupportedException("Clock setup finished");
            }
        }
    }
    #endregion
}
