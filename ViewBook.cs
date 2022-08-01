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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

       

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= LAPTOP-S6G13NP5\\SQLEXPRESS; database=library;integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
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
            con.ConnectionString = "data source= LAPTOP-S6G13NP5\\SQLEXPRESS; database=library;integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook where bid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPubli.Text = ds.Tables[0].Rows[0][3].ToString();
            txtdateTimePicker1.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text= ds.Tables[0].Rows[0][5].ToString();
            txtQuan.Text= ds.Tables[0].Rows[0][6].ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if(txtBookName.Text!=  "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= LAPTOP-S6G13NP5\\SQLEXPRESS; database=library;integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook where bname LIKE '"+txtBookName.Text+ "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= LAPTOP-S6G13NP5\\SQLEXPRESS; database=library;integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }    }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _ = txtBName.Text;
            }
            String BName = txtBName.Text;
            string bauthor = txtAuthor.Text;
            String Publication = txtPubli.Text;
            DateTime pdate = txtdateTimePicker1.Value;
            Int64 Price = Int64.Parse(txtPrice.Text);
            Int64 quan = Int64.Parse(txtQuan.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= LAPTOP-S6G13NP5\\SQLEXPRESS; database=library;integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
 
            cmd.CommandText = "update NewBook set bname ='" +BName+ "',bAuthor ='" + bauthor + "',bPubli='" + Publication + "',bdate ='" + pdate + "', bPrice='" + Price + "', bQuan= " + quan + "  where bid=" + rowid + "";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted.Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= LAPTOP-S6G13NP5\\SQLEXPRESS; database=library;integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewBook where bid=" + rowid + "";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }

        }
    }
} 
