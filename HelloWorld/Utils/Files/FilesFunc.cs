﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class FilesFunc
    {
        string fileName = "TextFile1.txt";
        string sourcePath = @"D:\3.Source\ConsoleProgram\HelloWorld\files";
        string targetPath = @"D:\3.Source\ConsoleProgram\HelloWorld\files\subDir"; 
 
        public void Read(String sourceFile){ 
            var MyEncode = Encoding.GetEncoding("euc-kr");
            Console.WriteLine("myEncode.EncodingName = {0}", MyEncode.EncodingName);

            var pathway = Environment.CurrentDirectory;
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
            var lines = System.IO.File.ReadAllLines(sourceFile);

            // Display the file contents by using a foreach loop. 
            foreach (var line in lines)
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
            var sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            var destFile   = System.IO.Path.Combine(targetPath, fileName);

            if (!IsFileExist(targetPath))
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
            if (IsFileExist(sourcePath))
            {
                var files = System.IO.Directory.GetFiles(sourcePath);
                foreach (var s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    var destFile = System.IO.Path.Combine(targetPath, fileName);
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
            var sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            var destFile = System.IO.Path.Combine(targetPath, fileName);
  
            Console.WriteLine("file Move Start....");
            
            if (!IsFileExist(sourceFile))
            { 
                System.IO.File.Move(sourceFile, destFile);
                //System.IO.Directory.Move(sourceFile, destFile);
                Console.WriteLine("file Move Done....");
            }
        }

        public void Delete() {

            var destFile = System.IO.Path.Combine(targetPath, fileName);
            ReadDirectory(targetPath);

            Console.WriteLine("file Delete Start....");
            if (IsFileExist(destFile))
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
        var text = "A class is the most powerful data type in C#. Like a structure, " +
                       "a class defines the data and behavior of the data type. ";
        // WriteAllText creates a file, writes the specified string to the file,
        // and then closes the file.    You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllText(sourcePath + fileName, text);

        // Example #3: Write only some strings in an array to a file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
        // encodes the output as text.
        using (var file =
            new System.IO.StreamWriter(sourcePath + fileName))
        {
            foreach (var line in lines)
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
        using (var file =
            new System.IO.StreamWriter(sourcePath + fileName, true))
        {
            file.WriteLine("Fourth line");
        }

        Console.WriteLine("--------------list-------------");
        ReadDirectory(sourcePath); 
        }

        private Boolean IsFileExist(string sourcefile)
        {
            Console.WriteLine("Checking file..........");
            var result = false;

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

            var dir = new System.IO.DirectoryInfo(path);

            foreach (var file in dir.GetFiles("*.*"))
            {
                var fileName = file.Name;

                if (file.Name.Contains(".exe"))
                {
                    fileName += " ( 실행파일 ) ";
                }

                Console.WriteLine("{0}, {1}", fileName, file.Length);
            }

        }

    }
}
