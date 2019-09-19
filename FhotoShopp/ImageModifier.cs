using System;
using System.Drawing;

namespace FhotoShopp
{
    public class ImageModifier
    {
        /// <summary>
        /// The Bitmap object that is to be modified
        /// </summary>
        public Bitmap OriginalImage { get; set; }

        /// <summary>
        /// Creates a new instance of the ImageModifier class
        /// </summary>
        public ImageModifier()
        {

        }

        /// <summary>
        /// Creates a new instance of the ImageModifier class
        /// </summary>
        /// <param name="Image">THe bitmap object to be modified</param>
        public ImageModifier(Bitmap Image)
        {
            this.OriginalImage = Image;
        }

        /// <summary>
        /// Returns the Black And White version of the original bitmap of the specified ImageModifier Bitmap object
        /// </summary>
        /// <returns>Bitmap</returns>
        public Bitmap GetGreyscaleImage()
        {
            Bitmap blackAndWhiteImage = new Bitmap(OriginalImage.Width, OriginalImage.Height);

            for (int w = 0; w < OriginalImage.Width; w++)
            {
                for (int h = 0; h < OriginalImage.Height; h++)
                {
                    Color originalColor = OriginalImage.GetPixel(w, h);

                    int a = originalColor.A;
                    int greyScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    Color nc = Color.FromArgb(a, greyScale, greyScale, greyScale);

                    blackAndWhiteImage.SetPixel(w, h, nc);
                }
            }

            return blackAndWhiteImage;
        }

        /// <summary>
        /// Returns the inverted version of the original bitmap of the specified ImageModifier Bitmap object
        /// </summary>
        /// <returns></returns>
        public Bitmap GetNegativeImage()
        {
            Bitmap invertedImage = new Bitmap(OriginalImage.Width, OriginalImage.Height);

            for (int w = 0; w < OriginalImage.Width; w++)
            {
                for (int h = 0; h < OriginalImage.Height; h++)
                {
                    Color originalColor = OriginalImage.GetPixel(w, h);

                    int a = originalColor.A;
                    int r = 255 - originalColor.R;
                    int g = 255 - originalColor.G;
                    int b = 255 - originalColor.B;

                    Color newColor = Color.FromArgb(a, r, g, b);

                    invertedImage.SetPixel(w, h, newColor);
                }
            }

            return invertedImage;
        }

        /// <summary>
        /// Returns the horizontally linear blurred version of the original bitmap of this ImageModifier instance
        /// </summary>
        /// <returns></returns>
        public Bitmap GetHorizontalLinearBlurredImage()
        {
            Bitmap blurredImage = new Bitmap(OriginalImage.Width, OriginalImage.Height);

            int blurKernelSize = 0;

            if (OriginalImage.Width >= 25 && OriginalImage.Height >= 25)
            {
                blurKernelSize = (OriginalImage.Width / 25 + OriginalImage.Height / 25) / 2;
            }
            else
            {
                blurKernelSize = 5;
            }

            float avg = (float)1 / blurKernelSize;

            for (int h = 0; h < OriginalImage.Height; h++)
            {
                float[] hSum = new float[] { 0f, 0f, 0f, 0f };
                float[] hAvg = new float[] { 0f, 0f, 0f, 0f };

                for (int x = 0; x < blurKernelSize; x++)
                {
                    Color tmpColor = OriginalImage.GetPixel(x, h);
                    hSum[0] += tmpColor.A;
                    hSum[1] += tmpColor.R;
                    hSum[2] += tmpColor.G;
                    hSum[3] += tmpColor.B;
                }

                hAvg[0] = hSum[0] * avg;
                hAvg[1] = hSum[1] * avg;
                hAvg[2] = hSum[2] * avg;
                hAvg[3] = hSum[3] * avg;

                for (int w = 0; w < OriginalImage.Width; w++)
                {
                    int constraintLeft = w - blurKernelSize / 2;
                    int constraintRight = w + 1 + blurKernelSize / 2;
                    if ((constraintLeft >= 0 && constraintRight < OriginalImage.Width))
                    {
                        Color tmp_LeftColor = OriginalImage.GetPixel(constraintLeft, h);

                        hSum[0] -= tmp_LeftColor.A;
                        hSum[1] -= tmp_LeftColor.R;
                        hSum[2] -= tmp_LeftColor.G;
                        hSum[3] -= tmp_LeftColor.B;

                        Color tmp_RightColor = OriginalImage.GetPixel(constraintRight, h);

                        hSum[0] += tmp_RightColor.A;
                        hSum[1] += tmp_RightColor.R;
                        hSum[2] += tmp_RightColor.G;
                        hSum[3] += tmp_RightColor.B;

                        hAvg[0] = hSum[0] * avg;
                        hAvg[1] = hSum[1] * avg;
                        hAvg[2] = hSum[2] * avg;
                        hAvg[3] = hSum[3] * avg;
                    }

                    try
                    {
                        blurredImage.SetPixel(w, h, Color.FromArgb((int)hAvg[0], (int)hAvg[1], (int)hAvg[2], (int)hAvg[3]));
                    }
                    catch (ArgumentException exc)
                    {
                        LogWriter.WriteToLog(exc, "Pixel at position " + w + "," + h + " were set to black");
                        blurredImage.SetPixel(w, h, Color.FromArgb(255, 0, 0, 0));
                    }
                }
            }
            return blurredImage;
        }
    }
}
