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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data Source =LAPTOP-S6G13NP5\\SQLEXPRESS;database = library;integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bname from NewbooK", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for(int i=0; i < sdr.FieldCount; i++)
                {
                    ComboBoxBooks.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();

        }

        private void txtEnrollement_TextChanged(object sender, EventArgs e)
        {

        }


        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtEnrollment.Text != "")
            {
                string eid =txtEnrollment.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data Source =LAPTOP-S6G13NP5\\SQLEXPRESS;database = Newstudent;integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from student where Enroll= '" +eid+ "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                //-----------------------------------------------------------------
                //COde to Count how mnay book has been issued on this enrollment number
                cmd.CommandText = "Select count(std_enroll) from IRBook where std_enroll = '" + eid + "' and book_return_date is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());


                if (DS.Tables[0].Rows.Count !=0)
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtDep.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtSem.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = DS.Tables[0].Rows[0][5].ToString();

                }
                else
                {
                    txtName.Clear();
                    txtDep.Clear();
                    txtSem.Clear();
                    txtContact.Clear();
                    MessageBox.Show("Invalid enrollement No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollment.Text =="")
            {
                txtName.Clear();
                txtDep.Clear();
                txtSem.Clear();
                txtContact.Clear();

            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                if (ComboBoxBooks.SelectedIndex != -1  && count <= 2)
                {
                    string enroll = txtEnrollment.Text;
                    String sname = txtName.Text;
                    String Sdep = txtDep.Text;
                    String Sem = txtSem.Text;
                    Int64 Contact = Int64.Parse(txtContact.Text);
                    String bookname = ComboBoxBooks.Text;
                    String bookIssueDate = dateTimePicker.Text;

                    string eid = txtEnrollment.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data Source =LAPTOP-S6G13NP5\\SQLEXPRESS;database = Newstudent;integrated security=True ";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "insert into IRBook(std_enroll,std_name,std_Dep,std_Sem,std_Contact,book_name,book_issue_date)values('"+enroll+"','"+sname+"','"+Sdep+"','"+Sem+"','"+Contact+"','"+bookname+"','"+bookIssueDate+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Select Book.OR Maximum number of Book Has been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollment.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    } 
}
