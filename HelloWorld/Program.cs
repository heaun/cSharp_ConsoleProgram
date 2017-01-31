using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        public void printProgram(string[] args)
        {
            Console.WriteLine("hello:) Main() ");
            string strMsg = "string messag";
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
        private void MsgWrite(string msg) {
            Console.WriteLine("param : " + msg); 
        }
    } 
}
