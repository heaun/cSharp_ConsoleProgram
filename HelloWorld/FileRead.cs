using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class FileRead
    {
        public void FileReadMain()
        {
            string myFile1 = @"D:\3.Source\ConsoleProgram\HelloWorld\files\TextFile1.txt";
            string myFile2 = @"D:\3.Source\ConsoleProgram\HelloWorld\files\TextFile2.txt";

            //encoding 
            /**
             파일 처리시 파일에 있는 한글을 정상적으로 읽기 위해 기본적으로 셋팅되어 있는 UTF-8을 EUC-KR로 변경한다. */
            Encoding MyEncode = Encoding.GetEncoding("euc-kr");
            Console.WriteLine("myEncode.EncodingName = {0}", MyEncode.EncodingName);

            string pathway = Environment.CurrentDirectory;
            Console.WriteLine("pathway : {0}", pathway);

            ReadFileListInProject(@"D:\3.Source\ConsoleProgram\HelloWorld\");
            Console.WriteLine("========================================");
            ReadFile_0(myFile1);
     //       ReadFile_1(myFile1, MyEncode);
         //   ReadFile_2(myFile2, MyEncode);
        }

        private static void ReadFile_0(string myFile) { 
            
            // Example #1
            // Read the file as one string.
            //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
             // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(myFile);

            // Display the file contents by using a foreach loop. 
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
        public void ReadFileListInProject(String path) {
            Console.WriteLine("This program lists all the files in the directory: " + path);

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            foreach (System.IO.FileInfo file in dir.GetFiles("*.*"))
            {
                string fileName = file.Name;

                if (file.Name.Contains(".exe"))
                {
                    fileName += " ( 실행파일 ) ";                    
                }

                Console.WriteLine("{0}, {1}", file.Name, file.Length);
            }
        
        }
        private static void ReadFile_2(string myFile2, Encoding MyEncode)
         {
            if (File.Exists(myFile2))
            {
                try
                {
                    //pen(string path, FileMode mode, FileAccess access);
                    string path = myFile2;
                    FileMode mode = FileMode.OpenOrCreate;
                    FileAccess access = FileAccess.Read;

                    FileStream myFileStream2 = File.Open(path, mode, access);
                    StreamReader streamReader2 = new StreamReader(myFile2, MyEncode);
                    string strReadFileData;
                    int i = 0;

                    strReadFileData = streamReader2.ReadLine();

                    while (strReadFileData != null)
                    {
                        i++;
                        Console.WriteLine("텍스트 라인번호 : {0}, ", "", i);
                        if (strReadFileData == "")
                        {
                            strReadFileData = "빈라인";
                        }
                        Console.WriteLine("");
                        strReadFileData = streamReader2.ReadLine();
                    }
                    streamReader2.Close();
                }
                catch(Exception e) {
                    e.ToString();
                }
            }
            else
            {
                Console.WriteLine("no file : {0}", myFile2);
            }
        }

        private static void ReadFile_1(string myFile1, Encoding myEncode)
        {
            if (File.Exists(myFile1))
            {
                try
                {
                    //FileStream Reader 생성
                    FileStream myFileStream1 = File.Open(myFile1, FileMode.OpenOrCreate, FileAccess.Read);
                    //StreamReader 생성
                    StreamReader streamReader1 = new StreamReader(myFile1, myEncode);

                    streamReader1.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (streamReader1.Peek() > -1)
                    {
                        Console.WriteLine(streamReader1.ReadLine());
                    }
                    Console.WriteLine("fileReader.Peek() : {0}", streamReader1.Peek());

                    streamReader1.Close();
                }
                catch (DirectoryNotFoundException e) { Console.WriteLine("DirectoryNotFoundException error: " + e.Message); }
                catch (EndOfStreamException e) { Console.WriteLine("EndOfStreamException error: " + e.Message); }
                catch (FileNotFoundException e) { Console.WriteLine("FileNotFoundException error: " + e.Message); }
                catch (FileLoadException e) { Console.WriteLine("FileLoadException : " + e.Message); }
                catch (PathTooLongException e) { Console.WriteLine("PathTooLongException error: " + e.Message); }
                catch (IOException e) { Console.WriteLine("IOException error: " + e.Message); }
            }
            else
            {
                Console.WriteLine("no file : {0}", myFile1);
            }
        }
    }
}
