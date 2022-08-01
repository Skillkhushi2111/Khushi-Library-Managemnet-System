namespace Khushi_Library_Managemnet_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Clear();
            }
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Clear();
                txtpassword.PasswordChar = '*';
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ysss.edu.np/");
        }

        private void pictureBoxFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/www.ysss.edu.np");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "gyankoop" && txtpassword.Text == "klibrary")
            {
                Dashboard db = new Dashboard();
                db.Show();
            }
            else
            {
                MessageBox.Show("Enter Valid Username Or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
