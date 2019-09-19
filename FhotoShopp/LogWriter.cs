using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FhotoShopp
{
    public static class LogWriter
    {
        /// <summary>
        /// The Path to where log files are written.
        /// </summary>
        public static string LogPath { get; } = Directory.GetCurrentDirectory() + "\\Log\\log.txt";

        private static string LogDirectory = Directory.GetCurrentDirectory() + "\\Log";

        /// <summary>
        /// Writes a new line to the log file containing time stamp and the specified message.
        /// </summary>
        /// <param name="Message"></param>
        public static void WriteToLog(string Message)
        {
            DateTime now = DateTime.Now;

            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }

            if (!File.Exists(LogPath))
            {
                var file = File.Create(LogPath);
                file.Close();
            }

            using (StreamWriter writer = File.AppendText(LogPath))
            {
                string logLine = now.ToString() + " - " + Message;
                writer.WriteLine(logLine);
                writer.Flush();
            }
        }

        /// <summary>
        /// Writes a new line to the log file containing time stamp, the Exception type, stack trace and specified message.
        /// </summary>
        /// <param name="Exception">The exception to be used for log entry</param>
        /// <param name="Message">The message to be additionally written to the log</param>
        public static void WriteToLog(Exception Exception, string Message)
        {
            DateTime now = DateTime.Now;

            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }

            if (!File.Exists(LogPath))
            {
                var file = File.Create(LogPath);
                file.Close();
            }

            using (StreamWriter writer = File.AppendText(LogPath))
            {
                string logLine = now.ToString() + " - " + Message + " - " + Exception.GetType().ToString() + Exception.StackTrace;
                logLine.Replace("  ", " ");
                writer.WriteLine(logLine);
                writer.Flush();
            }
        }
    }
}
