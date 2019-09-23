using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FhotoShopp
{
    public static class ImageResizer
    {
        /// <summary>
        /// Returns a resized bitmap object according to the specified Width and height
        /// </summary>
        /// <param name="image">The bitmap to be resized</param>
        /// <param name="width">The resized Width</param>
        /// <param name="height">The resized Height</param>
        /// <returns></returns>
        public static Bitmap Resize(Bitmap image, int width, int height)
        {
            var destinationRectangle = new Rectangle(0, 0, width, height);
            var resizedImage = new Bitmap(width, height);

            resizedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destinationRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return resizedImage;
        }
    }
}
