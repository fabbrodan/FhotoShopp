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
            Bitmap testImage = new Bitmap(10, 10);

            for (int x = 0; x < testImage.Width; x++)
            {
                for (int y = 0; y < testImage.Width; y++)
                {
                    testImage.SetPixel(x, y, Color.FromArgb(255, 100, 200, 150));
                }
            }

            ImageModifier imageModifier = new ImageModifier(testImage);

            Bitmap expectedImage = new Bitmap(10, 10);

            for (int x = 0; x < testImage.Width; x++)
            {
                for (int y = 0; y < testImage.Height; y++)
                {
                    expectedImage.SetPixel(x, y, Color.FromArgb(255, 164, 164, 164));
                }
            }

            // Act
            Bitmap actualImage = imageModifier.GetGreyscaleImage();

            // Assert
            for (int i = 0; i < expectedImage.Width; i++)
            {
                for (int j = 0; j < expectedImage.Height; j++)
                {
                    Assert.AreEqual(expectedImage.GetPixel(i, j), actualImage.GetPixel(i, j));
                }
            }
        }

        [Test]
        public void TestNegative()
        {
            // Arrange

            Bitmap testImage = new Bitmap(10, 10);

            for (int x = 0; x < testImage.Width; x++)
            {
                for (int y = 0; y < testImage.Height; y++)
                {
                    testImage.SetPixel(x, y, Color.FromArgb(255, 155, 155, 155));
                }
            }

            ImageModifier imageModifier = new ImageModifier(testImage);

            Bitmap expectedImage = new Bitmap(10, 10);

            for (int i = 0; i < expectedImage.Width; i++)
            {
                for (int j = 0; j < expectedImage.Height; j++)
                {
                    expectedImage.SetPixel(i, j, Color.FromArgb(255, 100, 100, 100));
                }
            }

            // Act
            Bitmap actualImage = imageModifier.GetNegativeImage();

            // Assert
            for (int x = 0; x < actualImage.Width; x++)
            {
                for (int y = 0; y < actualImage.Height; y++)
                {
                    Assert.AreEqual(expectedImage.GetPixel(x, y), actualImage.GetPixel(x, y));
                }
            }
        }

        [Test]
        public void TestBlur()
        {
            // Arrange
            Bitmap testImage = new Bitmap(9, 9);

            for (int x = 0; x < testImage.Width; x++)
            {
                for (int y = 0; y < testImage.Height; y++)
                {
                    if (x == 4 && y == 4)
                    {
                        testImage.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                    }
                    else
                    {
                        testImage.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                    }
                }
            }

            ImageModifier imageModifier = new ImageModifier(testImage);

            Bitmap expectedImage = new Bitmap(9, 9);

            for (int x = 0; x < expectedImage.Width; x++)
            {
                for (int y = 0; y < expectedImage.Height; y++)
                {
                    if (y == 4)
                    {
                        expectedImage.SetPixel(x, y, Color.FromArgb(255, 204, 204, 204));
                    }
                    else
                    {
                        expectedImage.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                    }
                }
            }

            // Act
            Bitmap actualImage = imageModifier.GetHorizontalLinearBlurredImage();

            // Assert
            for (int x = 0; x < expectedImage.Width; x++)
            {
                for (int y = 0; y < expectedImage.Height; y++)
                {
                    Assert.AreEqual(expectedImage.GetPixel(x, y), actualImage.GetPixel(x, y));
                }
            }
        }
    }
}