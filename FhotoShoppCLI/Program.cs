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
            string imagePath = null;
            FileHandler fileHandler = new FileHandler();
            ImageModifier imageModifier = new ImageModifier();

            if (args.Length < 1)
            {
                Console.WriteLine("There were no arguments passed to the program at startup.");
                Console.WriteLine("Please enter a path to an image...");
                imagePath = Console.ReadLine();
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("You have specified more than one argument for the program.");
                Console.WriteLine("Please enter a path to an image...");
                imagePath = Console.ReadLine();
            }
            else
            {
                imagePath = args[0];
            }

            bool validPath = fileHandler.VerifyPath(imagePath);
            bool validFile = fileHandler.VerifyFileExtension(imagePath);

            while ((!validFile) || (!validPath))
            {
                if (!validPath)
                {
                    Console.WriteLine("The file specified does not exist.\nPlease enter a new path...");
                    imagePath = Console.ReadLine();

                    validPath = fileHandler.VerifyPath(imagePath);
                    validFile = fileHandler.VerifyFileExtension(imagePath);
                }
                else if (!validPath && validFile)
                {
                    Console.WriteLine("The file specified does not exist.\nPlease enter a new path...");
                    imagePath = Console.ReadLine();

                    validPath = fileHandler.VerifyPath(imagePath);
                    validFile = fileHandler.VerifyFileExtension(imagePath);
                }
                else if (validPath && !validFile)
                {
                    Console.WriteLine("The file specified is not an image.\nPlease enter a new path...");
                    imagePath = Console.ReadLine();

                    validPath = fileHandler.VerifyPath(imagePath);
                    validFile = fileHandler.VerifyFileExtension(imagePath);
                }
            }

            imageModifier.OriginalImage = fileHandler.GetImageFromPath(imagePath);
            Bitmap greyScaleImage = imageModifier.GetGreyscaleImage();
            Bitmap negativeImage = imageModifier.GetNegativeImage();
            Bitmap blurredImage = imageModifier.GetHorizontalLinearBlurredImage();

            string greyScaleImagePath = fileHandler.NewFilePath(imagePath, "_greyscale");
            string negativeImagPath = fileHandler.NewFilePath(imagePath, "_negative");
            string blurredImagePath = fileHandler.NewFilePath(imagePath, "_blurred");

            fileHandler.SaveFile(greyScaleImage, greyScaleImagePath);
            fileHandler.SaveFile(negativeImage, negativeImagPath);
            fileHandler.SaveFile(blurredImage, blurredImagePath);

            Console.WriteLine("The greyscale image was saved at {0}", greyScaleImagePath);
            Console.WriteLine("The negative image was saved at {0}", negativeImagPath);
            Console.WriteLine("The blurred image was saved at {0}\n", blurredImagePath);
        }
    }
}