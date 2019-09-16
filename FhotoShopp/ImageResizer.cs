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
        /// <param name="Image">The bitmap to be resized</param>
        /// <param name="Width">The resized Width</param>
        /// <param name="Height">The resized Height</param>
        /// <returns></returns>
        public static Bitmap Resize(Bitmap Image, int Width, int Height)
        {
            var DestinationRectangle = new Rectangle(0, 0, Width, Height);
            var ResizedImage = new Bitmap(Width, Height);

            ResizedImage.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(ResizedImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(Image, DestinationRectangle, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return ResizedImage;
        }
    }
}
