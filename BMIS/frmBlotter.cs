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
    public partial class frmBlotter : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        FrmIssue f;
       
        public frmBlotter(FrmIssue f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;
        }

        public string GetFileNo()
        {
            string fileno = DateTime.Now.Year.ToString();
            Random rnd = new Random();
            try
            {
                for (int x=0; x<4; x++)
                {
                    fileno += rnd.Next(1, 9).ToString();
                }
                
            }
            catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return fileno;
        }
        private void frmBlotter_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cancelblotter_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSaveblotter_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this blotter?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblBlotter (fileno, barangay, purok, incident, place, idate, itime, complainant, witness1, witness2, narrative, status) values (@fileno, @barangay, @purok, @incident, @place, @idate, @itime, @complainant, @witness1, @witness2, @narrative, @status)", cn);
                    
                    cm.Parameters.AddWithValue("@fileno", filenotxt.Text);
                    cm.Parameters.AddWithValue("@barangay", txtBrngy.Text);
                    cm.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cm.Parameters.AddWithValue("@incident", txtIncident.Text);
                    cm.Parameters.AddWithValue("@place", txtPlaceinc.Text);
                    cm.Parameters.AddWithValue("@idate", DateTime.Parse(dateinc.Value.ToLongDateString()));
                    cm.Parameters.AddWithValue("@itime", timeinc.Text);
                    cm.Parameters.AddWithValue("@complainant", txtComplainant.Text);
                    cm.Parameters.AddWithValue("@witness1", txtWit1.Text);
                    cm.Parameters.AddWithValue("@witness2", txtWit2.Text);
                    cm.Parameters.AddWithValue("@narrative", txtNarrative.Text);
                    cm.Parameters.AddWithValue("@status", statustxt.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    f.LoadRecord();
                }
            }
            catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void clear()
        {
            txtBrngy.Clear();
            txtPurok.Clear();
            txtIncident.Clear();
            txtPlaceinc.Clear();
            txtComplainant.Clear();
            txtNarrative.Clear();
            txtWit1.Clear();
            txtWit2.Clear();
            timeinc.Clear();
            dateinc.Value = DateTime.Today;
            btnSaveblotter.Enabled = false;
            txtBrngy.Focus();

        }

        private void btnUpdateblotter_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for emoty

                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

            
                    cn.Open();
                    cm = new SqlCommand("update tblBlotter set fileno=@fileno, barangay=@barangay, purok=@purok, incident=@incident, place=@place, idate=@idate, itime=@itime, complainant=@complainant, witness1=@witness1, witness2=@witness2, narrative=@narrative, status=@status where id =@id", cn);
                    cm.Parameters.AddWithValue("@id", __id.Text);
                    cm.Parameters.AddWithValue("@fileno", filenotxt.Text);
                    cm.Parameters.AddWithValue("@barangay", txtBrngy.Text);
                    cm.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cm.Parameters.AddWithValue("@incident", txtIncident.Text);
                    cm.Parameters.AddWithValue("@place", txtPlaceinc.Text);
                    cm.Parameters.AddWithValue("@idate", DateTime.Parse(dateinc.Value.ToLongDateString()));
                    cm.Parameters.AddWithValue("@itime", timeinc.Text);
                    cm.Parameters.AddWithValue("@complainant", txtComplainant.Text);
                    cm.Parameters.AddWithValue("@witness1", txtWit1.Text);
                    cm.Parameters.AddWithValue("@witness2", txtWit2.Text);
                    cm.Parameters.AddWithValue("@narrative", txtNarrative.Text);
                    cm.Parameters.AddWithValue("@status", statustxt.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecord();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
