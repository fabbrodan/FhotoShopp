using NUnit.Framework;
using FhotoShopp;
using System.Drawing;

namespace Tests
{
    public class ImageModifierTests
    {
        
        [Test]
        public void TestGreyscale()
        {
            // Arrange
            Bitmap TestImage = new Bitmap(10, 10);

            for (int x = 0; x < TestImage.Width; x++)
            {
                for (int y = 0; y < TestImage.Width; y++)
                {
                    TestImage.SetPixel(x, y, Color.FromArgb(255, 100, 200, 150));
                }
            }

            ImageModifier imageModifier = new ImageModifier(TestImage);

            Bitmap ExpectedImage = new Bitmap(10, 10);

            for (int x = 0; x < TestImage.Width; x++)
            {
                for (int y = 0; y < TestImage.Height; y++)
                {
                    ExpectedImage.SetPixel(x, y, Color.FromArgb(255, 164, 164, 164));
                }
            }

            // Act
            Bitmap ActualImage = imageModifier.GetGreyscaleImage();

            // Assert
            for (int i = 0; i < ExpectedImage.Width; i++)
            {
                for (int j = 0; j < ExpectedImage.Height; j++)
                {
                    Assert.AreEqual(ExpectedImage.GetPixel(i, j), ActualImage.GetPixel(i, j));
                }
            }
        }

        [Test]
        public void TestNegative()
        {
            // Arrange

            Bitmap TestImage = new Bitmap(10, 10);

            for (int x = 0; x < TestImage.Width; x++)
            {
                for (int y = 0; y < TestImage.Height; y++)
                {
                    TestImage.SetPixel(x, y, Color.FromArgb(255, 155, 155, 155));
                }
            }

            ImageModifier imageModifier = new ImageModifier(TestImage);

            Bitmap ExpectedImage = new Bitmap(10, 10);

            for (int i = 0; i < ExpectedImage.Width; i++)
            {
                for (int j = 0; j < ExpectedImage.Height; j++)
                {
                    ExpectedImage.SetPixel(i, j, Color.FromArgb(255, 100, 100, 100));
                }
            }

            // Act
            Bitmap ActualImage = imageModifier.GetNegativeImage();

            // Assert
            for (int x = 0; x < ActualImage.Width; x++)
            {
                for (int y = 0; y < ActualImage.Height; y++)
                {
                    Assert.AreEqual(ExpectedImage.GetPixel(x, y), ActualImage.GetPixel(x, y));
                }
            }
        }

        [Test]
        public void TestBlur()
        {
            // Arrange
            Bitmap TestImage = new Bitmap(9, 9);

            for (int x = 0; x < TestImage.Width; x++)
            {
                for (int y = 0; y < TestImage.Height; y++)
                {
                    if (x == 4 && y == 4)
                    {
                        TestImage.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                    }
                    else
                    {
                        TestImage.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                    }
                }
            }

            ImageModifier imageModifier = new ImageModifier(TestImage);

            Bitmap ExpectedImage = new Bitmap(9, 9);

            for (int x = 0; x < ExpectedImage.Width; x++)
            {
                for (int y = 0; y < ExpectedImage.Height; y++)
                {
                    if (y == 4)
                    {
                        ExpectedImage.SetPixel(x, y, Color.FromArgb(255, 204, 204, 204));
                    }
                    else
                    {
                        ExpectedImage.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                    }
                }
            }

            // Act
            Bitmap ResultImage = imageModifier.GetHorizontalLinearBlurredImage();

            // Assert
            for (int x = 0; x < ExpectedImage.Width; x++)
            {
                for (int y = 0; y < ExpectedImage.Height; y++)
                {
                    Assert.AreEqual(ExpectedImage.GetPixel(x, y), ResultImage.GetPixel(x, y));
                }
            }
        }
    }
}