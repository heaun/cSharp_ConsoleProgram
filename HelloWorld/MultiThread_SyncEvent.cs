using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HelloWorld
{
    class MultiThread_SyncEvent
    {
        //lock 키워드를 사용하여 큐에 동시에 액세스하지 못하도록 방지할 뿐만 아니라 두 가지 이벤트 개체를 통해 추가로 동기화를 제공합니다.
        public MultiThread_SyncEvent() {
            /**
             * AutoResetEvent   : "새 항목" 이벤트로 사용. 소비자 스레드가 이 이벤트에 응답할 때마다 이 이벤트가 자동으로 다시 설정되도록 할 수 있다. 
             * ManualResetEvent : "종료" 이벤트로 사용. 이 이벤트가 신호를 받을 때 여러 스레드가 응답하도록 할 수 잇다. 
             */
            
            /* */
            _newItemEvent = new AutoResetEvent(false);
            _exitThreadEvent = new ManualResetEvent(false);
            
            _eventArray = new WaitHandle[2];
            _eventArray[0] = _newItemEvent;
            _eventArray[1] = _exitThreadEvent;
        }

        public EventWaitHandle ExitThreadEvent {
            get { return _exitThreadEvent; }
        }
        public EventWaitHandle NewItemEvent {
            get { return _newItemEvent; }
        }
        public WaitHandle[] EventArray {
            get { return _eventArray; }
        }

        private EventWaitHandle _newItemEvent;
        private EventWaitHandle _exitThreadEvent;
        private WaitHandle[] _eventArray;

        public class Producer{
            public Producer(Queue<int> q, MultiThread_SyncEvent e){
                _queue = q;
                _syncEvents = e;
            }
            public void ThreadRun()
        {
            /*
             * "스레드종료" 이벤트가 신호를 받을 때까지 반복.
             * WaitOne(즉신반환, 신호받음유무)으로 테스트 한다.*
             * 소비자 스레드와 기본 스레드가 컬렉션에 동시에 엑서스하지 못하도록 새항목을 추가하기 전에 컬렉션을 잠군다  : lock 키워드 
             * lock에 전달되는 인수는 ICollection인터페이스를 통해 노출되는 SyncRoot 필드. 
             * SyncRoot : 스레드 액서스를 동기화 하기 위해 제공된다. 
             */
            var count = 0;
            var r = new Random();

            while (!_syncEvents.ExitThreadEvent.WaitOne(0, false)) {
                lock (((ICollection)_queue).SyncRoot) {
                    while (_queue.Count < 20) {
                        var inputValue = r.Next(0, 100);
                        //Console.WriteLine("Producer thread : _queue Count :: {0} Enqueue :: {1}", _queue.Count, inputValue);
                        _queue.Enqueue(inputValue);
                        _syncEvents.NewItemEvent.Set();
                        count++;
                    }
                }
            }
            Console.WriteLine("Producer thread : produced {0} items", count);
        }  
            private Queue<int> _queue;
            private MultiThread_SyncEvent _syncEvents;
        }

        public class Consumer
        {
            public Consumer(Queue<int> q, MultiThread_SyncEvent e)
            {
                _queue = q;
                _syncEvents = e;
            }
            public void ThreadRun()
            {
                /*
                 * 제공된 배열의 대기 핸들에 신호가 전달될 때까지 WaitAny를 사용하여 소비자 스레드를 차단한다. 
                 * 1. 작업자 스레드를 종료하기 위한 것
                 * 2. 새 항목이 컬렉션에 추가되었음을 나타내기 위한 것. 
                 * 
                 * WaitAny : 신호를 받은 이벤트의 인덱스를 반환. ( 인덱스 1 : 스레드 종료, 인덱스 0 :  새 항목)
                 * 새항목이벤트가 전달되면 lock을 사용하여 컬렉션에 단독 엑세스하고 새 항목을 사용할 수 있다. 
                 */
                var count = 0;

                while (WaitHandle.WaitAny(_syncEvents.EventArray) != 1)
                {
                    lock (((ICollection)_queue).SyncRoot)
                    {
                        var item = _queue.Dequeue();
                    }
                    count++;
                }
                Console.WriteLine("Consumer thread : consumed {0} items", count);
            }
            private Queue<int> _queue;
            private MultiThread_SyncEvent _syncEvents; 
        } 
    }
}
