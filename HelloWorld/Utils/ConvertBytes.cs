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
        private readonly int _maxByteSize;

        public ConvertBytes(Encoding encoding, int maxSize)
        {
            _log = new LogDisplay(this.GetType().Name);
            this._encoding = encoding;
            this._maxByteSize = maxSize;
        }

        public int GetByteSize(string param)
        {
            return _encoding.GetBytes(param).Length;
        }

        private bool IsOverSized(string param)
        {
            return GetByteSize(param) >= _maxByteSize;
        }

        private bool IsConfirmed(string response)
        {
            return response == "y" ? true : false;
        }

        private string ConvertBytesToString(byte[] datas, int startIndex, int maxSize)
        {
            string result = _encoding.GetString(datas, startIndex, maxSize);
            int length = result.Length;

            if (result[length - 1].Equals('?'))
                result = result.Substring(startIndex, length - 1);
            return result;
        }

        public void ResizeMonoData(string requestText)
        {
            try
            {
                if (!IsOverSized(requestText)) return;
                if (!IsConfirmed(_log.SetCommendRead("Continue Resizing Data ?? Y/N ", "").ToLower())) return;

                _log.Trace("Start Resizeing Data under " + _maxByteSize + " Bytes....", "");

                Byte[] datas = _encoding.GetBytes(requestText);
                string resultText = ConvertBytesToString(datas, 0, _maxByteSize);

                _log.PrintResult(_encoding, resultText, GetByteSize(resultText));
            }
            catch (Exception e)
            {
                _log.Trace(e.ToString(), "");
            }
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
