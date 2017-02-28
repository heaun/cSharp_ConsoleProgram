using System;
using System.Text;

namespace HelloWorld.Utils
{
    class ConvertBytes
    {

        public bool IsStringOverByteSize(string param, Encoding encoding, int standardSize)
        {
            return GetByteCount(param, encoding) >= standardSize;
        }
  
         public int GetByteCount(string param, Encoding encoding)
        { 
            return encoding.GetBytes(param).Length;
        }

         private string ConvertBytesToString(byte[] strByte, Encoding encoding)
         {   
             return encoding.GetString(strByte);
         }

         private byte[] ConvertStringToByte(string str, Encoding encoding)
         {   
             return encoding.GetBytes(str);
         }
        public string SplitStringbyStandardSize(string param, int splitSize, Encoding encoding)
        {
            Console.WriteLine("\n--------------------------------------");
            byte[] datas = ConvertStringToByte(param, encoding);
            Console.WriteLine("datas : {0}", ConvertBytesToString(datas, encoding));
            Console.WriteLine("\n--------------------------------------");
            return encoding.GetString(datas, 0, splitSize); 
        } 
    }


}
