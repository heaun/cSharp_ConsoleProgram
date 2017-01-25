using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello:) Main() ");
            string strMsg = "string messag";
            HelloWorld.Program.MsgWrite(strMsg);

            if (args.Length != 0)
            {
                Console.WriteLine("hello? {0} !! ", args[0]);
            }
            else
            {
                Console.WriteLine("please write your name... ");
            }

        }

        public static void MsgWrite(string msg) {
            Console.WriteLine("param : " + msg); 
        }
    } 
}
