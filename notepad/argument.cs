using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Argument
{
    class ArgClass
    {

        /**
         * notepad �ۼ�
         * ���ϸ�.cs �� ����
         * vs command ���� csc ���ϸ�.cs ������
         * ���ϸ�.exe �������� ����
         * ���ϸ�.exe �Ķ���� �Է�
         * ���α׷� ����
         */

        static void Main(string[] args)
        {
            Console.WriteLine("hello:) Main() ");
            string strMsg = "string messag";
            Argument.ArgClass.MsgWrite(strMsg);

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
