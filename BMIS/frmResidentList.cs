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
    public partial class frmResidentList : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public frmResidentList()
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
            frmResident f = new frmResident(this);
            f.btnUpdate.Enabled = false;
            f.Clear();
            f.ShowDialog();
        }

        public void Loadrecords()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblresident where lname like '%" + txtSearch.Text + "%' or fname like '%" + txtSearch.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["nid"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["alias"].ToString(), dr["address"].ToString(), dr["house"].ToString(), dr["category"].ToString(), DateTime.Parse(dr["bdate"].ToString()).ToShortDateString(), dr["age"].ToString(), dr["gender"].ToString(), dr["civilstatus"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
                lblCount.Text = CountRecords("select count(*) from tblresident");
                lblHousehold.Text = CountRecords("select count(*) from tblresident where category like 'HEAD OF THE FAMILY'");
                lblMember.Text = CountRecords("select count(*) from tblresident where category like 'MEMBER'");
                lblVoters.Text = CountRecords("select count(*) from tblresident where voters like 'YES'");
                lblFemale.Text = CountRecords("select count(*) from tblresident where gender like 'FEMALE'");
                lblMale.Text = CountRecords("select count(*) from tblresident where gender like 'MALE'");
                lblVaccination.Text = CountRecords("select count(*) from tblvaccine where status like 'FULLY VACCINATED'");
                infantcount.Text = CountRecords("select count(*) from tblresident where ageclass like 'INFANT'");
                minorcount.Text = CountRecords("select count(*) from tblresident where ageclass like 'MINOR'");
                legalcount.Text = CountRecords("select count(*) from tblresident where ageclass like 'LEGAL AGE'");
                seniorcount.Text = CountRecords("select count(*) from tblresident where ageclass like 'SENIOR'");
                poorcount.Text = CountRecords("select count(*) from tblresident where incomeclass like 'POOR'");
                lowincomecount.Text = CountRecords("select count(*) from tblresident where incomeclass like 'LOW INCOME'");
                lowmidcount.Text = CountRecords("select count(*) from tblresident where incomeclass like 'LOWER MIDDLE INCOME'");
                middlecount.Text = CountRecords("select count(*) from tblresident where incomeclass like 'MIDDLE CLASS'");
                uppermidcount.Text = CountRecords("select count(*) from tblresident where incomeclass like 'UPPER MIDDLE INCOME'");
                upperincomecount.Text = CountRecords("select count(*) from tblresident where incomeclass like 'UPPER INCOME'");
                richcount.Text = CountRecords("select count(*) from tblresident where incomeclass like 'RICH'");
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void LoadHead()
        {
            try
            {
                dataGridView2.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblresident where (lname like '%" + txtSearch1.Text + "%' or fname like '%" + txtSearch.Text + "%') and category like 'HEAD OF THE FAMILY'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr["id"].ToString(), dr["nid"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["alias"].ToString(), dr["address"].ToString(), dr["house"].ToString(), dr["category"].ToString(), DateTime.Parse(dr["bdate"].ToString()).ToShortDateString(), dr["age"].ToString(), dr["gender"].ToString(), dr["civilstatus"].ToString());
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

        public void LoadVaccination()
        {
            try
            {
                dataGridView3.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from vwvaccination where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and status like '" + cboStatus.Text + "'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView3.Rows.Add(dr["id"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["vaccine"].ToString(), dr["status"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView3.ClearSelection();

            }
            catch (Exception ex)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if(colname == "btnEdit")
                {
                    frmResident f = new frmResident(this);
                    f.LoadPurok();
                    cn.Open();
                    cm = new SqlCommand("select pic as picture, * from tblresident where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        long len = dr.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        f._id = dr["id"].ToString();
                        f.txtID.Text = dr["nid"].ToString();
                        f.txtLname.Text = dr["lname"].ToString();
                        f.txtFname.Text = dr["fname"].ToString();
                        f.txtMI.Text = dr["mname"].ToString();
                        f.txtAddress.Text = dr["address"].ToString();
                        f.txtAge.Text = dr["age"].ToString();
                        f.txtAlias.Text = dr["alias"].ToString();
                        f.txtContact.Text = dr["contact"].ToString();
                        f.txtEducational.Text = dr["educational"].ToString();
                        f.txtEmail.Text = dr["email"].ToString();
                        f.txtHead.Text = dr["head"].ToString();
                        f.txtHouse.Text = dr["house"].ToString();
                        f.txtOccupation.Text = dr["occupation"].ToString();
                        f.txtPlace.Text = dr["bplace"].ToString();
                        f.txtPrecinct.Text = dr["precinct"].ToString();
                        f.txtReligion.Text = dr["religion"].ToString();
                        f.cboCategory.Text = dr["category"].ToString();
                        f.cboCivil.Text  = dr["civilstatus"].ToString();
                        f.cboDisability.Text = dr["disability"].ToString();
                        f.cboGender.Text = dr["gender"].ToString();
                        f.cboPurok.Text = dr["purok"].ToString();
                       //f.cboStatus.Text = dr["status"].ToString();
                        f.cboVoters.Text = dr["voters"].ToString();
                        f.dtBdate.Value = DateTime.Parse(dr["bdate"].ToString());
                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmap = new Bitmap(ms);
                        f.picImage.BackgroundImage = bitmap;
                        f.btnSave.Enabled = false;
                    }
                    dr.Close();
                    cn.Close();
                    f.ShowDialog();
                }else if (colname == "btnDelete")
                {
                    if (MessageBox.Show("Do you want to delte this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblresident where id  like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        cn.Open();
                        cm = new SqlCommand("delete from tblVaccine where rid  like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully deleted!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loadrecords();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadAgeClass()
        {


            try
            {
                dataGridView4.Rows.Clear();
                cn.Open();
                if (ageclasscombo.Text == "0-11 months")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and ageclass like 'INFANT'", cn);
                }
                else if(ageclasscombo.Text == "1-4 y/o")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and ageclass not like 'INFANT' and age <= 4", cn);
                }
                else if (ageclasscombo.Text == "5-9 y/o")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and ageclass not like 'INFANT' and age >=5 and age <=9", cn);
                }
                else if (ageclasscombo.Text == "10-14 y/o")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and ageclass not like 'INFANT' and age >=10 and age <= 14", cn);
                }
                else if (ageclasscombo.Text == "15-16 y/o")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and age>=15 and age <= 16", cn);
                }
                else if (ageclasscombo.Text == "17-20 y/o")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and age >=17 and age <= 20", cn);
                }
                else if (ageclasscombo.Text == "21-59 y/o")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and age>= 21 and age <= 59", cn);
                }
                else if (ageclasscombo.Text == "60 y/o above")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and age >= 60", cn);
                }
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView4.Rows.Add(dr["id"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["gender"].ToString(), dr["age"].ToString(), dr["ageclass"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView4.ClearSelection();
                 
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadIncomeClass()
        {


            try
            {
                dataGridView5.Rows.Clear();
                cn.Open();
                if (incomeclasscombo.Text == "Poor")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and incomeclass like 'POOR'", cn);
                }
                else if (incomeclasscombo.Text == "Low Income")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and incomeclass like 'LOW INCOME'", cn);
                }
                else if (incomeclasscombo.Text == "Lower Middle Income")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and incomeclass like 'LOWER MIDDLE INCOME'", cn);
                }
                else if (incomeclasscombo.Text == "Middle Class")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and incomeclass like 'MIDDLE CLASS'", cn);
                }
                else if (incomeclasscombo.Text == "Upper Middle Income")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and incomeclass like 'UPPER MIDDLE INCOME'", cn);
                }
                else if (incomeclasscombo.Text == "Upper Income")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and incomeclass like 'UPPER INCOME'", cn);
                }
                else if (incomeclasscombo.Text == "Rich")
                {
                    cm = new SqlCommand("select * from tblresident where (lname like '%" + metroTextBox1.Text + "%' or fname like '%" + metroTextBox1.Text + "%') and incomeclass like 'RICH'", cn);
                }
      
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView5.Rows.Add(dr["id"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["gender"].ToString(), dr["income"].ToString(), dr["incomeclass"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView5.ClearSelection();

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Loadrecords();
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            LoadHead();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           try
            {
                string colName = dataGridView2.Columns[e.ColumnIndex].Name;
                if (colName == "btnView")
                {
                    string _id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    frmViewHouseHold f = new frmViewHouseHold(this);
                    cn.Open();
                    cm = new SqlCommand("select (lname + ', ' + fname + ' ' + mname) as fullname, house from tblresident where id =@id", cn);
                    cm.Parameters.AddWithValue("@id", _id);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        f.lblHouseNo.Text = dr["house"].ToString();
                        f.lblname.Text = dr["fullname"].ToString();
                    }
                    dr.Close();
                    cn.Close();
                    f.LoadRecord();
                    f.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title,MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView3.Columns[e.ColumnIndex].Name;
            if (colname == "colEditVaccination")
            {
                frmVaccination f = new frmVaccination(this);
                f._id = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                f.lblname.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString() + ", " + dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString() ;
                f.txtVaccine.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.cboStatus.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.ShowDialog();
            }
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVaccination();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            LoadVaccination();
        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ageclasscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAgeClass();
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void seniorcount_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIncomeClass();
        }
    }
}
