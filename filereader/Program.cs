using System;
using System.IO;
using System.Linq;

namespace filereader
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryRetrievePath();
        }

        static void DirectoryRetrievePath()
        {
            bool pathFound = false;

            Console.WriteLine("Please enter the path of directory");

            string path = "";

            while (!pathFound)
            {
                path = Console.ReadLine();

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Directory path isn't valid");
                    DirectoryRetrievePath();
                }

                else pathFound = true;
            }

            DirectoryGetFiles(path);
        }

        static void DirectoryGetFiles(string path)
        {
            if (Directory.GetFiles(path).Length == 0)
            {
                Console.Write("There are no files in this directory");
                DirectoryRetrievePath();
            }

            string[] directoryFiles = Directory.GetFiles(path);

            string output = "";

            foreach (string file in directoryFiles)
            {
                string lines = File.ReadAllText(file);
                output += lines + Environment.NewLine;
            }

            DirectoryWriteFile(path, output);
        }

        static void DirectoryWriteFile(string path, string output)
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.txt");
            File.WriteAllText(outputPath, output);

            Console.WriteLine($"Text was saved at {outputPath}");

            Environment.Exit(0);
        }
    }
}
