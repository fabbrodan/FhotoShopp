using NUnit.Framework;
using System;
using System.IO;
using FhotoShopp;

namespace Tests
{
    public class LogWriterTests
    {
        [Test]
        public void TestSimpleLogMessage()
        {
            // Arrange
            if (File.Exists(LogWriter.LogPath))
            {
                File.Delete(LogWriter.LogPath);
            }

            LogWriter.WriteToLog("This is a test");

            string expectedText = "This is a test";
            string actualText;

            // Act
            using (StreamReader reader = new StreamReader(File.Open(LogWriter.LogPath, FileMode.Open)))
            {
                string line = reader.ReadLine();
                actualText = line.Substring(22, line.Length - 22);
            }

            // Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void TestLogMessageWithException()
        {
            // Arrange
            if (File.Exists(LogWriter.LogPath))
            {
                File.Delete(LogWriter.LogPath);
            }

            string expectedText = "This was a divide by zero exception - System.DivideByZeroException   at Tests.LogWriterTests.TestLogMessageWithException()";
            string actualText;

            // Act
            try
            {
                int x = 100;
                int y = 0;
                int divideByZero = x/y;
            }
            catch (DivideByZeroException exc)
            {
                LogWriter.WriteToLog(exc, "This was a divide by zero exception");
            }

            using (StreamReader reader = new StreamReader(File.Open(LogWriter.LogPath, FileMode.Open)))
            {
                string line = reader.ReadLine();
                actualText = line.Substring(22, expectedText.Length);
            }

            // Assert
            Assert.AreEqual(expectedText, actualText);
        }
    }
}