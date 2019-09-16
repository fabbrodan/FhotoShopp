using NUnit.Framework;
using FhotoShopp;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Tests
{
    public class FileHandlerTests
    {
        [Test]
        public void TestFileNameGeneration()
        {
            // Arrange
            FileHandler fileHandler = new FileHandler();
            string OriginalPath = @"C:\Users\admin\Pictures\tesp.jpg";
            string AdditionalText = " hej hej ";
            int Index = 0;
            string Expected = @" hej hej C:\Users\admin\Pictures\tesp.jpg";

            // Act
            string Actual = fileHandler.NewFilePath(OriginalPath, AdditionalText, Index);

            // Assert
            Assert.AreEqual(Actual, Expected);
        }

        [Test]
        public void TestFileExists()
        {
            // Arrange
            FileHandler fileHandler = new FileHandler();
            string path = @"C:\users\admin\Pictures\test.jpg";

            // Act & Assert
            Assert.IsTrue(fileHandler.VerifyPath(path));
        }

        [Test]
        public void TestFileSave()
        {
            // Arrange
            Bitmap img = new Bitmap(100, 100);
            string path = @"C:\users\admin\Desktop\UnitTest.jpg";

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