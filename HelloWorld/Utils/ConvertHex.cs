using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    internal class ConvertHex
    {
        public string Account { get; private set; }

        public void ParseHexCode()
        {
            Console.Write("input convert text : ");
            var strRead = Console.ReadLine();

            string[] hexs = splitString(strRead, ' ');

            foreach (var h in hexs)
            {
                if(h.Equals(string.Empty)) continue;
                int hexaIntValue = Convert.ToInt32(h, 16);
                string haxaStringValue = Char.ConvertFromUtf32(hexaIntValue);
                Account += haxaStringValue;
            }
 
            Console.WriteLine("result : {0}", Account);

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey(); 
        }

        private string[] splitString(string strRead, char strTag)
        {   
            return strRead.Split(strTag);
        } 
    }
}
