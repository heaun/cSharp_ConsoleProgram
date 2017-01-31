using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmdLine
{
    class ConsoleLineRead
    {
        public void ConsoleLineReadMain()
        {
            string strRead;
            int i = 0;
            Console.WriteLine("name -> ");
            strRead = Console.ReadLine();

            while (strRead.Length != 0) {
                i++;
                Console.WriteLine("hello {0}", strRead + "!!");
                Console.WriteLine("{0}", i.ToString() + "th");
                Console.WriteLine("exit : q");

                Console.WriteLine("input your name -> ");
                strRead = Console.ReadLine();

                if (strRead == "q")
                {
                    break;
                }
            } 
        }

        private void MsgWrite(string msg) {
            Console.WriteLine("param : " + msg); 
        }
    } 
}
