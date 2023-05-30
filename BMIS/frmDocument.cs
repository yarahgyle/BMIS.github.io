using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security;

namespace BMIS
{
    public partial class frmDocument : Form
    {
        public frmDocument()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.CheckFileExists == true)
            {
                MessageBox.Show("OPENING SAMPLE DOCUMENT");
                // }

                // {
                try
                {

                    string filePath = openFileDialog2.FileName;
                    using (Stream str = openFileDialog2.OpenFile())
                    {
                        Process.Start("Winword.exe", filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.CheckFileExists == true)
            {
                MessageBox.Show("OPENING SAMPLE DOCUMENT");
           // }
           
           // {
                try
                {
                   
                    string filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        Process.Start("Winword.exe", filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            }
            
        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void printClearance_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.CheckFileExists == true)
            {
                MessageBox.Show("OPENING SAMPLE DOCUMENT");
                // }

                // {
                try
                {

                    string filePath = openFileDialog3.FileName;
                    using (Stream str = openFileDialog3.OpenFile())
                    {
                        Process.Start("Winword.exe", filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
