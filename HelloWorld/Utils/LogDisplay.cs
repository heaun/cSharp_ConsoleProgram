using System;
using System.Text;
using System.Threading;

namespace HelloWorld.Utils
{
    class LogDisplay
    {
        private readonly string _tag;

        public LogDisplay(string tag)
        {
            this._tag = tag;
        }


        public void Trace(string context, string detail, Boolean flag)
        {   
            Console.WriteLine("{0} {1} :: {2} {3}", DateTime.Now, _tag, context, detail);
            if (flag) GridProgressBar(context);
        }

        public void Trace(string context, string detail)
        {
            Console.WriteLine("{0} {1} :: {2} {3}", DateTime.Now, _tag, context, detail);
        }

        public void Trace(string context)
        {
            Console.WriteLine("{0} {1} :: {2}", DateTime.Now, _tag, context);
        }

        public void PrintResult(Encoding encoding, string context, int length)
        {
            Trace(context, "");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Trace("Encoding Type > ", encoding.EncodingName);
            Trace("Size > ", length + " Bytes");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public void PrintProcessDone(string context)
        {
            Trace(context,null);
            Console.WriteLine("================================================================");
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey(); 
        }

        public string SetCommendRead(string title, string context)
        {
            Console.Write("{0} {1} :: {2}", DateTime.Now, title, context);
            return Console.ReadLine();
        } 

        public void GridProgressBar(string context)
        {
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }
            Trace("Done.");
        } 
    }
}
