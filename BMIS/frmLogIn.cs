using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BMIS
{
    public partial class Login : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataAdapter adp;
        public Login()
        {
            cn = new SqlConnection(dbconstring.connection);
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;

            

            try
            {
                cn.Open();
                string cm ="SELECT * From tblUsers where username= '"+username+"' and password = '"+password+"'";
                adp = new SqlDataAdapter(cm, cn);

                DataTable datatbl = new DataTable();
                adp.Fill(datatbl);
                if(datatbl.Rows.Count > 0 )
                {
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }


            }
            catch
            {
                MessageBox.Show("Please enter Username and Password");
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
