using System;
using System.Reflection;

namespace HelloWorld
{
    internal class GetSetProperty
    {
        //Attribute 사용 선언. All : 범위 '전체'
        [AttributeUsage(AttributeTargets.All)]

        //Attribute(속성)을 계승(inherit)한 class CustomInfo
        public class CustomInfo : Attribute  // Attribute 계승 : class가 Attribute를 계승하는 방법
        {
            private int _mAge;

            public CustomInfo(string name)
            {
                PName = name;
            }

            public string PCode { get; set; }

            public string PName { get; set; }

            public string PAddr { get; set; }

            public string PTel { get; set; }

            public int GetAge()
            {
                return _mAge;
            }
            public void SetAge(int age)
            {
                if (age <= 0)
                {
                    Console.WriteLine("Set Age Error! {0} 입니다. 정확히 입력하세요...", age.ToString());
                }
                else
                {
                    _mAge = age;
                }
            }
        }

        [CustomInfo("삼각형")]
        public interface IAttribute
        {
            void ConsolePrint();
        }

        [CustomInfo("이순신")]
        public class ClassAttribute : IAttribute
        {
            public void ConsolePrint()
            {
                Console.WriteLine("This is ClassAttribute Console Print Method!!");
            }
        }

        public class DisplayAttributes
        {
            public DisplayAttributes(MemberInfo paramType)
            {
                var myAttributes = Attribute.GetCustomAttributes(paramType);
                foreach (var attributeStart in myAttributes)
                {
                    var info = attributeStart as CustomInfo;
                    if (info == null) continue;
                    Console.WriteLine("type : {0}", paramType);
                    var myCustom = info;

                    Console.WriteLine("고객성명 Get : {0}", myCustom.PName);
                    Console.WriteLine("");
                }
            }
        }//DisplayAttributes

        public class GetSetMainClass
        {
            internal void PrintAttribute(string[] args)
            {
                var myCustom = new CustomInfo("홍길동") {PCode = "K12345"};
                myCustom.SetAge(27);
                Console.WriteLine("고객성명 : {0}", myCustom.PName);
                Console.WriteLine("고객코드 : {0}", myCustom.PCode);
                Console.WriteLine("고객나이 : {0}", myCustom.GetAge());

                myCustom.SetAge(0);
                Console.WriteLine("고객나이 : {0}", myCustom.GetAge());

                Console.WriteLine("");
                Console.WriteLine("===클래스 DisplayAttributes에서의 출력 시작 ===");

                var myCAttr = new DisplayAttributes(typeof(ClassAttribute));
                var myIAttr = new DisplayAttributes(typeof(IAttribute));

                Console.WriteLine("===클래스 DisplayAttributes에서의 출력 끝 ===");
            }
        }

       
    }
}
