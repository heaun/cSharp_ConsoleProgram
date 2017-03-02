using System;
using System.Text;

namespace HelloWorld.Utils
{
    class LogDisplay
    {
        private readonly string _tag;

        public LogDisplay(string tag)
        {
            this._tag = tag;
        }

        public void Trace(string context, string detail)
        {
            Console.WriteLine("{0} {1} :: {2} {3}", DateTime.Now, _tag, context, detail);
        }

        public void PrintResult(Encoding encoding, string context, int length)
        {
            Trace(context, "");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Trace("Encoding Type > ", encoding.EncodingName);
            Trace("Size > ", length + " Bytes");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public string SetCommendRead(string title, string context)
        {
            Console.Write("{0} {1} :: {2}", DateTime.Now, title, context);
            return Console.ReadLine();
        }
    }
}
