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
        }

        public static void MsgWrite(string msg) {
            Console.WriteLine("param : " + msg); 
        }
    } 
}
