using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BMIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = SetImageOpacity(panel3.BackgroundImage, 0.25F);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int y = Screen.PrimaryScreen.Bounds.Height;
            int x = Screen.PrimaryScreen.Bounds.Width;
            this.Height = y - 30;
            this.Width = x;
            this.Left = 0;
            this.Top = 0;
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            frmDocument f = new frmDocument();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            frmMaintenance f = new frmMaintenance();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.LoadPurok();
            f.BringToFront();
            f.Show();
        }

        private void btnResident_Click(object sender, EventArgs e)
        {
            frmResidentList f = new frmResidentList();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.BringToFront();
            f.Loadrecords();
            f.LoadVaccination();
            f.LoadHead();
            f.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmIssue f = new FrmIssue();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.BringToFront();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        
    }
}
