using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class GetSetProperty
    {
        //Attribute 사용 선언. All : 범위 '전체'
        [AttributeUsage(AttributeTargets.All)]

        //Attribute(속성)을 계승(inherit)한 class CustomInfo
        public class CustomInfo : Attribute  // Attribute 계승 : class가 Attribute를 계승하는 방법
        {
            string m_Code, m_Name, m_Addr, m_Tel;
            int m_Age;

            public CustomInfo(String name)
            {
                this.m_Name = name;
            }

            public string p_code
            {
                get { return m_Code; }
                set { m_Code = value; }
            }
            public string p_Name
            {
                get { return m_Name; }
                set { m_Name = value; }
            }
            public string p_Addr
            {
                get { return m_Addr; }
                set { m_Addr = value; }
            }
            public string p_Tel
            {
                get { return m_Tel; }
                set { m_Tel = value; }
            }
            public int getAge()
            {
                return m_Age;
            }
            public void setAge(int age)
            {
                if (age <= 0)
                {
                    Console.WriteLine("Set Age Error! {0} 입니다. 정확히 입력하세요...", age.ToString());
                }
                else
                {
                    m_Age = age;
                }
            }
        }

        [CustomInfo("삼각형")]
        public interface IAttribute
        {
            void ConsolePrint();
        }

        [CustomInfo("이순신")]
        public class classAttribute : IAttribute
        {
            public void ConsolePrint()
            {
                Console.WriteLine("This is ClassAttribute Console Print Method!!");
            }
        }

        public class DisplayAttributes
        {
            public DisplayAttributes(Type ParamType)
            {
                Attribute[] MyAttributes = Attribute.GetCustomAttributes(ParamType);
                foreach (Attribute AttributeStart in MyAttributes)
                {
                    if (AttributeStart is CustomInfo)
                    {
                        Console.WriteLine("type : {0}", ParamType);
                        CustomInfo MyCustom = (CustomInfo)AttributeStart;

                        Console.WriteLine("고객성명 Get : {0}", MyCustom.p_Name);
                        Console.WriteLine("");
                    }
                }
            }
        }//DisplayAttributes

        class GetSetMainClass
        {
            static void Main(string[] args)
            {
                CustomInfo myCustom = new CustomInfo("홍길동");
                myCustom.p_code = "K12345";
                myCustom.setAge(27);
                Console.WriteLine("고객성명 : {0}", myCustom.p_Name);
                Console.WriteLine("고객코드 : {0}", myCustom.p_code);
                Console.WriteLine("고객나이 : {0}", myCustom.getAge());

                myCustom.setAge(0);
                Console.WriteLine("고객나이 : {0}", myCustom.getAge());

                Console.WriteLine("");
                Console.WriteLine("===클래스 DisplayAttributes에서의 출력 시작 ===");

                DisplayAttributes myCAttr = new DisplayAttributes(typeof(classAttribute));
                DisplayAttributes myIAttr = new DisplayAttributes(typeof(IAttribute));

                Console.WriteLine("===클래스 DisplayAttributes에서의 출력 끝 ===");
            }
        }
    }
}
