using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsHomeWork2
{
    interface ILogger
    {
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void LogError(string message, Exception ex);
    }

    class LocalFileLogger<T>: ILogger
    {
        private string Path;
        public LocalFileLogger(string path)
        {
            Path = path;
            
        }

        public void LogError(string message, Exception ex)
        {
            Write($"[Error]: [{typeof(T)}] : {message}. {ex.Message}");
            //Console.WriteLine($"[Error]: [{typeof(T)}] : {message}. {ex.Message}");
        }

        public void LogInfo(string message)
        {
            Write($"[Info]: [{typeof(T)}] : {message}");
            //Console.WriteLine($"[Info]: [{typeof(T)}] : {message}");
        }

        public void LogWarning(string message)
        {
            Write($"[Warning]: [{typeof(T)}] : {message}");
            //Console.WriteLine($"[Warning]: [{typeof(T)}] : {message}");
        }

        private void Write(string message)
        {
            StreamWriter writer = new StreamWriter(Path, File.Exists(Path)?true:false);
            writer.WriteLine(message);
            writer.Close();
        }
    }
}
