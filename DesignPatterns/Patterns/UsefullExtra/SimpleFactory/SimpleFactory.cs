using System;

namespace DesignPatterns.Patterns.UsefullExtra.SimpleFactory
{
    public abstract class Gearbox
    {
    }

    public class AutomaticGearbox : Gearbox
    {
        public AutomaticGearbox()
        {
            Console.WriteLine(@"new automatic gearbox created");
        }
    }

    public class ManualGearbox : Gearbox
    {
        public ManualGearbox()
        {
            Console.WriteLine(@"new manual gearbox created.");
        }
    }

    public class GearBoxFactory
    {
        public enum Type
        {
            Automatic, Manual
        }

        public static Gearbox Create(Type type)
        {
            if(type==Type.Automatic) return new AutomaticGearbox();
            return new ManualGearbox();
        }
    }
}
