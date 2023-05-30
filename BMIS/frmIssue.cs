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
using System.IO; 

namespace BMIS
{
    public partial class FrmIssue : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public FrmIssue()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void addBlotter_Click(object sender, EventArgs e)
        {
            frmBlotter f = new frmBlotter(this);
            f.filenotxt.Text = f.GetFileNo();
            f.btnUpdateblotter.Enabled = false;
            f.ShowDialog();
        }
        public void LoadRecord()
        {
            try
            {
                blottergrid.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblBlotter", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    blottergrid.Rows.Add(dr["id"].ToString(), dr["fileno"].ToString(), dr["barangay"].ToString(), dr["purok"].ToString(), dr["incident"].ToString(), dr["place"].ToString(), DateTime.Parse(dr["idate"].ToString()).ToShortDateString(), dr["itime"].ToString(), dr["complainant"].ToString(), dr["witness1"].ToString(), dr["witness2"].ToString(), dr["narrative"].ToString(), dr["status"].ToString());
                }
                dr.Close();
                cn.Close();
                blottergrid.ClearSelection();
                lblCaseCount.Text = CountRecords("select count(*) from tblBlotter");
                lblCaseSet.Text = CountRecords("select count(*) from tblBlotter where status like 'Settled'");
            }
            catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string CountRecords(string sql)
        {
            cn.Open();
            cm = new SqlCommand(sql, cn);
            string _count = cm.ExecuteScalar().ToString();
            cn.Close();
            return _count;
        }
        private void dataGridBlotter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void blottergrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = blottergrid.Columns[e.ColumnIndex].Name;
                if (colname == "btnEditblot")
                {
                    frmBlotter f = new frmBlotter(this);
                    cn.Open();
                    cm = new SqlCommand("select * from tblBlotter where id like '" + blottergrid.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        //long len = dr.GetBytes(0, 0, null, 0, 0);
                        //byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        //dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        f.__id.Text = dr["id"].ToString();
                        f.filenotxt.Text = dr["fileno"].ToString();
                        f.txtBrngy.Text = dr["barangay"].ToString();
                        f.txtPurok.Text = dr["purok"].ToString();
                        f.txtIncident.Text = dr["incident"].ToString();
                        f.txtPlaceinc.Text = dr["place"].ToString();
                        f.dateinc.Text = dr["idate"].ToString();
                        f.timeinc.Text = dr["itime"].ToString();
                        f.txtComplainant.Text = dr["complainant"].ToString();
                        f.txtWit1.Text = dr["witness1"].ToString();
                        f.txtWit2.Text = dr["witness2"].ToString();
                        f.txtNarrative.Text = dr["narrative"].ToString();
                        f.statustxt.Text = dr["status"].ToString();

                        //MemoryStream ms = new MemoryStream(array);
                        //Bitmap bitmap = new Bitmap(ms);
                        
                        f.btnSaveblotter.Enabled = false;
                    }
                    dr.Close();
                    cn.Close();
                    f.ShowDialog();
                }
                else if (colname == "btnDeleteblot")
                {
                    if (MessageBox.Show("Do you want to delte this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblBlotter where id  like '" + blottergrid.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
