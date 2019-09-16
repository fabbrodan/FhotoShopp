namespace FhotoShoppApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BrowseImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveNewImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.BrowseForFile_Btn = new System.Windows.Forms.Button();
            this.Greyscale_Btn = new System.Windows.Forms.Button();
            this.Negative_Btn = new System.Windows.Forms.Button();
            this.Blur_Btn = new System.Windows.Forms.Button();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.OriginalImage_Picturebox = new System.Windows.Forms.PictureBox();
            this.EditedImage_Picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage_Picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedImage_Picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // BrowseForFile_Btn
            // 
            this.BrowseForFile_Btn.Location = new System.Drawing.Point(12, 13);
            this.BrowseForFile_Btn.Name = "BrowseForFile_Btn";
            this.BrowseForFile_Btn.Size = new System.Drawing.Size(75, 27);
            this.BrowseForFile_Btn.TabIndex = 0;
            this.BrowseForFile_Btn.Text = "Browse...";
            this.BrowseForFile_Btn.UseVisualStyleBackColor = true;
            this.BrowseForFile_Btn.Click += new System.EventHandler(this.BrowseForFile_Btn_Click);
            // 
            // Greyscale_Btn
            // 
            this.Greyscale_Btn.Location = new System.Drawing.Point(400, 46);
            this.Greyscale_Btn.Name = "Greyscale_Btn";
            this.Greyscale_Btn.Size = new System.Drawing.Size(102, 27);
            this.Greyscale_Btn.TabIndex = 1;
            this.Greyscale_Btn.Text = "Greyscale";
            this.Greyscale_Btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Greyscale_Btn.UseVisualStyleBackColor = true;
            this.Greyscale_Btn.Click += new System.EventHandler(this.Greyscale_Btn_Click);
            // 
            // Negative_Btn
            // 
            this.Negative_Btn.Location = new System.Drawing.Point(400, 79);
            this.Negative_Btn.Name = "Negative_Btn";
            this.Negative_Btn.Size = new System.Drawing.Size(102, 27);
            this.Negative_Btn.TabIndex = 2;
            this.Negative_Btn.Text = "Negative";
            this.Negative_Btn.UseVisualStyleBackColor = true;
            this.Negative_Btn.Click += new System.EventHandler(this.Negative_Btn_Click);
            // 
            // Blur_Btn
            // 
            this.Blur_Btn.Location = new System.Drawing.Point(400, 112);
            this.Blur_Btn.Name = "Blur_Btn";
            this.Blur_Btn.Size = new System.Drawing.Size(102, 27);
            this.Blur_Btn.TabIndex = 3;
            this.Blur_Btn.Text = "Blur";
            this.Blur_Btn.UseVisualStyleBackColor = true;
            this.Blur_Btn.Click += new System.EventHandler(this.Blur_Btn_Click);
            // 
            // Save_Btn
            // 
            this.Save_Btn.Location = new System.Drawing.Point(400, 241);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(102, 27);
            this.Save_Btn.TabIndex = 4;
            this.Save_Btn.Text = "Save";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // OriginalImage_Picturebox
            // 
            this.OriginalImage_Picturebox.BackColor = System.Drawing.Color.White;
            this.OriginalImage_Picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalImage_Picturebox.Location = new System.Drawing.Point(12, 46);
            this.OriginalImage_Picturebox.Name = "OriginalImage_Picturebox";
            this.OriginalImage_Picturebox.Size = new System.Drawing.Size(382, 382);
            this.OriginalImage_Picturebox.TabIndex = 5;
            this.OriginalImage_Picturebox.TabStop = false;
            // 
            // EditedImage_Picturebox
            // 
            this.EditedImage_Picturebox.BackColor = System.Drawing.Color.White;
            this.EditedImage_Picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditedImage_Picturebox.Location = new System.Drawing.Point(508, 46);
            this.EditedImage_Picturebox.Name = "EditedImage_Picturebox";
            this.EditedImage_Picturebox.Size = new System.Drawing.Size(382, 382);
            this.EditedImage_Picturebox.TabIndex = 6;
            this.EditedImage_Picturebox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 464);
            this.Controls.Add(this.EditedImage_Picturebox);
            this.Controls.Add(this.OriginalImage_Picturebox);
            this.Controls.Add(this.Save_Btn);
            this.Controls.Add(this.Blur_Btn);
            this.Controls.Add(this.Negative_Btn);
            this.Controls.Add(this.Greyscale_Btn);
            this.Controls.Add(this.BrowseForFile_Btn);
            this.Name = "Form1";
            this.Text = "FhotoShopp";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage_Picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditedImage_Picturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog BrowseImageDialog;
        private System.Windows.Forms.SaveFileDialog SaveNewImageDialog;
        private System.Windows.Forms.Button BrowseForFile_Btn;
        private System.Windows.Forms.Button Greyscale_Btn;
        private System.Windows.Forms.Button Negative_Btn;
        private System.Windows.Forms.Button Blur_Btn;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.PictureBox OriginalImage_Picturebox;
        private System.Windows.Forms.PictureBox EditedImage_Picturebox;
    }
}

