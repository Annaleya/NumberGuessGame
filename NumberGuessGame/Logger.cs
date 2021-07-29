using System;
using System.IO;
namespace NumberGuessGame
{
    public static class Logger
    {
        private static string LogFileName = "log.txt";

        public static void Log(string message)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "logfile.txt")))
            {
                outputFile.WriteLine(DateTime.Now);
                outputFile.WriteLine();
            }
        }
    }
}