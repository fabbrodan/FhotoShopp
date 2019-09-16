using System;
using System.Drawing;

namespace FhotoShopp
{
    public class ImageModifier
    {
        private Bitmap OriginalImage;

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
        /// Returns the original Bitmap of the class instance
        /// </summary>
        /// <returns></returns>
        public Bitmap GetOriginalImage()
        {
            return this.OriginalImage;
        }
        /// <summary>
        /// Sets the Original Image of the class instance
        /// </summary>
        /// <param name="Image">The Bitmap object to be modified</param>
        public void SetOriginalImage(Bitmap Image)
        {
            this.OriginalImage = Image;
        }
        /// <summary>
        /// Returns the Black And White version of the original bitmap of the specified ImageModifier Bitmap object
        /// </summary>
        /// <returns>Bitmap</returns>
        public Bitmap GetGreyscaleImage()
        {
            Bitmap BlackAndWhiteImage = new Bitmap(OriginalImage);

            for (int w = 0; w < OriginalImage.Width; w++)
            {
                for (int h = 0; h < OriginalImage.Height; h++)
                {
                    Color oc = OriginalImage.GetPixel(w, h);

                    int a = oc.A;
                    int GreyScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(a, GreyScale, GreyScale, GreyScale);

                    BlackAndWhiteImage.SetPixel(w, h, nc);
                }
            }

            return BlackAndWhiteImage;
        }

        /// <summary>
        /// Returns the inverted version of the original bitmap of the specified ImageModifier Bitmap object
        /// </summary>
        /// <returns></returns>
        public Bitmap GetNegativeImage()
        {
            Bitmap InvertedImage = new Bitmap(OriginalImage);

            for (int w = 0; w < OriginalImage.Width; w++)
            {
                for (int h = 0; h < OriginalImage.Height; h++)
                {
                    Color OriginalColor = OriginalImage.GetPixel(w, h);

                    int a = OriginalColor.A;
                    int r = 255 - OriginalColor.R;
                    int g = 255 - OriginalColor.G;
                    int b = 255 - OriginalColor.B;

                    Color NewColor = Color.FromArgb(a, r, g, b);

                    InvertedImage.SetPixel(w, h, NewColor);
                }
            }

            return InvertedImage;
        }

        /// <summary>
        /// Returns the Blurred version version of the original bitmap of the specified ImageModifier Bitmap object
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBlurredImage()
        {
            Bitmap BlurredImage = new Bitmap(OriginalImage);

            int BlurKernelSize = 5;
            float Avg = (float)1 / BlurKernelSize;

            for (int h = 0; h < OriginalImage.Height; h++)
            {
                float[] hSum = new float[] { 0f, 0f, 0f, 0f };
                float[] hAvg = new float[] { 0f, 0f, 0f, 0f };

                for (int x = 0; x < BlurKernelSize; x++)
                {
                    Color tmpColor = OriginalImage.GetPixel(x, h);
                    hSum[0] += tmpColor.A;
                    hSum[1] += tmpColor.R;
                    hSum[2] += tmpColor.G;
                    hSum[3] += tmpColor.B;
                }

                hAvg[0] = hSum[0] * Avg;
                hAvg[1] = hSum[1] * Avg;
                hAvg[2] = hSum[2] * Avg;
                hAvg[3] = hSum[3] * Avg;

                for (int w = 0; w < OriginalImage.Width; w++)
                {
                    if ((w - BlurKernelSize / 2 >= 0 && w + 1 + BlurKernelSize / 2 < OriginalImage.Width))
                    {
                        Color tmp_pColor = OriginalImage.GetPixel(w - BlurKernelSize / 2, h);

                        hSum[0] -= tmp_pColor.A;
                        hSum[1] -= tmp_pColor.R;
                        hSum[2] -= tmp_pColor.G;
                        hSum[3] -= tmp_pColor.B;

                        Color tmp_nColor = OriginalImage.GetPixel(w + 1 + BlurKernelSize / 2, h);

                        hSum[0] += tmp_nColor.A;
                        hSum[1] += tmp_nColor.R;
                        hSum[2] += tmp_nColor.G;
                        hSum[3] += tmp_nColor.B;

                        hAvg[0] = hSum[0] * Avg;
                        hAvg[1] = hSum[1] * Avg;
                        hAvg[2] = hSum[2] * Avg;
                        hAvg[3] = hSum[3] * Avg;
                    }

                    BlurredImage.SetPixel(w, h, Color.FromArgb((int)hAvg[0], (int)hAvg[1], (int)hAvg[2], (int)hAvg[3]));
                }
            }
            return BlurredImage;
        }
    }
}
