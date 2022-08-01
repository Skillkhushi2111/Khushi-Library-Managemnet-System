using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Khushi_Library_Managemnet_System
{
    public partial class View_Student_Information : Form
    {
        public View_Student_Information()
        {
            InitializeComponent();
        }

        private void txtSearchenrollment_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchenrollment.Text != "" ) 
            {
                label1.Visible = false;
               Image image = Image.FromFile("C:/Users/binod/Desktop/Liberay Management System Icon and Images/Liberay Management System/search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = " data Source=LAPTOP-S6G13NP5\\SQLEXPRESS;database =Newstudent;integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from student where Enroll LIKE '"+txtSearchenrollment.Text+"%'"; 
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                label1.Visible = false;
                Image image = Image.FromFile("C:/Users/binod/Desktop/Liberay Management System Icon and Images/Liberay Management System/search.gif");
                pictureBox1.Image = image;
            }
        }

        private void View_Student_Information_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = " data Source=LAPTOP-S6G13NP5\\SQLEXPRESS;database =Newstudent;integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from student";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = " data Source=LAPTOP-S6G13NP5\\SQLEXPRESS;database =Newstudent;integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from student where sid="+bid+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());

            txtSname.Text = DS.Tables[0].Rows[0][1].ToString();
            txtEnroll.Text = DS.Tables[0].Rows[0][2].ToString();
            txtDep.Text = DS.Tables[0].Rows[0][3].ToString();
            txtSem.Text = DS.Tables[0].Rows[0][4].ToString();
            txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String Sname = txtSname.Text;
            String Enroll = txtEnroll.Text;
            String Dep = txtDep.Text;
            String Sem= txtSem.Text;
            Int64 Contact = Int64.Parse(txtContact.Text);

            if (MessageBox.Show("Data will be Updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK);
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = " data Source=LAPTOP-S6G13NP5\\SQLEXPRESS;database =Newstudent;integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update student set Sname='" +Sname+ "', Enroll='" +Enroll+ "', Dep='" +Dep+ "', Sem='" +Sem +"',Contact='" +Contact+ "' where sid = "+rowid+" ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                View_Student_Information_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            View_Student_Information_Load(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be Deleted.Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK);
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = " data Source=LAPTOP-S6G13NP5\\SQLEXPRESS;database =Newstudent;integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Delete from student  where sid= " + rowid + " ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                View_Student_Information_Load(this, null);
            }
        }

        private void Sname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data will be Lost.", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
