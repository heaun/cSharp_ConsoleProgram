using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld.Utils
{
    class ConvertBytes
    {
        private readonly Encoding _encoding;
        private readonly LogDisplay _log; 

        public ConvertBytes(Encoding encoding)
        {
            _log = new LogDisplay(this.GetType().Name);
            this._encoding = encoding;
        }

        public int GetByteSize(string param)
        {
            return _encoding.GetBytes(param).Length;
        }

        public bool IsOverSized(string param, int maxByteSize)
        {
            return GetByteSize(param) >= maxByteSize;
        }

        public bool IsConfirmed(string response)
        {
            return response == "y" ? true : false;
        }

        public string ConvertBytesToString(byte[] datas, int startIndex, int maxSize)
        {
            string result = _encoding.GetString(datas, startIndex, maxSize);
            int length = result.Length;

            if (result[length - 1].Equals('?'))
                result = result.Substring(startIndex, length - 1);
            return result;
        }

        private string SubstringH(string source, int start, int length)
        {
            if (source.Length == 0)
                return string.Empty;

            byte[] l_str;
            l_str = System.Text.Encoding.GetEncoding("korean").GetBytes(source);

            if (l_str.Length < length)
                length = l_str.Length;
            if (length == 0)
            {
                string text = System.Text.Encoding.GetEncoding("korean").GetString(l_str, start, l_str.Length - start);
                if (text.Substring(text.Length - 1, 1) == "?")
                    text = System.Text.Encoding.GetEncoding("korean").GetString(l_str, start, l_str.Length - start - 1);

                return text;
            }
            else
            {
                string text = System.Text.Encoding.GetEncoding("korean").GetString(l_str, start, length);
                if (text.Substring(text.Length - 1, 1) == "?")
                    text = System.Text.Encoding.GetEncoding("korean").GetString(l_str, start, length - 1);

                return text;
            }
        }
    }
}
