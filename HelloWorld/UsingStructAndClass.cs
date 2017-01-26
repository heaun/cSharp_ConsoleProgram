using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    struct AddrStruct
    {
        public string ID;
        public string Name;
        public string Addr;
        public string Tel;
        public string Post;
        public string HP;
        public string Remarks;
    } 

    class MyAddrListClass
    {
        public string ID;
        public string Name;
        public string Addr;
        public string Tel;
        public string Post;
        public string HP;
        public string Remarks;
    }

    class UsingStructAndClass
    {
        public static void Main(string[] agrs)
        {
            /*
             *  class는 call by reference 타입 (참조형)
             *  class 구조체 생성 시 이는 "Heap" 메모리에 저장*
             *  
             * class 클래스명{
             * //상수멤버리스트
             * //필드멤버리스트
             * //메소드맴버
             * //속성멤버(get(), set()
             * //생성자
             * //속성자
             * }
             */
            MyAddrListClass cAddrList = new MyAddrListClass();
            cAddrList.ID = "C0001";
            cAddrList.Name = "나나나";
            cAddrList.Addr = "강남구";
            cAddrList.Tel = "02-511-3456";
            cAddrList.Post = "135-789";
            cAddrList.HP = "011-511-3456";
            cAddrList.Remarks = "클래스 구조체 사용";

            /*
             * struct는 call by value 타입 (value형)
             * struct 구조체 선언 시 stack 메모리에 할당.*
             * 
             * struct 구조체명{
             * //상수멤버리스트
             * //필드멤버리스트
             * }
             */
            AddrStruct StructAddr;

            StructAddr.ID = "S0001";
            StructAddr.Name = "너너너";
            StructAddr.Addr = "역삼동";
            StructAddr.Tel = "02-123-4567";
            StructAddr.Post = "135-789";
            StructAddr.HP = "011-511-3456";
            StructAddr.Remarks = "Struct 구조체 사용";

            Console.WriteLine("===Main() 클래스 구조체 출력(변경전)===");
            Console.WriteLine("Class주소 : {0}", cAddrList.Addr);

            Console.WriteLine("===Main() Struct 구조체 출력(변경전)===");
            Console.WriteLine("Struct주소 : {0}", StructAddr.Addr);

            Console.WriteLine("=== Call AddrPrint ===");
            AddPrint(cAddrList, StructAddr);

            Console.WriteLine("===Main() 클래스 구조체 출력(변경후)===");
            Console.WriteLine("Class주소 : {0}", cAddrList.Addr);

            Console.WriteLine("===Main() Struct 구조체 출력(변경후)===");
            Console.WriteLine("Struct주소 : {0}", StructAddr.Addr);
            

        }

        private static void AddPrint(MyAddrListClass cAddrList, AddrStruct StructAddr)
        {
            Console.WriteLine("===AddPrint() 클래스 구조체 출력 ===");
            Console.WriteLine("Class주소 : {0}", cAddrList.Addr);

            Console.WriteLine("===AddPrint() Struct 구조체 출력 ===");
            Console.WriteLine("Struct주소 : {0}", StructAddr.Addr);

            cAddrList.Addr = "전북 전주시 덕진구";
            StructAddr.Addr = "전북 전주시 덕진구";

        }
    } 
}
