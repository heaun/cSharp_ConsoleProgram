using CmdLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{ 
    class MainClass
    {
        enum LIST { Program, DateDisplay, CallOtherClassMethod, GetSetProperty, ObjCompare, UsingArray, UsingStructAndClass, ConsoleLineRead,
       FileRead }

        static void Main(string[] args) {
             
             while (true) {  
                printLectures(); 
                string strRead = Console.ReadLine();
                //Convert.ToInt32();
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
                        FileRead fr = new FileRead();
                        fr.FileReadMain();
                        break;
                    case "9":
                        FileWrite fw = new FileWrite();
                        fw.FileWriteMain();
                         break;
                    case "q":
                        Console.WriteLine("end");
                        return;
                    default:
                        continue;
                }
            }
             
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
                Console.WriteLine(tab+ " case \"q\" : exit");
            Console.WriteLine(tab+"==========================================");
            Console.WriteLine(tab+"please select Number :: ");
        } 
    }
}
