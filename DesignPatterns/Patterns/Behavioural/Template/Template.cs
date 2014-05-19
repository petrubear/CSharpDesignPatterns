using System;

namespace DesignPatterns.Patterns.Behavioural.Template
{
    /*
     * permite a subclases redefinir ciertas 
     * partes de un algoritmo sin cambiar su estructura
     */

    public abstract class AbstractBookletPrinter
    {
        protected internal abstract int PageCount { get; }
        protected internal abstract void PrintFrontCover();
        protected internal abstract void PrintTableOfContents();
        protected internal abstract void PrintPage(int pageNumber);
        protected internal abstract void PrintIndex();
        protected internal abstract void PrintBackCover();

        public void Print()
        {
            PrintFrontCover();
            PrintTableOfContents();
            for (var i = 1; i <= PageCount; i++)
            {
                PrintPage(i);
            }
            PrintIndex();
            PrintBackCover();
        }
    }

    public class SaloonBooklet : AbstractBookletPrinter
    {
        protected internal override int PageCount
        {
            get { return 100; }
        }

        protected internal override void PrintFrontCover()
        {
            Console.WriteLine(@"Saloon front cover");
        }

        protected internal override void PrintTableOfContents()
        {
            Console.WriteLine(@"Saloon TOC");
        }

        protected internal override void PrintPage(int pageNumber)
        {
            Console.WriteLine(@"Saloon page {0}", pageNumber);
        }

        protected internal override void PrintIndex()
        {
            Console.WriteLine(@"Saloon index");
        }

        protected internal override void PrintBackCover()
        {
            Console.WriteLine(@"Saloon back cover");
        }
    }
    public class ServiceHistoryBooklet : AbstractBookletPrinter
    {
        protected internal override int PageCount
        {
            get { return 12; }
        }

        protected internal override void PrintFrontCover()
        {
            Console.WriteLine(@"Service history front cover");
        }

        protected internal override void PrintTableOfContents()
        {
            Console.WriteLine(@"Service history TOC");
        }

        protected internal override void PrintPage(int pageNumber)
        {
            Console.WriteLine(@"Service history page {0}", pageNumber);
        }

        protected internal override void PrintIndex()
        {
            Console.WriteLine(@"Service history index");
        }

        protected internal override void PrintBackCover()
        {
            Console.WriteLine(@"Service history back cover");
        }
    }
}
