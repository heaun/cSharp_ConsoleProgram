using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class MultiThread
    {
        private volatile bool _shouldStop;
        //volatile 키워드는 여러 스레드가 _shouldStop 데이터 멤버에 액세스하므로 이 멤버의 상태에 대한 최적화 가정을 하지 말아야 한다는 사실을 컴파일러에 경고로 알립니다.

        public void DoWork() {
            while (!_shouldStop) {
                Console.WriteLine("worker thread:working.....:: {0}", _shouldStop);
            }
            Console.WriteLine("worker thread: terminating gracefully! :: {0}", _shouldStop);
        }

        public void RequestStop() {

            /**
             RequestStop 메서드는 _shouldStop 데이터 멤버를 true로 할당하기만 합니다. 
             * 이 데이터 멤버는 DoWork 메서드에서 검사하므로 이는 간접적으로 DoWork가 반환되도록 하여 결과적으로 작업자 스레드가 종료됩니다. 
             * 그러나 중요한 점은 DoWork와 RequestStop이 서로 다른 스레드에서 실행된다는 사실입니다. 
             * DoWork는 작업자 스레드에서 실행되고 RequestStop은 기본 스레드에서 실행되므로 _shouldStop 데이터 멤버는 다음과 같이 volatile로 선언됩니다.
             */
            Console.WriteLine("worker thread:RequestStop..... :: {0}", _shouldStop);
            _shouldStop = true;
        } 
    }
}
