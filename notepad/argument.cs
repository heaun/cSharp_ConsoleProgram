using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Argument
{
    class ArgClass
    {

        /**
         * notepad 작성
         * 파일명.cs 로 저장
         * vs command 에서 csc 파일명.cs 컴파일
         * 파일명.exe 실행파일 생성
         * 파일명.exe 파라미터 입력
         * 프로그램 실행
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
