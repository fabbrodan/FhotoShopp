using System;
using FhotoShopp;
using System.Drawing;
using System.IO;

namespace FhotoShoppCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string ImagePath = null;
            FileHandler fileHandler = new FileHandler();
            ImageModifier imageModifier = new ImageModifier();

            if (args.Length < 1)
            {
                Console.WriteLine("There were no arguments passed to the program at startup.");
                Console.WriteLine("Please enter a path to an image...");
                ImagePath = Console.ReadLine();
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("You have specified more than one argument for the program.");
                Console.WriteLine("Please enter a path to an image...");
                ImagePath = Console.ReadLine();
            }
            else
            {
                ImagePath = args[0];
            }

            while(!fileHandler.VerifyPath(ImagePath))
            {
                Console.WriteLine("The file specified does not exist.\nPlease enter a new path...");
                ImagePath = Console.ReadLine();
            }
            
            while(!fileHandler.VerifyImage(ImagePath))
            {
                Console.WriteLine("The file specified is not an image.\nPlease enter a new path...");
                ImagePath = Console.ReadLine();
            }

            imageModifier.SetOriginalImage(fileHandler.GetImageFromPath(ImagePath));
            Bitmap GreyScaleImage = imageModifier.GetGreyscaleImage();
            Bitmap NegativeImage = imageModifier.GetNegativeImage();
            Bitmap BlurredImage = imageModifier.GetLinearBlurredImage();

            int IndexOfDot = ImagePath.IndexOf('.');
            string GreyScaleImagePath = fileHandler.NewFilePath(ImagePath, "_greyscale", IndexOfDot);
            string NegativeImagPath = fileHandler.NewFilePath(ImagePath, "_negative", IndexOfDot);
            string BlurredImagePath = fileHandler.NewFilePath(ImagePath, "_blurred", IndexOfDot);

            fileHandler.SaveFile(GreyScaleImage, GreyScaleImagePath);
            fileHandler.SaveFile(NegativeImage, NegativeImagPath);
            fileHandler.SaveFile(BlurredImage, BlurredImagePath);

            Console.WriteLine("The greyscale image was saved at {0}", GreyScaleImagePath);
            Console.WriteLine("The negative image was saved at {0}", NegativeImagPath);
            Console.WriteLine("The blurred image was saved at {0}\n", BlurredImagePath);
            Console.WriteLine("Enter any key to close the application...");

            Console.ReadLine();

        }
    }
}