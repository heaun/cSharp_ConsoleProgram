using CmdLine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 

namespace HelloWorld
{ 
    class MainClass
    {
        enum LIST { Program, DateDisplay, CallOtherClassMethod, GetSetProperty, ObjCompare, UsingArray, UsingStructAndClass, ConsoleLineRead,
       FileRead }

  
        static void Main(string[] args) {

            string fileName = "TextFile1.txt";
            string projectPath = @"D:\3.Source\ConsoleProgram\HelloWorld";
            string sourcePath = @"D:\3.Source\ConsoleProgram\HelloWorld\files";
            string sourceFile = string.Empty;
            string destFile = string.Empty; 

             while (true) {  
                printLectures(); 
                string strRead = Console.ReadLine(); 
                FilesFunc ff = new FilesFunc();
                switch (strRead)
                {
                    case "0":
                        Program p = new Program();
                        p.printProgram(args);
                        break;
                    case "1":
                        DateDisplay d = new DateDisplay();
                        d.printData(args);
                        break;
                    case "2":
                        CallOtherClassMethod c = new CallOtherClassMethod();
                        c.printClasses();//what is internal?
                        break;
                    case "3":
                        GetSetProperty.GetSetMainClass gs = new GetSetProperty.GetSetMainClass();
                        gs.printAttribute(args);
                        break;
                    case "4":
                        ObjCompare o = new ObjCompare();
                        o.ObjCompareMain();
                        break;
                    case "5":
                        UsingArray u = new UsingArray();
                        u.UsingArrayMain();
                        break;
                    case "6":
                        UsingStructAndClass usc = new UsingStructAndClass();
                        usc.UsingStructAndClassMain();
                        break;
                    case "7":
                        ConsoleLineRead clr = new ConsoleLineRead();
                        clr.ConsoleLineReadMain();
                        break;
                    case "8":
                        sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                        ff.ReadDirectory(projectPath);
                        ff.ReadFile(sourceFile);
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
                    case "q":
                        Console.WriteLine("end");
                        return;
                    default:
                        continue;
                }
            } 
        }

        private static void ShowQueueContents(Queue<int> q, int Count)
        { 
            lock (((ICollection)q).SyncRoot)
            {
                Console.Write("{0} : ", Count);
                foreach (int item in q)
                {
                    Console.Write("{0} ", item);
                }
            }
            Console.WriteLine();
        }


        private static void MultiSyncEventThreadExample()
        {   
            Queue<int> queue = new Queue<int>();
            MultiThread_SyncEvent syncEvents = new MultiThread_SyncEvent();

            Console.WriteLine("Main Thread :: Configuring worker threads....");
            MultiThread_SyncEvent.Producer producer = new MultiThread_SyncEvent.Producer(queue, syncEvents);
            MultiThread_SyncEvent.Consumer consumer = new MultiThread_SyncEvent.Consumer(queue, syncEvents);
            Thread producerThread = new Thread(producer.ThreadRun);
            Thread consumerThread = new Thread(consumer.ThreadRun);

            Console.WriteLine("Main Thread :: Launching producer and consumer threads....");
            producerThread.Start();
            consumerThread.Start();

            for (int i = 0; i < 4; i++) {
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
            MultiThread mt = new MultiThread();
            Thread workerThread = new Thread(mt.DoWork);

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

        private static void printLectures()
        {
            string tab = "\t\t\t\t\t\t\t";  
            Console.WriteLine("\n"+ tab+"================== LIST ==================");
                Console.WriteLine(tab+ " case \"0\" : Program" );
                Console.WriteLine(tab+ " case \"1\" : DateDisplay");
                Console.WriteLine(tab+ " case \"2\" : CallOtherClassMethod          ");
                Console.WriteLine(tab+ " case \"3\" : GetSetProperty.GetSetMainClass");
                Console.WriteLine(tab+ " case \"4\" : ObjCompare");
                Console.WriteLine(tab+ " case \"5\" : UsingArray");
                Console.WriteLine(tab+ " case \"6\" : UsingStructAndClass ");
                Console.WriteLine(tab+ " case \"7\" : ConsoleLineRead     ");
                Console.WriteLine(tab+ " case \"8\" : FileRead ");
                Console.WriteLine(tab + "case \"9\" : FileWrite ");
                Console.WriteLine(tab + "case \"10\" : Filecopy ");
                Console.WriteLine(tab + "case \"11\" : FileMove ");
                Console.WriteLine(tab + "case \"12\" : FileDelete ");
                Console.WriteLine(tab + "case \"13\" : Thread ");
                Console.WriteLine(tab + "case \"14\" : Thread SyncEvent");
                Console.WriteLine(tab+ " case \"q\" : exit");
            Console.WriteLine(tab+"==========================================");
            Console.WriteLine(tab+"please select Number :: ");
        } 
    }
}
