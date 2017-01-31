using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class DateDisplay
    {
        enum TYPE { DATETIME, DATE, TIME, DAYOFWEEK }

        public void printData(string[] args)
        {

            DateTime curDate = DateTime.Now;

            string strDate, strDate2, strDate3, strDayofWeek, strTime, strTime2, strTime3;

            strDate = curDate.Year.ToString("0000") + "/" + curDate.Month.ToString("00") + "/" + curDate.Day.ToString("00");
            strDate2 = curDate.ToShortDateString();
            strDate3 = curDate.ToLongDateString();

            strTime = curDate.Hour.ToString("00") + ":" + curDate.Minute.ToString("00") + ":" + curDate.Second.ToString("00");
            strTime2 = curDate.ToShortTimeString();
            strTime3 = curDate.ToLongTimeString();

            strDayofWeek = curDate.DayOfWeek.ToString();
            DayOfWeek strDayOfWeek1 = curDate.DayOfWeek;

            int strDayOfWeek2 = (int)curDate.DayOfWeek;

            printDateTime(TYPE.DATETIME, curDate.ToString());
            printDateTime(TYPE.DATE, strDate);
            printDateTime(TYPE.DATE, strDate2);
            printDateTime(TYPE.DATE, strDate3);
            printDateTime(TYPE.TIME, strTime);
            printDateTime(TYPE.TIME, strTime2);
            printDateTime(TYPE.TIME, strTime3);
            printDateTime(TYPE.DAYOFWEEK, strDayofWeek);
            printDateTime(TYPE.DAYOFWEEK, strDayOfWeek1.ToString());
            printDateTime(TYPE.DAYOFWEEK, strDayOfWeek2.ToString());

        }

        private void printDateTime(TYPE type, string strDate)
        {
            string strMessage = string.Empty;
            switch (type)
            {
                case TYPE.DATETIME:
                    strMessage = "날짜, 시간 --> {0}";
                    break;
                case TYPE.DATE:
                    strMessage = "날짜 --> {0}";
                    break;
                case TYPE.TIME:
                    strMessage = "시간 --> {0}";
                    break;
                case TYPE.DAYOFWEEK:
                    strMessage = "요일(Monday) --> {0}";
                    break;
            }
            Console.WriteLine(strMessage, strDate);
        }  
    }
}
