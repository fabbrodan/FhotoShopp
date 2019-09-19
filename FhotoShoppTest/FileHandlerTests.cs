using NUnit.Framework;
using FhotoShopp;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System;

namespace Tests
{
    public class FileHandlerTests
    {
        [Test]
        public void TestFileNameGenerationWithStandardPath()
        {
            // Arrange
            FileHandler fileHandler = new FileHandler();
            string originalPath = @"D:\hejhej\test.txt";
            string additionalText = "_blurred";
            string expectedText = @"D:\hejhej\test_blurred.txt";

            // Act
            string actualText = fileHandler.NewFilePath(originalPath, additionalText);

            // Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void TestFileNameGenerationWithDotInPath()
        {
            // Arrange
            FileHandler fileHandler = new FileHandler();
            string originalPath = @"D:\hej.hej\test.txt";
            string additionalText = "_greyscale";
            string expectedText = @"D:\hej.hej\test_greyscale.txt";

            // Act
            string actualText = fileHandler.NewFilePath(originalPath, additionalText);

            // Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void TestFileExists()
        {
            // Arrange
            FileHandler fileHandler = new FileHandler();
            string path = Directory.GetCurrentDirectory() + "\\TestFiles\\Test_Exists.jpg";

            // Act & Assert
            Assert.IsTrue(fileHandler.VerifyPath(path));
        }

        [Test]
        public void TestFileSave()
        {
            // Arrange
            Bitmap img = new Bitmap(100, 100);
            string path = Directory.GetCurrentDirectory() + "\\TestFiles\\Test_Save.jpg";

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (j%2 == 0)
                    {
                        img.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        img.SetPixel(i, j, Color.White);
                    }
                }
            }

            FileHandler fileHandler = new FileHandler();

            // Act
            fileHandler.SaveFile(img, path);

            // Assert
            Assert.IsTrue(File.Exists(path));
        }
    }
}