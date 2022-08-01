using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Khushi_Library_Managemnet_System
{
    public partial class Addstudent : Form
    {
        public Addstudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();


        }

        private void btnSaveinfo_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEnrollment.Text != "" && txtDepartment.Text != "" && txtSemester.Text != "" && txtContact.Text != "")
            { 
            String name = txtName.Text;
            String enroll = txtEnrollment.Text;
            string Dep = txtDepartment.Text;
            String Sem = txtSemester.Text;
            Int64 mobile = Int64.Parse(txtContact.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-S6G13NP5\\SQLEXPRESS; database = Newstudent ;integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = " insert into student(Sname,Enroll,Dep,Sem,Contact) values ('" + name + "','" + enroll + "','" + Dep + "','" + Sem + "','" + mobile + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Please Fill Empty Fields","Suggest",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            


        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
