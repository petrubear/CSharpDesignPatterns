using DesignPatterns.Model;
using DesignPatterns.Patterns.Behavioural.Command;
using NUnit.Framework;

namespace DesignPatternsTest.Behavioural
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void CommandTestCase()
        {
            var radio = new Radio();
            radio.SwitchOn();
            IVoiceCommand volumeUpCommand = new VolumeUpCommand(radio);
            IVoiceCommand volumeDownCommand = new VolumeDownCommand(radio);

            var window = new ElectricWindow();
            IVoiceCommand windowUpCommand = new WindowUpCommand(window);
            IVoiceCommand windowDownCommand = new WindowDownCommand(window);

            var speechRecognizer = new SpeechRecognizer();
            //control window
            speechRecognizer.SetCommands(windowUpCommand, windowDownCommand);
            //Log
            speechRecognizer.HearDownSpoken();
            speechRecognizer.HearUpSpoken();

            //control radio
            speechRecognizer.SetCommands(volumeUpCommand, volumeDownCommand);
            //Log
            speechRecognizer.HearUpSpoken();
            speechRecognizer.HearUpSpoken();
            speechRecognizer.HearDownSpoken();

            //todo: define tests
        }
    }
}
