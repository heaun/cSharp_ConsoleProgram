using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    internal class ObjCompare
    {
        public void ObjCompareMain()
        {
            const string strBuffer = "삼각형";
            var strCompare = string.Copy(strBuffer);

            Console.WriteLine("strBuffer / strCompare : {0} / {1}", strBuffer, strCompare);

            Console.WriteLine("if strBuffer = strCompare ? {0}", strBuffer.Equals(strCompare));

            Console.WriteLine("isEqualObject ? {0}", (object)strBuffer == (object)strCompare);
            Console.WriteLine("Object strBuffer Type ? {0}", strBuffer.GetType());
            Console.WriteLine("compare strBuffer with strBuffer ? {0}", string.Compare(strBuffer, strBuffer, StringComparison.Ordinal));

        }
    }
}
