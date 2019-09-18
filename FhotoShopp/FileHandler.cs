using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FhotoShopp
{
    public class FileHandler
    {

        private List<string> ValidImageFileExtensions = new List<string>()
        {
            ".jpg", ".jpeg", ".bmp", ".gif", ".png"
        };

        /// <summary>
        /// Intializezs a new instance of the FileHandler class
        /// </summary>
        public FileHandler()
        {

        }
        /// <summary>
        /// Returns a Bitmap object fetched from the passed in FilePath parameter
        /// </summary>
        /// <param name="FilePath">The full path to an image on the file system</param>
        /// <returns></returns>
        public Bitmap GetImageFromPath(string FilePath)
        {
            return (Bitmap)Bitmap.FromFile(FilePath);
        }

        /// <summary>
        /// Returns a new file path with the Additional Text inserted at the specified Index
        /// </summary>
        /// <param name="OriginalPath">The path to be modified</param>
        /// <param name="AdditionalText">The additional text to be added to the path</param>
        /// <param name="Index">The 0-based index at where the additional text is to be added</param>
        /// <returns></returns>
        public string NewFilePath (string OriginalPath, string AdditionalText, int Index)
        {
            StringBuilder sb = new StringBuilder(OriginalPath);
            sb.Insert(Index, AdditionalText);
            return sb.ToString();
        }

        /// <summary>
        /// Returns a bool indicating whether or not the passed in file path exists or not
        /// </summary>
        /// <param name="FilePath">The file path to be verified</param>
        /// <returns></returns>
        public bool VerifyPath(string FilePath)
        {
            bool bFileExists = false;

            if (File.Exists(FilePath))
            {
                bFileExists = true;
            }
            return bFileExists;
        }

        /// <summary>
        /// Returns a bool whether or not the specfied file from the path is an image file type or not
        /// </summary>
        /// <param name="FilePath">The file path to be verified</param>
        /// <returns></returns>
        public bool VerifyImage(string FilePath)
        {
            bool bFileIsImage = false;

            foreach (string extension in ValidImageFileExtensions)
            {
                if (FilePath.ToLowerInvariant().EndsWith(extension))
                {
                    bFileIsImage = true;
                    break;
                }
            }

            return bFileIsImage;
        }

        /// <summary>
        /// Saves the Bitmap object to the specified Path
        /// </summary>
        /// <param name="Image">The Bitmap object to be saved</param>
        /// <param name="FilePath">The string literal of the path to be saved</param>
        public void SaveFile(Bitmap Image, string FilePath)
        {
            try
            {
                Image.Save(FilePath);
            }
            catch (ArgumentNullException)
            {
                
            }
            catch (ExternalException)
            {
                
            }
        }
    }
}
