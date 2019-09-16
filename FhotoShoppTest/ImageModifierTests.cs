using NUnit.Framework;
using FhotoShopp;
using System.Drawing;

namespace Tests
{
    public class ImageModifierTests
    {
        private Bitmap TestImage = (Bitmap)Bitmap.FromFile(@"C:\users\admin\Pictures\red.png");
        [Test]
        public void TestGreyscale()
        {
            // Arrange
            ImageModifier mod = new ImageModifier(TestImage);

            Bitmap expectedImage = new Bitmap(mod.GetOriginalImage().Width, mod.GetOriginalImage().Height);

            for (int x = 0; x < TestImage.Width; x++)
            {
                for (int y = 0; y < TestImage.Height; y++)
                {
                    expectedImage.SetPixel(x, y, Color.FromArgb(255, 76, 76, 76));
                }
            }

            // Act
            Bitmap ActualImage = mod.GetGreyscaleImage();

            // Assert
            for (int i = 0; i < expectedImage.Width; i++)
            {
                for (int j = 0; j < expectedImage.Height; j++)
                {
                    Assert.AreEqual(expectedImage.GetPixel(i, j), ActualImage.GetPixel(i, j));
                }
            }
        }

        [Test]
        public void TestNegative()
        {
            // Arrange
            ImageModifier mod = new ImageModifier(TestImage);

            Bitmap ExpectedImage = new Bitmap(mod.GetOriginalImage().Width, mod.GetOriginalImage().Height);

            for (int i = 0; i < ExpectedImage.Width; i++)
            {
                for (int j = 0; j < ExpectedImage.Height; j++)
                {
                    ExpectedImage.SetPixel(i, j, Color.FromArgb(255, 0, 255, 255));
                }
            }

            // Act
            Bitmap ActualImage = mod.GetNegativeImage();

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
            // Assert
            Bitmap OrgImg = new Bitmap(256, 256);
            ImageModifier mod = new ImageModifier(OrgImg);

            for (int x = 0; x < OrgImg.Width; x++)
            {
                for (int y = 0; y < OrgImg.Height; y++)
                {
                    if (x%2 == 0 && y%2 == 0)
                    {
                        OrgImg.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                    }
                    else
                    {
                        OrgImg.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                    }
                }
            }

            Bitmap ExpectedImage = new Bitmap(mod.GetOriginalImage().Width, mod.GetOriginalImage().Height);

            for (int i = 0; i < ExpectedImage.Width; i++)
            {
                for (int j = 0; j < ExpectedImage.Height; j++)
                {
                    if (i%2 == 0 && j%2 == 0)
                    {
                        ExpectedImage.SetPixel(i, j, Color.FromArgb(255, 153, 153, 153));
                    }
                    else
                    {
                        ExpectedImage.SetPixel(i, j, Color.FromArgb(255, 102, 102, 102));
                    }
                }
            }

            // Act
            Bitmap ActualImage = mod.GetBlurredImage();

            // Assert

            for (int x = 0; x < OrgImg.Width; x++)
            {
                for (int y = 0; y < OrgImg.Height; y++)
                {
                    Assert.AreEqual(ExpectedImage.GetPixel(x, y), ActualImage.GetPixel(x, y));
                }
            }

        }
    }
}