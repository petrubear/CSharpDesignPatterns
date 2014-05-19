using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Behavioural.Command
{
    /* command & conquer */
    public interface IVoiceCommand
    {
        void Execute();
        void Undo();
    }
    public class VolumeUpCommand : IVoiceCommand
    {
        private readonly Radio _radio;

        public VolumeUpCommand(Radio radio)
        {
            _radio = radio;
        }
        public void Execute()
        {
            _radio.VolumeUp();
        }

        public void Undo()
        {
            _radio.VolumeDown();
        }
    }
    public class VolumeDownCommand : IVoiceCommand
    {
        private readonly Radio _radio;

        public VolumeDownCommand(Radio radio)
        {
            _radio = radio;
        }
        public void Execute()
        {
            _radio.VolumeDown();
        }
        public void Undo()
        {
            _radio.VolumeUp();
        }
    }
    public class WindowUpCommand : IVoiceCommand
    {
        private readonly ElectricWindow _window;

        public WindowUpCommand(ElectricWindow window)
        {
            _window = window;
        }
        public void Execute()
        {
            _window.CloseWindow();
        }
        public void Undo()
        {
            _window.OpenWindow();
        }
    }
    public class WindowDownCommand : IVoiceCommand
    {
        private readonly ElectricWindow _window;

        public WindowDownCommand(ElectricWindow window)
        {
            _window = window;
        }
        public void Execute()
        {
            _window.OpenWindow();
        }
        public void Undo()
        {
            _window.CloseWindow();
        }
    }

    public class SpeechRecognizer
    {
        private IVoiceCommand _upCommand, _downCommand;

        public virtual void SetCommands(IVoiceCommand upCommand,
            IVoiceCommand downCommand)
        {
            _upCommand = upCommand;
            _downCommand = downCommand;
        }

        public virtual void HearUpSpoken()
        {
            _upCommand.Execute();
        }
        public virtual void HearDownSpoken()
        {
            _downCommand.Execute();
        }
    }
}
