using CmdLine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using HelloWorld.Monos;
using HelloWorld.Utils;

namespace HelloWorld
{ 
    class MainClass
    {
        private static LogDisplay _log;
        public MainClass()
        {
           
        }
        private static readonly AppSettingsReader _reader = new AppSettingsReader();
        private static void Main(string[] args) { 
            const string fileName = "TextFile1.txt";
            string projectPath = _reader.GetValue("projectPath", typeof(string)).ToString();
            const string sourcePath = @"D:\3.Source\sample\ConsoleProgram\HelloWorld\files";

            while (true) {  
                PrintLectures(); 

                var readLine = Console.ReadLine();
                //if (readLine != null) args[0] = readLine;
                var ff = new FilesFunc();
                switch (readLine)
                {
                    case "0":
                        var p = new Program();
                        p.PrintProgram(args);
                        break;
                    case "1":
                        var d = new DateDisplay();
                        d.printData(args);
                        break;
                    case "2":
                        var c = new CallOtherClassMethod();
                        c.printClasses();//what is internal?
                        break;
                    case "3":
                        var gs = new GetSetProperty.GetSetMainClass();
                        gs.PrintAttribute(args);
                        break;
                    case "4":
                        var o = new ObjCompare();
                        o.ObjCompareMain();
                        break;
                    case "5":
                        var u = new UsingArray();
                        u.UsingArrayMain();
                        break;
                    case "6":
                        var usc = new UsingStructAndClass();
                        usc.UsingStructAndClassMain();
                        break;
                    case "7":
                        var clr = new ConsoleLineRead();
                        clr.ConsoleLineReadMain();
                        break;
                    case "8":
                        var sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                        ff.ReadDirectory(projectPath);
                        ff.Read(sourceFile);
                        break;
                    case "9": 
                        ff.Write();
                         break;
                    case "10": 
                         ff.Copy();
                         break;
                    case "11": 
                         ff.Move();
                         break;
                    case "12":
                         ff.Delete();
                         break;
                    case "13":
                         MultiThreadExample();  
                         break;
                    case "14":
                         MultiSyncEventThreadExample();
                         break;
                    case "15": 
                        ConvertHex ch = new ConvertHex();
                        ch.ParseHexCode();
                        break; 
                    case "16":
                        var m = new Mono();
                        m.GetMonoDatas();
                        break;
                    case "q":
                        Console.WriteLine("end");
                        return;
                    default:
                        continue;
                }
            } 
        } 

        private static void ShowQueueContents(Queue<int> q, int count)
        { 
            lock (((ICollection)q).SyncRoot)
            {
                Console.Write("{0} : ", count);
                foreach (var item in q)
                {
                    Console.Write("{0} ", item);
                }
            }
            Console.WriteLine();
        }


        private static void MultiSyncEventThreadExample()
        {   
            var queue = new Queue<int>();
            var syncEvents = new MultiThread_SyncEvent();

            Console.WriteLine("Main Thread :: Configuring worker threads....");
            var producer = new MultiThread_SyncEvent.Producer(queue, syncEvents);
            var consumer = new MultiThread_SyncEvent.Consumer(queue, syncEvents);
            var producerThread = new Thread(producer.ThreadRun);
            var consumerThread = new Thread(consumer.ThreadRun);

            Console.WriteLine("Main Thread :: Launching producer and consumer threads....");
            producerThread.Start();
            consumerThread.Start();

            for (var i = 0; i < 4; i++) {
                Thread.Sleep(2500);
                ShowQueueContents(queue, i);
            }

            Console.WriteLine("Main Thread :: Signaling threads to terminate.....");
            syncEvents.ExitThreadEvent.Set();

            producerThread.Join();
            consumerThread.Join();
        } 

        private static void MultiThreadExample()
        {
            var mt = new MultiThread();
            var workerThread = new Thread(mt.DoWork);

            workerThread.Start();
            Console.WriteLine("Main Thread ::  Starting worker thread....");
            
            while (!workerThread.IsAlive);

            Thread.Sleep(1);
            Console.WriteLine("Main Thread :: Thread.Sleep(1) : main thread pause...");
            
            mt.RequestStop();

            workerThread.Join();
            // 이 메서드는 개체가 가리키는 스레드가 종료될 때까지 현재 스레드를 차단하거나 대기 상태로 만듭니다. 
            // 따라서 Join은 작업자 스레드가 반환되고 자체 종료될 때까지 반환되지 않습니다.
            Console.WriteLine("Main Thread :: Worker thread has terminated.");
        }

        private static void PrintLectures()
        {
            Console.Clear();
            Console.WriteLine("================== LIST ==================");
            Console.WriteLine( " case \"0\" : Program" );
            Console.WriteLine( " case \"1\" : DateDisplay");
            Console.WriteLine( " case \"2\" : CallOtherClassMethod          ");
            Console.WriteLine( " case \"3\" : GetSetProperty.GetSetMainClass");
            Console.WriteLine( " case \"4\" : ObjCompare");
            Console.WriteLine( " case \"5\" : UsingArray");
            Console.WriteLine( " case \"6\" : UsingStructAndClass ");
            Console.WriteLine( " case \"7\" : ConsoleLineRead     ");
            Console.WriteLine( " case \"8\" : FileRead ");
            Console.WriteLine( "case \"9\" : FileWrite ");
            Console.WriteLine( "case \"10\" : Filecopy ");
            Console.WriteLine( "case \"11\" : FileMove ");
            Console.WriteLine( "case \"12\" : FileDelete ");
            Console.WriteLine( "case \"13\" : Thread ");
            Console.WriteLine( "case \"14\" : Thread SyncEvent");
            Console.WriteLine( "case \"15\" : ConvertToHex");
            Console.WriteLine( " case \"q\" : exit");
            Console.WriteLine("==========================================");
            Console.WriteLine("please select Number :: ");
        } 
    }
}
