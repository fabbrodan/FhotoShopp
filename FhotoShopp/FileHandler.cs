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
        /// <returns>Bitmap</returns>
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
        /// <returns>string</returns>
        public string NewFilePath (string OriginalPath, string AdditionalText)
        {
            string fileNameWithExtension = Path.GetFileName(OriginalPath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(OriginalPath);
            string fileExtension = Path.GetExtension(OriginalPath);
            string newFileName = fileNameWithoutExtension + AdditionalText + fileExtension;
            StringBuilder sb = new StringBuilder(OriginalPath);
            sb.Replace(fileNameWithExtension, newFileName);

            return sb.ToString();
        }

        /// <summary>
        /// Returns a bool indicating whether or not the passed in file path exists or not
        /// </summary>
        /// <param name="FilePath">The file path to be verified</param>
        /// <returns>bool</returns>
        public bool VerifyPath(string FilePath)
        {
            bool fileExists = false;

            if (File.Exists(FilePath))
            {
                fileExists = true;
            }
            return fileExists;
        }

        /// <summary>
        /// Returns a bool whether or not the specfied file from the path is an image file type or not
        /// </summary>
        /// <param name="FilePath">The file path to be verified</param>
        /// <returns>bool</returns>
        public bool VerifyFileExtension(string FilePath)
        {
            bool fileIsImage = false;

            foreach (string extension in ValidImageFileExtensions)
            {
                if (FilePath.ToLowerInvariant().EndsWith(extension))
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
        /// <param name="FilePath">The path to the file to be checked</param>
        /// <returns>long</returns>
        public long GetFileSizeInBytes(string FilePath)
        {
            var fileLengthInBytes = new FileInfo(FilePath).Length;
            return fileLengthInBytes;
        }

        /// <summary>
        /// Returns the size of the file in mega bytes
        /// </summary>
        /// <param name="FilePath">The path to the file to be checked</param>
        /// <returns>long</returns>
        public long GetFileSizeInMegaBytes(string FilePath)
        {
            var fileLengthInMegaBytes = new FileInfo(FilePath).Length / 1024 / 1024;
            return fileLengthInMegaBytes;
        }

        /// <summary>
        /// Tries to save the Bitmap object to the specified Path and return a bool indicating if the save was successsful or not
        /// </summary>
        /// <param name="Image">The Bitmap object to be saved</param>
        /// <param name="FilePath">The string literal of the path to be saved</param>
        /// <returns>bool</returns>
        public bool SaveFile(Bitmap Image, string FilePath)
        {
            try
            {
                Image.Save(FilePath);
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
