using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class OtherClass {
        string m_string; //기본적인 접근권한은 private가 된다. 
        
        public OtherClass(string pString)
        {
            Console.WriteLine("I'm 생성자");
            m_string = pString;     //멤버변수에 값 할당.
        }

        public void m_Display() {
            Console.WriteLine("멤버변수 m_string : {0}", m_string);
        }

        public void Msg(string msg)
        {
            Console.WriteLine("메소드 처리 메서드 ", msg);
        }

        public int CalCulate(int pVal) {
            int rtnResult = 0;
            rtnResult = 100 * pVal;
            return rtnResult + 30;
        }

        public string TodayDate() {
            DateTime today = DateTime.Now;
            string rtnDate = today.Year.ToString("0000") + "/" + today.Month.ToString("00") + "/" + today.Day.ToString("00");
            return rtnDate;
        }
    }

 
    class CallOtherClassMethod
    {
        enum Month { Janurary, Febrary, March, April, May, June, July, Argust, September, Octorber, November, December };
        enum Dept { 기획팀, 총무팀, 회계팀, 재무팀, 영업팀, 무역팀, 생산팀};

        internal void printClasses()
        {
            OtherClass callOtherCalss = new OtherClass("생성자있는클래스");
            callOtherCalss.Msg("다른 클래스 메소드 호출중...");

            int val = 100;
            int rtnVal = 0;

            Console.Write("출력 ->");
            callOtherCalss.m_Display();

            rtnVal = callOtherCalss.CalCulate(val);

            Month month = Month.Argust;
            Console.WriteLine("Month = {0}", month.ToString());
            Console.WriteLine("TodayDate = {0}", callOtherCalss.TodayDate());

        }
 
    }
}
