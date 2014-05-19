using System;
using System.Linq;

namespace DesignPatterns.Patterns.Behavioural.ChainOfResponsibility
{
    /*
     * define una cadena donde multiples clases
     * pueden procesar el requerimiento, siguiendo un
     * orden establecido - lol orden establecido!
     */
    public interface IEmailHandler
    {
        IEmailHandler NextHandler { set; }
        void ProcessHandler(string email);
    }

    public abstract class AbstractEmailHandler : IEmailHandler
    {
        private IEmailHandler _nextHandler;

        public virtual IEmailHandler NextHandler
        {
            set { _nextHandler = value; }
        }

        public void ProcessHandler(string email)
        {
            var wordFound = false;
            if (MatchingWords().Length == 0)
            {
                wordFound = true;
            }
            else
            {
                if (MatchingWords().Any(word => email.IndexOf(word, StringComparison.Ordinal) >= 0))
                {
                    wordFound = true;
                }
            }
            if (wordFound)
            {
                HandleHere(email);
            }
            else
            {
                _nextHandler.ProcessHandler(email);


            }
        }

        protected internal abstract string[] MatchingWords();
        protected internal abstract void HandleHere(string email);

        public static void Handle(string email)
        {
            IEmailHandler spam = new SpamEmailHandler();
            IEmailHandler sales = new SalesEmailHandler();
            IEmailHandler service = new ServiceEmailHandler();
            IEmailHandler manager = new ManagerEmailHandler();
            IEmailHandler general = new GeneralEnuiriesEmailHandler();

            //Set the chain
            spam.NextHandler = sales;
            sales.NextHandler = service;
            service.NextHandler = manager;
            manager.NextHandler = general;

            //processing
            spam.ProcessHandler(email);
        }
    }

    public class SpamEmailHandler : AbstractEmailHandler
    {
        protected internal override string[] MatchingWords()
        {
            return new[] {@"viagra", @"pills", @"medicines"};
        }

        protected internal override void HandleHere(string email)
        {
            Console.WriteLine(@"This is spam");
        }
    }
    public class SalesEmailHandler : AbstractEmailHandler
    {
        protected internal override string[] MatchingWords()
        {
            return new[] { @"buy", @"purcharse" };
        }

        protected internal override void HandleHere(string email)
        {
            Console.WriteLine(@"This is sales mail");
        }
    }
    public class ServiceEmailHandler : AbstractEmailHandler
    {
        protected internal override string[] MatchingWords()
        {
            return new[] { @"service", @"repair" };
        }

        protected internal override void HandleHere(string email)
        {
            Console.WriteLine(@"This is service mail");
        }
    }
    public class ManagerEmailHandler : AbstractEmailHandler
    {
        protected internal override string[] MatchingWords()
        {
            return new[] { @"complain", @"bad" };
        }

        protected internal override void HandleHere(string email)
        {
            Console.WriteLine(@"This is manager mail");
        }
    }
    public class GeneralEnuiriesEmailHandler : AbstractEmailHandler
    {
        protected internal override string[] MatchingWords()
        {
            return new string[0];
        }

        protected internal override void HandleHere(string email)
        {
            Console.WriteLine(@"This is general mail");
        }
    }
}
