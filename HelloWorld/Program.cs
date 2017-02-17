using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    internal class Program
    {
        public void PrintProgram(string[] args)
        {
            Console.WriteLine("hello:) Main() ");
            const string strMsg = "string messag";
            MsgWrite(strMsg);

            if (args.Length != 0)
            {
                Console.WriteLine("hello? {0} !! ", args[0]);
            }
            else
            {
                Console.WriteLine("please write your name... ");
            }
        }
        private static void MsgWrite(string msg) {
            Console.WriteLine("param : " + msg); 
        }
    } 
}
