using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class ObjCompare
    {
        public static void Main(string[] args) {
            string strBuffer, strCompare;
            bool strTureFalse = false;

            strBuffer = "삼각형";
            strCompare = string.Copy(strBuffer);

            Console.WriteLine("strBuffer / strCompare : {0} / {1}", strBuffer, strCompare);

            strTureFalse = strBuffer.Equals(strCompare);
            Console.WriteLine("if strBuffer = strCompare ? {0}", strBuffer.Equals(strCompare));

            Console.WriteLine("isEqualObject ? {0}", (object)strBuffer == (object)strCompare);
            Console.WriteLine("Object strBuffer Type ? {0}", strBuffer.GetType());
            Console.WriteLine("compare strBuffer with strBuffer ? {0}", strBuffer.CompareTo(strBuffer));

        }
    }
}
