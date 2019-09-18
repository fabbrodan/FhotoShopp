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
        ImageModifier imageModifier = new ImageModifier();
        private string OriginalFileName;
        private string NewFileName;
        private int IndexOfDotInFilePath;
        private Bitmap EditedImage;
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

                var fileSize = new FileInfo(BrowseImageDialog.FileName).Length;

                if (fileSize > 1000000)
                {
                    DialogResult result = MessageBox.Show("The image selected is larger than 1 megabyte. Actual Image size is " + ((decimal)fileSize/1024/1024).ToString("N2") + " megabytes." +
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

                Bitmap OriginalImage = (Bitmap)Bitmap.FromFile(BrowseImageDialog.FileName);
                Bitmap ResizedImage = ImageResizer.Resize(OriginalImage, OriginalImage_Picturebox.Width, OriginalImage_Picturebox.Height);
                OriginalImage_Picturebox.Image = ResizedImage;
                imageModifier.SetOriginalImage(OriginalImage);
                OriginalFileName = BrowseImageDialog.SafeFileName;

                IndexOfDotInFilePath = OriginalFileName.IndexOf('.');

                Greyscale_Btn.Enabled = true;
                Negative_Btn.Enabled = true;
                Blur_Btn.Enabled = true;
            }
        }

        private void Greyscale_Btn_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();

            Cursor.Current = Cursors.WaitCursor;
            EditedImage = imageModifier.GetGreyscaleImage();
            Cursor.Current = Cursors.Default;
            Bitmap ResizedGreyscaleImage = ImageResizer.Resize(EditedImage, EditedImage_Picturebox.Width, EditedImage_Picturebox.Height);
            EditedImage_Picturebox.Image = ResizedGreyscaleImage;

            NewFileName = OriginalFileName.Insert(IndexOfDotInFilePath, "_greyscale");

            Save_Btn.Enabled = true;
        }

        private void Negative_Btn_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            Cursor.Current = Cursors.WaitCursor;
            EditedImage = imageModifier.GetNegativeImage();
            Cursor.Current = Cursors.Default;
            Bitmap ResizedNegativeImage = ImageResizer.Resize(EditedImage, EditedImage_Picturebox.Width, EditedImage_Picturebox.Height);
            EditedImage_Picturebox.Image = ResizedNegativeImage;

            NewFileName = OriginalFileName.Insert(IndexOfDotInFilePath, "_negative");

            Save_Btn.Enabled = true;
        }

        private void Blur_Btn_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            Cursor.Current = Cursors.WaitCursor;
            EditedImage = imageModifier.GetHorizontalLinearBlurredImage();
            Cursor.Current = Cursors.Default;
            Bitmap ResizedBlurredImage = ImageResizer.Resize(EditedImage, EditedImage_Picturebox.Width, EditedImage_Picturebox.Height);
            EditedImage_Picturebox.Image = ResizedBlurredImage;

            NewFileName = OriginalFileName.Insert(IndexOfDotInFilePath, "_blurred");

            Save_Btn.Enabled = true;
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            SaveNewImageDialog.FileName = NewFileName;
            if (SaveNewImageDialog.ShowDialog() == DialogResult.OK)
            {
                EditedImage.Save(SaveNewImageDialog.FileName);
            }
        }
    }
}
