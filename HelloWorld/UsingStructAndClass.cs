using System;

namespace HelloWorld
{
    internal struct AddrStruct
    {
        public string Id;
        public string Name;
        public string Addr;
        public string Tel;
        public string Post;
        public string Hp;
        public string Remarks;
    } 

    class MyAddrListClass
    {
        public string Id;
        public string Name;
        public string Addr;
        public string Tel;
        public string Post;
        public string Hp;
        public string Remarks;
    }

    internal class UsingStructAndClass
    {
        public void UsingStructAndClassMain()
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
            var cAddrList = new MyAddrListClass
            {
                Id = "C0001",
                Name = "나나나",
                Addr = "강남구",
                Tel = "02-511-3456",
                Post = "135-789",
                Hp = "011-511-3456",
                Remarks = "클래스 구조체 사용"
            };

            /*
             * struct는 call by value 타입 (value형)
             * struct 구조체 선언 시 stack 메모리에 할당.*
             * 
             * struct 구조체명{
             * //상수멤버리스트
             * //필드멤버리스트
             * }
             */
            AddrStruct structAddr;

            structAddr.Id = "S0001";
            structAddr.Name = "너너너";
            structAddr.Addr = "역삼동";
            structAddr.Tel = "02-123-4567";
            structAddr.Post = "135-789";
            structAddr.Hp = "011-511-3456";
            structAddr.Remarks = "Struct 구조체 사용";

            Console.WriteLine("===Main() 클래스 구조체 출력(변경전)===");
            Console.WriteLine("Class주소 : {0}", cAddrList.Addr);

            Console.WriteLine("===Main() Struct 구조체 출력(변경전)===");
            Console.WriteLine("Struct주소 : {0}", structAddr.Addr);

            Console.WriteLine("=== Call AddrPrint ===");
            AddPrint(cAddrList, structAddr);

            Console.WriteLine("===Main() 클래스 구조체 출력(변경후)===");
            Console.WriteLine("Class주소 : {0}", cAddrList.Addr);

            Console.WriteLine("===Main() Struct 구조체 출력(변경후)===");
            Console.WriteLine("Struct주소 : {0}", structAddr.Addr);
            

        }

        private static void AddPrint(MyAddrListClass cAddrList, AddrStruct structAddr)
        {
            Console.WriteLine("===AddPrint() 클래스 구조체 출력 ===");
            Console.WriteLine("Class주소 : {0}", cAddrList.Addr);

            Console.WriteLine("===AddPrint() Struct 구조체 출력 ===");
            Console.WriteLine("Struct주소 : {0}", structAddr.Addr);

            cAddrList.Addr = "전북 전주시 덕진구";
            structAddr.Addr = "전북 전주시 덕진구";

        }
    } 
}
