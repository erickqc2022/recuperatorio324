using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Detection_of_the_contours_of_objects_in_the_picture
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        #region-   Declaration of global variables   -
        //

        // Variable for storing original image
        Bitmap Original_image;


        // The program handles only the image saved in standard
        // JPEG or BMP 24 bits RGB format.
        // Eight bits (one byte) for each component of RGB color.
        const PixelFormat Allowed_RGB_pixel_format = PixelFormat.Format24bppRgb;

        public object Upper_Brightness_Limit { get; private set; }

        //
        #endregion

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
        }

        #region-    Input-Output part of the program   -
        void Image_1_Click(object sender, EventArgs e)
        {
            // Click on the image opens a dialog box
            // for selecting new image for processing, contour detection.
            DialogResult Choice = Load_Image_Dialog.ShowDialog();

            Refresh();

            if (Choice == DialogResult.OK)
            {
                string Document_Format = Load_Image_Dialog.FileName.Substring(Load_Image_Dialog.FileName.Length - 3, 3).ToUpper();
                if (Document_Format == "BMP" || Document_Format == "JPG")
                    Original_image = new Bitmap(Load_Image_Dialog.FileName);
                else
                    MessageBox.Show(" You have selected a document whose format does not match the supported formats (JPEG or BMP).    ",
                                    " Error!   ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                if (Original_image != null && Original_image.PixelFormat == Allowed_RGB_pixel_format)
                {
                    Image_1.Image = Original_image;

                    Start_Contour_Detection();
                }
                else
                    Original_image = null;
            }

            Refresh();
        }

        void Image_2_Click(object sender, EventArgs e)
        {
            // Click on the image opens a dialog box for saving new result image.
            bool Choice_ОК = false;

            if (Image_2.Image != null)
            {
                while (!Choice_ОК)
                {
                    DialogResult Choice = Save_Image_Dialog.ShowDialog();

                    Refresh();

                    if (Choice == DialogResult.OK && Save_Image_Dialog.FileName != Load_Image_Dialog.FileName)
                    {
                        string Document_Format = Load_Image_Dialog.FileName.Substring(Load_Image_Dialog.FileName.Length - 3, 3).ToUpper();
                        if (Document_Format == "JPG")
                        {
                            Image_2.Image.Save(Save_Image_Dialog.FileName, ImageFormat.Jpeg);
                            Choice_ОК = true;
                        }
                        else
                            MessageBox.Show(" You have selected a document whose format does not match the supported formats (JPEG or BMP).    ",
                                            " Error!   ",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                    }
                    else if (Choice == DialogResult.OK && Save_Image_Dialog.FileName == Load_Image_Dialog.FileName)
                        MessageBox.Show(" You have selected a document that is currently in use   \n" +
                                        " and it is not possible to overwrite it.   ",
                                        " Error!   ",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    else
                        Choice_ОК = true;
                }
            }
        }
        #endregion

        #region-   Main part of program   -
        //
        void Start_Contour_Detection()
        {
            Bitmap bmp = (Bitmap)Original_image.Clone();

            int Image_width = bmp.Width;
            int Image_height = bmp.Height;

            // Rectangle size
            Rectangle Rectangle = new Rectangle(0, 0, Image_width, Image_height);
            BitmapData bmp_Data = bmp.LockBits(Rectangle, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr bmp_First_byte_adress = bmp_Data.Scan0;
            int Number_of_pixels = Image_width * Image_height;
            int Number_of_bytes = Number_of_pixels * 3;
            int Exact_number_of_bytes_in_row = bmp_Data.Stride;
            int Necessary_number_of_bytes = Image_width * 3;
            //
            int Number_of_alignment_bytes = Exact_number_of_bytes_in_row - Necessary_number_of_bytes;

            Number_of_bytes += Image_height * Number_of_alignment_bytes;
  
            byte[] bmp_RGB_values = new byte[Number_of_bytes];


            Marshal.Copy(bmp_First_byte_adress, bmp_RGB_values, 0, Number_of_bytes);

            byte[,,] RGB = new byte[Image_width, Image_height, 3];

            float[,] Brightness = new float[Image_width, Image_height];

            int bmp_k = 0;

            for (int i = 0; i < Image_height; i++)
            {
                for (int j = 0; j < Image_width; j++)
                {
                    // Value of R component of pixel color
                    RGB[j, i, 0] = bmp_RGB_values[bmp_k + 2];

                    // Value of G component of pixel color
                    RGB[j, i, 1] = bmp_RGB_values[bmp_k + 1];

                    // Value of B component of pixel color
                    RGB[j, i, 2] = bmp_RGB_values[bmp_k + 0];

                    // Value of pixel brightness
                    Brightness[j, i] = Color.FromArgb
                        (
                            bmp_RGB_values[bmp_k + 2],
                            bmp_RGB_values[bmp_k + 1],
                            bmp_RGB_values[bmp_k + 0]
                        ).GetBrightness();

                    bmp_k += 3;
                }

                bmp_k += Number_of_alignment_bytes;
            }


            // Load lower and upper limit of the brightness 
            float lower_limit = (float)Lower_Brightness_Limit.Value;
            float upper_limit = (float)Upper_Brightness_Limit.Value;

            // Maximum found value for the difference in brightness 
            // between the opposing pixels
            float mfd = 0;

            for (int i = 1; i < Image_height - 1; i++)
            {
                for (int j = 1; j < Image_width - 1; j++)
                {

                    //
                    mfd = Math.Abs(Brightness[j - 1, i - 1] - Brightness[j + 1, i + 1]);

                    //
                    if (mfd < Math.Abs(Brightness[j - 1, i + 1] - Brightness[j + 1, i - 1]))
                        mfd = Math.Abs(Brightness[j - 1, i + 1] - Brightness[j + 1, i - 1]);

                    //
                    if (mfd < Math.Abs(Brightness[j, i + 1] - Brightness[j, i - 1]))
                        mfd = Math.Abs(Brightness[j, i + 1] - Brightness[j, i - 1]);

                    //
                    if (mfd < Math.Abs(Brightness[j - 1, i] - Brightness[j + 1, i]))
                        mfd = Math.Abs(Brightness[j - 1, i] - Brightness[j + 1, i]);

                    //
                    if (Invertir.Checked)
                    {
                        if (mfd < lower_limit)
                        {
                            RGB[j, i, 0] = (byte)255;
                            RGB[j, i, 1] = (byte)255;
                            RGB[j, i, 2] = (byte)255;
                        }
                        else if (mfd > upper_limit)
                        {
                            RGB[j, i, 0] = (byte)0;
                            RGB[j, i, 1] = (byte)0;
                            RGB[j, i, 2] = (byte)0;
                        }
                    }
                    else
                    {
                        if (mfd < lower_limit)
                        {
                            RGB[j, i, 0] = (byte)0;
                            RGB[j, i, 1] = (byte)0;
                            RGB[j, i, 2] = (byte)0;
                        }
                        else if (mfd > upper_limit)
                        {
                            RGB[j, i, 0] = (byte)255;
                            RGB[j, i, 1] = (byte)255;
                            RGB[j, i, 2] = (byte)255;
                        }
                    }

                }
            }


            if (Black_White.Checked)
            {
                for (int i = 1; i < Image_height - 1; i++)
                {
                    for (int j = 1; j < Image_width - 1; j++)
                    {
                        if (Invertirr.Checked)
                        {
                            if (RGB[j, i, 0] < 255 || RGB[j, i, 1] < 255 || RGB[j, i, 2] < 255)
                                RGB[j, i, 0] = RGB[j, i, 1] = RGB[j, i, 2] = (byte)0;
                        }
                        else
                        {
                            if (RGB[j, i, 0] > 0 || RGB[j, i, 1] > 0 || RGB[j, i, 2] > 0)
                                RGB[j, i, 0] = RGB[j, i, 1] = RGB[j, i, 2] = (byte)255;
                        }
                    }
                }
            }


            if (Gray_Scale.Checked)
            {
                for (int i = 1; i < Image_height - 1; i++)
                {
                    for (int j = 1; j < Image_width - 1; j++)
                    {
                        RGB[j, i, 0] = RGB[j, i, 1] = RGB[j, i, 2] =
                            (byte)
                            (
                                (0.299 * RGB[j, i, 0]) +
                                (0.587 * RGB[j, i, 1]) +
                                (0.114 * RGB[j, i, 2])
                            );
                    }
                }
            }


            // Byte counter inside one dimenzional matrix
            bmp_k = 0;

            // Copy new bitmap values of RGB components of color of pixels,
            // from two dimenzional to one dimenzional matrix
            for (int i = 0; i < Image_height; i++)
            {
                for (int j = 0; j < Image_width; j++)
                {
                    // Value of R component of pixel color
                    bmp_RGB_values[bmp_k + 2] = RGB[j, i, 0];

                    // Value of G component of pixel color
                    bmp_RGB_values[bmp_k + 1] = RGB[j, i, 1];

                    // Value of B component of pixel color
                    bmp_RGB_values[bmp_k + 0] = RGB[j, i, 2];

                    bmp_k += 3;
                }

                bmp_k += Number_of_alignment_bytes;
            }

            // Copy new values of RGB components of pixel color from matrix back to bitmap
            Marshal.Copy(bmp_RGB_values, 0, bmp_First_byte_adress, Number_of_bytes);

            // Unlock bitmap inside memory
            bmp.UnlockBits(bmp_Data);

            // Show the processed image
            Image_2.Image = bmp;
        }
        //
        #endregion

        #region-   Event process, part of program   -
        void Process_Image()
        {
            // Start new contour detection
            if (Original_image != null)
                Start_Contour_Detection();
        }

        void Invert_Edge_Color_CheckedChanged(object sender, EventArgs e)
        {
            Process_Image();
        }

        void RGB_CheckedChanged(object sender, EventArgs e)
        {
            if (RGB.Checked)
                Process_Image();
        }

        void Black_White_CheckedChanged(object sender, EventArgs e)
        {
            if (Black_White.Checked)
                Process_Image();
        }

        void Gray_Scale_CheckedChanged(object sender, EventArgs e)
        {
            if (Gray_Scale.Checked)
                Process_Image();
        }

        void Lower_Brightness_Limit_ValueChanged(object sender, EventArgs e)
        {
            Process_Image();
        }

        void Upper_Brightness_Limit_ValueChanged(object sender, EventArgs e)
        {
            Process_Image();
        }

        private class Invertirr
        {
        }
        #endregion
    }
}