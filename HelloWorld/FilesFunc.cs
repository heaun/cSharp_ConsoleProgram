using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class FilesFunc
    {
        string fileName = "TextFile1.txt";
        string projectPath = @"D:\3.Source\ConsoleProgram\HelloWorld";
        string sourcePath = @"D:\3.Source\ConsoleProgram\HelloWorld\files";
        string targetPath = @"D:\3.Source\ConsoleProgram\HelloWorld\files\subDir";
   
 

        public void ReadFile(String sourceFile){ 
            Encoding MyEncode = Encoding.GetEncoding("euc-kr");
            Console.WriteLine("myEncode.EncodingName = {0}", MyEncode.EncodingName);

            string pathway = Environment.CurrentDirectory;
            Console.WriteLine("pathway : {0}", pathway); 
            Console.WriteLine("========================================");

            // Example #1
            // Read the file as one string.
            //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(sourceFile);

            // Display the file contents by using a foreach loop. 
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("========================================");
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey(); 
        } 
         
        public void Copy() {
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile   = System.IO.Path.Combine(targetPath, fileName);

            if (!isFileExist(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
                Console.WriteLine("targetPath : {0} \n CreateDirectory done", targetPath);
            }
            else {
                Console.WriteLine("targetPath : {0} \n is exist done", targetPath);
            }

            Console.WriteLine("file Copy Start....");
            Console.WriteLine("file has overwited....");
            System.IO.File.Copy(sourceFile, destFile, true);
            Console.WriteLine("file Copy Done....");

            Console.WriteLine("\n\n ==============================================");
            ReadDirectory(targetPath);
        }

        public void AllCopy() {
            if (isFileExist(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
                Console.WriteLine("filecopy done.");
            }
            else {
                Console.WriteLine("Source Path does not exist!");

            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public void Move()
        {
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
  
            Console.WriteLine("file Move Start....");
            
            if (!isFileExist(sourceFile))
            { 
                System.IO.File.Move(sourceFile, destFile);
                //System.IO.Directory.Move(sourceFile, destFile);
                Console.WriteLine("file Move Done....");
            }
        }

        public void Delete() {

            string destFile = System.IO.Path.Combine(targetPath, fileName);
            ReadDirectory(targetPath);

            Console.WriteLine("file Delete Start....");
            if (isFileExist(destFile))
            {
                System.IO.File.Delete(destFile);
                Console.WriteLine("destFile : {0}", destFile);
                Console.WriteLine("file Delete Done....");
            }
        }

        string inputfileName { get; set; }

        public void Write() { 
              // Example #1: Write an array of strings to a file.
        // Create a string array that consists of three lines.
        string[] lines = { "First line", "Second line", "Third line" };
        // WriteAllLines creates a file, writes a collection of strings to the file,
        // and then closes the file.  You do NOT need to call Flush() or Close().

        Console.WriteLine("set file Name: ");
        inputfileName = Console.ReadLine() + ".txt"; 
        System.IO.File.WriteAllLines(sourcePath + inputfileName, lines); 

        // Example #2: Write one string to a text file.
        string text = "A class is the most powerful data type in C#. Like a structure, " +
                       "a class defines the data and behavior of the data type. ";
        // WriteAllText creates a file, writes the specified string to the file,
        // and then closes the file.    You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllText(sourcePath + fileName, text);

        // Example #3: Write only some strings in an array to a file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
        // encodes the output as text.
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(sourcePath + fileName))
        {
            foreach (string line in lines)
            {
                // If the line doesn't contain the word 'Second', write the line to the file.
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }
        }

        // Example #4: Append new text to an existing file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(sourcePath + fileName, true))
        {
            file.WriteLine("Fourth line");
        }

        Console.WriteLine("--------------list-------------");
        FileRead fr = new FileRead();
        fr.ReadFileListInProject(sourcePath); 
        }

        private Boolean isFileExist(string sourcefile)
        {
            Console.WriteLine("Checking file..........");
            Boolean result = false;

            if (System.IO.File.Exists(sourcefile))
            {
                Console.WriteLine("{0} file exist!", fileName);
                result = true;
            }
            else {
                Console.WriteLine("no {0} file exist!", fileName);
            }
            return result;
        }

        public void ReadDirectory(String path)
        {
            Console.WriteLine("This program lists all the files in the directory: " + path);

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            foreach (System.IO.FileInfo file in dir.GetFiles("*.*"))
            {
                string fileName = file.Name;

                if (file.Name.Contains(".exe"))
                {
                    fileName += " ( 실행파일 ) ";
                }

                Console.WriteLine("{0}, {1}", fileName, file.Length);
            }

        }

    }
}
