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
    public partial class frmResident : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        frmResidentList f;
        public string _id;
        public frmResident(frmResidentList f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring.connection);
            this.f = f;
            LoadPurok();
        }

        public void LoadPurok()
        {
            try
            {
                cboPurok.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblpurok", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cboPurok.Items.Add(dr["purok"].ToString());
                }
                dr.Close();
                cn.Close();
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = txtFname.Text + " " + txtMI.Text + " " + txtLname.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
                openFileDialog1.ShowDialog();
                picImage.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //validation for empty field

                if (MessageBox.Show("Do you want to save this record?",var._title,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cm = new SqlCommand("insert into tblresident (nid, lname, fname, mname, alias, bdate, bplace, age, ageclass, civilstatus, gender, religion, email, income, incomeclass,contact, voters, precinct, purok, educational, occupation, address, category, house, head, disability, pic)values(@nid, @lname, @fname, @mname, @alias, @bdate, @bplace, @age, @ageclass, @civilstatus, @gender, @religion, @email, @income, @incomeclass, @contact, @voters, @precinct, @purok, @educational, @occupation, @address, @category, @house, @head, @disability,@pic)",cn);
                    cm.Parameters.AddWithValue("@nid", txtID.Text);
                    cm.Parameters.AddWithValue("@lname", txtLname.Text);
                    cm.Parameters.AddWithValue("@fname", txtFname.Text);
                    cm.Parameters.AddWithValue("@mname", txtMI.Text);
                    cm.Parameters.AddWithValue("@alias", txtAlias.Text);
                    cm.Parameters.AddWithValue("@bdate", dtBdate.Value);
                    cm.Parameters.AddWithValue("@bplace", txtPlace.Text);
                    cm.Parameters.AddWithValue("@age", txtAge.Text);
                    cm.Parameters.AddWithValue("@ageclass", ageclass.Text);
                    cm.Parameters.AddWithValue("@civilstatus", cboCivil.Text);
                    cm.Parameters.AddWithValue("@gender", cboGender.Text);
                    cm.Parameters.AddWithValue("@religion", txtReligion.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@income", income.Text);
                    cm.Parameters.AddWithValue("@incomeclass", incomeclass.Text); 
                    cm.Parameters.AddWithValue("@contact", txtContact.Text);
                    cm.Parameters.AddWithValue("@voters", cboVoters.Text);
                    cm.Parameters.AddWithValue("@precinct", txtPrecinct.Text);
                    cm.Parameters.AddWithValue("@purok", cboPurok.Text);
                    cm.Parameters.AddWithValue("@educational", txtEducational.Text);
                    cm.Parameters.AddWithValue("@occupation", txtOccupation.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@category", cboCategory.Text);
                    cm.Parameters.AddWithValue("@house", txtHouse.Text);
                    cm.Parameters.AddWithValue("@head", txtHead.Text);
                    cm.Parameters.AddWithValue("@disability", cboDisability.Text);
                    //cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.Parameters.AddWithValue("@pic", arrImage);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.Loadrecords();
                }

            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.Text == "HEAD OF THE FAMILY")
            {
                txtHouse.Enabled = true;
                btnBrowse.Visible = false;
            }
            else
            {
                txtHouse.Enabled = false;
                btnBrowse.Visible = true;
            }
        }

        private void cboVoters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVoters.Text == "YES")  { txtPrecinct.Enabled = true; }else { txtPrecinct.Enabled = false; txtPrecinct.Clear(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for emoty

                if (MessageBox.Show("Do you want to update this record?", var._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cm = new SqlCommand("update tblresident set nid=@nid, lname=@lname, fname=@fname, mname=@mname, alias=@alias, bdate=@bdate, bplace=@bplace, age=@age, ageclass=@ageclass, civilstatus=@civilstatus, gender=@gender, religion=@religion, email=@email, income=@income, incomeclass=@incomeclass, contact=@contact, voters=@voters, precinct=@precinct, purok=@purok, educational=@educational, occupation=@occupation, address=@address, category=@category, house=@house, head=@head, disability=@disability,  pic=@pic where id =@id", cn);
                    cm.Parameters.AddWithValue("@nid", txtID.Text);
                    cm.Parameters.AddWithValue("@lname", txtLname.Text);
                    cm.Parameters.AddWithValue("@fname", txtFname.Text);
                    cm.Parameters.AddWithValue("@mname", txtMI.Text);
                    cm.Parameters.AddWithValue("@alias", txtAlias.Text);
                    cm.Parameters.AddWithValue("@bdate", dtBdate.Value);
                    cm.Parameters.AddWithValue("@bplace", txtPlace.Text);
                    cm.Parameters.AddWithValue("@age", txtAge.Text);
                    cm.Parameters.AddWithValue("@ageclass", ageclass.Text);
                    cm.Parameters.AddWithValue("@civilstatus", cboCivil.Text);
                    cm.Parameters.AddWithValue("@gender", cboGender.Text);
                    cm.Parameters.AddWithValue("@religion", txtReligion.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@income", income.Text);
                    cm.Parameters.AddWithValue("@incomeclass", incomeclass.Text) ;
                    cm.Parameters.AddWithValue("@contact", txtContact.Text);
                    cm.Parameters.AddWithValue("@voters", cboVoters.Text);
                    cm.Parameters.AddWithValue("@precinct", txtPrecinct.Text);
                    cm.Parameters.AddWithValue("@purok", cboPurok.Text);
                    cm.Parameters.AddWithValue("@educational", txtEducational.Text);
                    cm.Parameters.AddWithValue("@occupation", txtOccupation.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@category", cboCategory.Text);
                    cm.Parameters.AddWithValue("@house", txtHouse.Text);
                    cm.Parameters.AddWithValue("@head", txtHead.Text);
                    cm.Parameters.AddWithValue("@disability", cboDisability.Text);
                    //cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.Parameters.AddWithValue("@pic", arrImage);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", var._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                           f.Loadrecords();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var._title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Clear()
        {
            picImage.BackgroundImage = Image.FromFile(Application.StartupPath + @"\man1.png");
            txtAddress.Clear();
            txtAge.Clear();
            txtAlias.Clear();
            txtContact.Clear();
            txtEducational.Clear();
            txtEmail.Clear();
            txtFname.Clear();
            txtHead.Clear();
            txtHouse.Clear();
            txtID.Clear();
            txtLname.Clear();
            txtMI.Clear();
            txtOccupation.Clear();
            txtPlace.Clear();
            txtPrecinct.Clear();
            txtReligion.Clear();
            cboCategory.Text = "";
            cboCivil.Text = "";
            cboDisability.Text = "";
            cboGender.Text = "";
            cboPurok.Text = "";
            cboVoters.Text = "";
            dtBdate.Value = DateTime.Now;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtID.Focus();
        }

        private void dtBdate_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dtBdate.Value.Year;
            txtAge.Text = age.ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            frmHouseHold f = new frmHouseHold(this);
            f.LoadRecords();
            f.ShowDialog();
        }

        private void txtHead_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHouse_TextChanged(object sender, EventArgs e)
        {

        }

        private void agecombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                int numage = Convert.ToInt32(txtAge.Text);

                if (agecombo.Text == "Months")
                {
                    ageclass.Text = "INFANT";
                }
                else if (agecombo.Text == "Years" && numage <18)
                {
                    ageclass.Text = "MINOR";
                }
                else if (agecombo.Text == "Years" && numage >= 18 && numage < 60)
                {
                    ageclass.Text = "LEGAL AGE";
                    income.Enabled = true;
                }
                else if (agecombo.Text == "Years" && numage >= 60)
                {
                    ageclass.Text = "SENIOR";
                    income.Enabled = true;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Enter corrent value");
            }
          
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (txtAge.Text == "")
            {
                txtAge.Text = "0";
            }
            try
            {
                int numage = Convert.ToInt32(txtAge.Text);

                if (agecombo.Text == "Months")
                {
                    ageclass.Text = "INFANT";
                }
                else if (agecombo.Text == "Years" && numage < 18)
                {
                    ageclass.Text = "MINOR";
                }
                else if (agecombo.Text == "Years" && numage >= 18 && numage < 60)
                {
                    ageclass.Text = "LEGAL AGE";
                    income.Enabled = true;
                }
                else if (agecombo.Text == "Years" && numage >= 60)
                {
                    ageclass.Text = "SENIOR";
                    income.Enabled = true;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Enter corrent value");
            }
            
        }

        private void income_TextChanged(object sender, EventArgs e)
        {
            if (income.Text == "")
            {
                income.Text = "0";
            }
            try
            {
                double numincome = Convert.ToDouble(income.Text);

                if (numincome < 9649.47)
                {
                    incomeclass.Text = "POOR";
                }
                else if (numincome >= 9649.47 && numincome < 19928.94)
                {
                    incomeclass.Text = "LOW INCOME";
                }
                else if (numincome >= 19928.94 && numincome < 38597.88)
                {
                    incomeclass.Text = "LOWER MIDDLE INCOME";
                }
                else if (numincome >= 38597.88 && numincome < 96494.70)
                {
                    incomeclass.Text = "MIDDLE CLASS";
                }
                else if (numincome >= 96494.70 && numincome < 144742.05)
                {
                    incomeclass.Text = "UPPER MIDDLE INCOME";
                }
                else if (numincome >= 144742.05 && numincome < 192989.40)
                {
                    incomeclass.Text = "UPPER INCOME";
                }
                else if (numincome >= 192989.40)
                {
                    incomeclass.Text = "RICH";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter corrent value");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
