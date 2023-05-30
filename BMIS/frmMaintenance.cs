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
    public partial class frmMaintenance : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public frmMaintenance()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOfficials f = new frmOfficials(this);
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }

        public void LoadRecord()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblofficial", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["name"].ToString(), dr["chairmanship"].ToString(), dr["position"].ToString(), DateTime.Parse(dr["termstart"].ToString()).ToShortDateString(), DateTime.Parse(dr["termend"].ToString()).ToShortDateString(), dr["status"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadPurok()
        {
            try
            {
                dataGridView2.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblpurok", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr["purok"].ToString(), dr["chairman"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit1")
                {
                    frmOfficials f = new frmOfficials(this);
                    f.btnSave.Enabled = false;
                    f._id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.cboChairmanship.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.cboPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    f.dtStart.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    f.dtEnd.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    f.cboStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    f.ShowDialog();
                }else if(colName == "btnDelete1")
                {
                    if(MessageBox.Show("Do you want to delete this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblofficial where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecord();
                    }
                }
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView2.Columns[e.ColumnIndex].Name;
                if (colName == "btnEdit2")
                {
                    frmPurok f = new frmPurok(this);
                    f.btnSave.Enabled = false;
                    f._purok = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtPurok.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.txtChairman.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.ShowDialog();
                }
                else if (colName == "btnDelete2")
                {
                    if (MessageBox.Show("Do you want to delete this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblpurok where purok like '" + dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPurok();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPurok f = new frmPurok(this);
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }
     
    }
}
