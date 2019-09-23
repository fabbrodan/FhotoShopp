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

        private List<string> validImageFileExtensions = new List<string>()
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
        /// <param name="filePath">The full path to an image on the file system</param>
        /// <returns>Bitmap</returns>
        public Bitmap GetImageFromPath(string filePath)
        {
            return (Bitmap)Bitmap.FromFile(filePath);
        }

        /// <summary>
        /// Returns a new file path with the Additional Text inserted at the specified Index
        /// </summary>
        /// <param name="originalPath">The path to be modified</param>
        /// <param name="AdditionalText">The additional text to be added to the path</param>
        /// <returns>string</returns>
        public string NewFilePath(string originalPath, string additionalText)
        {
            string fileNameWithExtension = Path.GetFileName(originalPath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalPath);
            string fileExtension = Path.GetExtension(originalPath);
            string newFileName = fileNameWithoutExtension + additionalText + fileExtension;
            StringBuilder sb = new StringBuilder(originalPath);
            sb.Replace(fileNameWithExtension, newFileName);

            return sb.ToString();
        }

        /// <summary>
        /// Returns a bool indicating whether or not the passed in file path exists or not
        /// </summary>
        /// <param name="filePath">The file path to be verified</param>
        /// <returns>bool</returns>
        public bool VerifyPath(string filePath)
        {
            bool fileExists = false;

            if (File.Exists(filePath))
            {
                fileExists = true;
            }
            return fileExists;
        }

        /// <summary>
        /// Returns a bool whether or not the specfied file from the path is an image file type or not
        /// </summary>
        /// <param name="filePath">The file path to be verified</param>
        /// <returns>bool</returns>
        public bool VerifyFileExtension(string filePath)
        {
            bool fileIsImage = false;

            foreach (string extension in validImageFileExtensions)
            {
                if (filePath.ToLowerInvariant().EndsWith(extension))
                {
                    fileIsImage = true;
                    break;
                }
            }

            return fileIsImage;
        }

        /// <summary>
        /// Returns the size of the file in bytes
        /// </summary>
        /// <param name="filePath">The path to the file to be checked</param>
        /// <returns>long</returns>
        public long GetFileSizeInBytes(string filePath)
        {
            var fileLengthInBytes = new FileInfo(filePath).Length;
            return fileLengthInBytes;
        }

        /// <summary>
        /// Returns the size of the file in mega bytes
        /// </summary>
        /// <param name="filePath">The path to the file to be checked</param>
        /// <returns>long</returns>
        public long GetFileSizeInMegaBytes(string filePath)
        {
            var fileLengthInMegaBytes = new FileInfo(filePath).Length / 1024 / 1024;
            return fileLengthInMegaBytes;
        }

        /// <summary>
        /// Tries to save the Bitmap object to the specified Path and return a bool indicating if the save was successsful or not
        /// </summary>
        /// <param name="image">The Bitmap object to be saved</param>
        /// <param name="filePath">The string literal of the path to be saved</param>
        /// <returns>bool</returns>
        public bool SaveFile(Bitmap image, string filePath)
        {
            try
            {
                image.Save(filePath);
                return true;
            }
            catch (ArgumentNullException exc)
            {
                LogWriter.WriteToLog(exc, null);
                return false;
            }
            catch (ExternalException exc)
            {
                LogWriter.WriteToLog(exc, null);
                return false;
            }
        }
    }
}
