using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class UsingArray
    {
        public void UsingArrayMain() {

            var strArray = new string[3]{"monday", "tuesday", "wednesday"};
            var strVal = "스트링";
            const int intVal = 100;

            /*
             * 변수/구조체 : call by value
             * 베열        : call by reference 
             */
            Console.WriteLine("main string 변수 : {0}", strVal);
            Console.WriteLine("main int 변수 : {0}", intVal);

            // 일반변수를 참조용으로 넘길때 ref 사용한다. 
            ArrayPrint(strArray, ref strVal, intVal);

        } 

        private static void ArrayPrint(IEnumerable<string> strArray, ref string paramString, int paramInt)
        {
            if (paramInt <= 0) throw new ArgumentOutOfRangeException("paramInt");
            var i = 0;
            Console.WriteLine("main에서 온 string 변수 : {0}", paramString);
            foreach(var a in strArray){
                Console.WriteLine("strArray[{0}] = {1}", i, a);
                i++;
            }

            paramString = "arrayPrint 값 변경";
            paramInt = 200;

            Console.WriteLine("ArrayPrint string 변수 : {0}", paramString);
            Console.WriteLine("ArrayPrint int 변수 : {0}", paramInt); 
        }
    }
}
