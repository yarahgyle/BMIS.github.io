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
    public partial class frmViewHouseHold : Form
    {
        frmResidentList f;
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public frmViewHouseHold(frmResidentList f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select id, address, (lname + ', ' + fname + ' ' + mname) as fullname, bdate  from tblresident where house like '%" + lblHouseNo.Text + "%' and category like 'MEMBER'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["fullname"].ToString(), dr["bdate"].ToString(), dr["address"].ToString());
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
    }
}
