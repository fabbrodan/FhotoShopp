using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FhotoShopp;
using System.Globalization;

namespace FhotoShoppApp
{
    public partial class Form1 : Form
    {
        private readonly ImageModifier imageModifier = new ImageModifier();
        private readonly FileHandler fileHandler = new FileHandler();
        private string originalFileName;
        private string newFileName;
        private int indexOfDotInFilePath;
        private Bitmap editedImage;
        public Form1()
        {
            InitializeComponent();
            SaveNewImageDialog.Filter = "Image Files | *.jpg; *.jpeg; *.gif; *.png";
            SaveNewImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            BrowseImageDialog.Filter = "Image Files | *.jpg; *.jpeg; *.gif; *.png";
            BrowseImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Greyscale_Btn.Enabled = false;
            Negative_Btn.Enabled = false;
            Blur_Btn.Enabled = false;
            Save_Btn.Enabled = false;
        }

        private void BrowseForFile_Btn_Click(object sender, EventArgs e)
        {
            if (BrowseImageDialog.ShowDialog() == DialogResult.OK)
            {
                if (EditedImage_Picturebox.Image != null)
                {
                    EditedImage_Picturebox.Image = null;
                }

                var fileSize = fileHandler.GetFileSizeInMegaBytes(BrowseImageDialog.FileName);

                if (fileSize > 3)
                {
                    DialogResult result = MessageBox.Show("The image selected is larger than 3 megabyte. Actual Image size is " + ((decimal)fileSize).ToString("N2") + " megabytes." +
                        "\nImage processing will be gradually slower the larger the file is." +
                        "\nDo you wish to proceed anyways?", "File Size Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        
                    }
                    else
                    {
                        OriginalImage_Picturebox.Image = null;
                        return;
                    }
                }

                Bitmap originalImage = (Bitmap)Bitmap.FromFile(BrowseImageDialog.FileName);
                Bitmap resizedImage = ImageResizer.Resize(originalImage, OriginalImage_Picturebox.Width, OriginalImage_Picturebox.Height);
                OriginalImage_Picturebox.Image = resizedImage;
                imageModifier.OriginalImage = originalImage;
                originalFileName = BrowseImageDialog.SafeFileName;

                indexOfDotInFilePath = originalFileName.IndexOf('.');

                Greyscale_Btn.Enabled = true;
                Negative_Btn.Enabled = true;
                Blur_Btn.Enabled = true;
            }
        }

        private void Greyscale_Btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            editedImage = imageModifier.GetGreyscaleImage();
            Cursor.Current = Cursors.Default;
            Bitmap resizedGreyscaleImage = ImageResizer.Resize(editedImage, EditedImage_Picturebox.Width, EditedImage_Picturebox.Height);
            EditedImage_Picturebox.Image = resizedGreyscaleImage;

            newFileName = originalFileName.Insert(indexOfDotInFilePath, "_greyscale");

            Save_Btn.Enabled = true;
        }

        private void Negative_Btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            editedImage = imageModifier.GetNegativeImage();
            Cursor.Current = Cursors.Default;
            Bitmap resizedNegativeImage = ImageResizer.Resize(editedImage, EditedImage_Picturebox.Width, EditedImage_Picturebox.Height);
            EditedImage_Picturebox.Image = resizedNegativeImage;

            newFileName = originalFileName.Insert(indexOfDotInFilePath, "_negative");

            Save_Btn.Enabled = true;
        }

        private void Blur_Btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            editedImage = imageModifier.GetHorizontalLinearBlurredImage();
            Cursor.Current = Cursors.Default;
            Bitmap resizedBlurredImage = ImageResizer.Resize(editedImage, EditedImage_Picturebox.Width, EditedImage_Picturebox.Height);
            EditedImage_Picturebox.Image = resizedBlurredImage;

            newFileName = originalFileName.Insert(indexOfDotInFilePath, "_blurred");

            Save_Btn.Enabled = true;
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            SaveNewImageDialog.FileName = newFileName;
            if (SaveNewImageDialog.ShowDialog() == DialogResult.OK)
            {
                editedImage.Save(SaveNewImageDialog.FileName);
            }
        }
    }
}
