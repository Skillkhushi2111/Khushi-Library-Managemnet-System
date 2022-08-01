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
    public partial class Add_Book : Form
    {
        public Add_Book()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text!= "" && txtAuthor.Text != "" && txtPubli.Text != "" && txtPrice.Text != "" && txtQuan.Text != "")

                {
                String bname = txtBookName.Text;
                String bAuthor = txtAuthor.Text;
                String bPubli = txtPubli.Text;
                DateTime bDate = txtdateTimePicker.Value;
                Int64 bPrice = Int64.Parse(txtPrice.Text);
                Int64 bQuan = Int64.Parse(txtQuan.Text);


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data Source=LAPTOP-S6G13NP5\\SQLEXPRESS; database=library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Newbook(bname,bAuthor,bPubli,bDate,bPrice,bQuan) values ('" + bname + "','" + bAuthor + "','" + bPubli + "','" + bDate + "','" + bPrice + "'," + bQuan + ")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPubli.Clear();
                txtPrice.Clear();
                txtQuan.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Delete your Unsaved DATA.", "Are you Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
                {
                this.Close();
            }
        }
    }
}
