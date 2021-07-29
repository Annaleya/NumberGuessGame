using System;
using System.IO;
namespace NumberGuessGame
{
    public static class Logger
    {
        public static void WriteToLog(string message)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "log.txt")))
            {
                outputFile.WriteLine(DateTime.Now + $" { message}");
            }
        }
            
    }
}