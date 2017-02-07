using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    
    class FileCopy
    {
        string fileName = "TextFile1.txt";
        string sourcePath = @"D:\3.Source\ConsoleProgram\HelloWorld\files";
        string targetPath = @"D:\3.Source\ConsoleProgram\HelloWorld\files\subDir";
        string sourceFile = string.Empty;
        string destFile   = string.Empty;

        public void fileCopy() {
            sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            destFile   = System.IO.Path.Combine(targetPath, fileName);
            if (!System.IO.Directory.Exists(targetPath)) {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
            AllFileCopy();
        }
        public void AllFileCopy() {
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
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
    }
}
