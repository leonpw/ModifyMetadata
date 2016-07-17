using System;
using System.IO;
using CommandLine;
using MetaData;

namespace ModifyMetadata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("processing ...");
                var dateTime = options.DateTime ?? DateTime.Now;
                var inputDir = options.InputDir;

                ProcessFiles(inputDir, dateTime);
                ProcessDirs(inputDir, dateTime);

                Console.WriteLine("Done processing.");
            }
            else
            {
                Console.WriteLine("The input was incorrect... ^^");
            }
        }

        private static void ProcessDirs(string inputDir, DateTime dateTime)
        {
            ProcessDir(dateTime, inputDir);
            foreach (var dir in Directory.GetDirectories(inputDir, "*", SearchOption.AllDirectories))
            {
                ProcessDir(dateTime, dir);
            }
        }

        private static void ProcessDir(DateTime dateTime, string dir)
        {
            new DateTimeSetter(dir, MetaData.Type.Dir, dateTime).SetDateTime();
        }

        private static void ProcessFiles(string inputDir, DateTime dateTime)
        {
            foreach (var file in Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories))
            {
                new DateTimeSetter(file, MetaData.Type.File, dateTime).SetDateTime();
            }
        }
    }
}