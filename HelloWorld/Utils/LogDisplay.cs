using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HelloWorld.Utils
{
    class LogDisplay
    { 
        public void Trace(string title, string value, string detail)
        {   
            Console.WriteLine("{0} {1} :: {2} {3}", DateTime.Now, title, value, detail);
        }

        public void PrintResult(string title, string value, string detail)
        {
            Console.WriteLine("{0} : {1} {2}", title, value, detail);
        }


    }
}
