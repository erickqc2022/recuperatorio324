
namespace Detection_of_the_contours_of_objects_in_the_picture
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.Image_1 = new System.Windows.Forms.PictureBox();
            this.Image_2 = new System.Windows.Forms.PictureBox();
            this.Load_Image_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.Invertirr = new System.Windows.Forms.CheckBox();
            this.propiedadesColor = new System.Windows.Forms.GroupBox();
            this.Gray_Scale = new System.Windows.Forms.RadioButton();
            this.Black_White = new System.Windows.Forms.RadioButton();
            this.RGB = new System.Windows.Forms.RadioButton();
            this.Lower_Brightness_Limit = new System.Windows.Forms.NumericUpDown();
            this.Upper_Brightness_Limit = new System.Windows.Forms.NumericUpDown();
            this.cajaGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Save_Image_Dialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Image_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_2)).BeginInit();
            this.propiedadesColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lower_Brightness_Limit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upper_Brightness_Limit)).BeginInit();
            this.cajaGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Image_1
            // 
            this.Image_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Image_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Image_1.Location = new System.Drawing.Point(12, 12);
            this.Image_1.Name = "Image_1";
            this.Image_1.Size = new System.Drawing.Size(600, 400);
            this.Image_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image_1.TabIndex = 0;
            this.Image_1.TabStop = false;
            this.Image_1.Click += new System.EventHandler(this.Image_1_Click);
            // 
            // Image_2
            // 
            this.Image_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Image_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Image_2.Location = new System.Drawing.Point(660, 12);
            this.Image_2.Name = "Image_2";
            this.Image_2.Size = new System.Drawing.Size(600, 400);
            this.Image_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image_2.TabIndex = 1;
            this.Image_2.TabStop = false;
            this.Image_2.Click += new System.EventHandler(this.Image_2_Click);
            // 
            // Invertirr
            // 
            this.Invertirr.Location = new System.Drawing.Point(413, 29);
            this.Invertirr.Name = "Invertirr";
            this.Invertirr.Size = new System.Drawing.Size(179, 26);
            this.Invertirr.TabIndex = 4;
            this.Invertirr.Text = " Invert edge color";
            this.Invertirr.UseVisualStyleBackColor = true;
            this.Invertirr.CheckedChanged += new System.EventHandler(this.Invert_Edge_Color_CheckedChanged);
            // 
            // propiedadesColor
            // 
            this.propiedadesColor.Controls.Add(this.Gray_Scale);
            this.propiedadesColor.Controls.Add(this.Invertirr);
            this.propiedadesColor.Controls.Add(this.Black_White);
            this.propiedadesColor.Controls.Add(this.RGB);
            this.propiedadesColor.Location = new System.Drawing.Point(660, 418);
            this.propiedadesColor.Name = "propiedadesColor";
            this.propiedadesColor.Size = new System.Drawing.Size(600, 66);
            this.propiedadesColor.TabIndex = 13;
            this.propiedadesColor.TabStop = false;
            this.propiedadesColor.Text = "Type of display of the processed image";
            // 
            // Gray_Scale
            // 
            this.Gray_Scale.Location = new System.Drawing.Point(288, 31);
            this.Gray_Scale.Name = "Gray_Scale";
            this.Gray_Scale.Size = new System.Drawing.Size(122, 24);
            this.Gray_Scale.TabIndex = 2;
            this.Gray_Scale.Text = "Gray scale";
            this.Gray_Scale.UseVisualStyleBackColor = true;
            this.Gray_Scale.CheckedChanged += new System.EventHandler(this.Gray_Scale_CheckedChanged);
            // 
            // Black_White
            // 
            this.Black_White.Location = new System.Drawing.Point(142, 31);
            this.Black_White.Name = "Black_White";
            this.Black_White.Size = new System.Drawing.Size(140, 24);
            this.Black_White.TabIndex = 1;
            this.Black_White.Text = "Black and White";
            this.Black_White.UseVisualStyleBackColor = true;
            this.Black_White.CheckedChanged += new System.EventHandler(this.Black_White_CheckedChanged);
            // 
            // RGB
            // 
            this.RGB.Checked = true;
            this.RGB.Location = new System.Drawing.Point(16, 31);
            this.RGB.Name = "RGB";
            this.RGB.Size = new System.Drawing.Size(110, 24);
            this.RGB.TabIndex = 0;
            this.RGB.TabStop = true;
            this.RGB.Text = "RGB Color";
            this.RGB.UseVisualStyleBackColor = true;
            this.RGB.CheckedChanged += new System.EventHandler(this.RGB_CheckedChanged);
            // 
            // Lower_Brightness_Limit
            // 
            this.Lower_Brightness_Limit.DecimalPlaces = 2;
            this.Lower_Brightness_Limit.Increment = new decimal(new int[] {
                                    1,
                                    0,
                                    0,
                                    131072});
            this.Lower_Brightness_Limit.Location = new System.Drawing.Point(136, 31);
            this.Lower_Brightness_Limit.Maximum = new decimal(new int[] {
                                    1,
                                    0,
                                    0,
                                    0});
            this.Lower_Brightness_Limit.Name = "Lower_Brightness_Limit";
            this.Lower_Brightness_Limit.Size = new System.Drawing.Size(124, 26);
            this.Lower_Brightness_Limit.TabIndex = 11;
            this.Lower_Brightness_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Lower_Brightness_Limit.Value = new decimal(new int[] {
                                    10,
                                    0,
                                    0,
                                    131072});
            this.Lower_Brightness_Limit.ValueChanged += new System.EventHandler(this.Lower_Brightness_Limit_ValueChanged);
            // 
            // Upper_Brightness_Limit
            // 
            this.Upper_Brightness_Limit.DecimalPlaces = 2;
            this.Upper_Brightness_Limit.Increment = new decimal(new int[] {
                                    1,
                                    0,
                                    0,
                                    131072});
            this.Upper_Brightness_Limit.Location = new System.Drawing.Point(337, 30);
            this.Upper_Brightness_Limit.Maximum = new decimal(new int[] {
                                    1,
                                    0,
                                    0,
                                    0});
            this.Upper_Brightness_Limit.Name = "Upper_Brightness_Limit";
            this.Upper_Brightness_Limit.Size = new System.Drawing.Size(124, 26);
            this.Upper_Brightness_Limit.TabIndex = 17;
            this.Upper_Brightness_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Upper_Brightness_Limit.Value = new decimal(new int[] {
                                    10,
                                    0,
                                    0,
                                    131072});
            this.Upper_Brightness_Limit.ValueChanged += new System.EventHandler(this.Upper_Brightness_Limit_ValueChanged);
            // 
            // cajaGroup
            // 
            this.cajaGroup.Controls.Add(this.label3);
            this.cajaGroup.Controls.Add(this.label2);
            this.cajaGroup.Controls.Add(this.label1);
            this.cajaGroup.Controls.Add(this.Upper_Brightness_Limit);
            this.cajaGroup.Controls.Add(this.Lower_Brightness_Limit);
            this.cajaGroup.Location = new System.Drawing.Point(12, 418);
            this.cajaGroup.Name = "cajaGroup";
            this.cajaGroup.Size = new System.Drawing.Size(600, 66);
            this.cajaGroup.TabIndex = 15;
            this.cajaGroup.TabStop = false;
            this.cajaGroup.Text = "Lower and upper limit of value for brightness of pixel ( 0 - 1 )";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(467, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = ">>  edge";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(53, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = " edge  <<";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(266, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "PIXEL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Save_Image_Dialog
            // 
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1272, 571);
            this.Controls.Add(this.cajaGroup);
            this.Controls.Add(this.propiedadesColor);
            this.Controls.Add(this.Image_2);
            this.Controls.Add(this.Image_1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Bolivia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.Text = "Detection of the contours of objects in the picture";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Image_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_2)).EndInit();
            this.propiedadesColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Lower_Brightness_Limit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upper_Brightness_Limit)).EndInit();
            this.cajaGroup.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.SaveFileDialog Save_Image_Dialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Upper_Brightness_Limit;
        private System.Windows.Forms.GroupBox cajaGroup;
        private System.Windows.Forms.RadioButton RGB;
        private System.Windows.Forms.RadioButton Black_White;
        private System.Windows.Forms.RadioButton Gray_Scale;
        private System.Windows.Forms.GroupBox propiedadesColor;
        private System.Windows.Forms.NumericUpDown Lower_Brightness_Limit;
        private System.Windows.Forms.CheckBox Invertirr;
        private System.Windows.Forms.OpenFileDialog Load_Image_Dialog;
        private System.Windows.Forms.PictureBox Image_2;
        private System.Windows.Forms.PictureBox Image_1;
    }
}
