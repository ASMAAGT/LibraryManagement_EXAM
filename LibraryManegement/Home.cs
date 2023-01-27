using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManegement
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddBook f2 = new AddBook();
            f2.MdiParent = this;
            f2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllBooks f5 = new AllBooks();
            f5.MdiParent = this;
            f5.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            AddBook f2 = new AddBook();
            f2.MdiParent = this;
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            ModifyBook f3 = new ModifyBook();
            f3.MdiParent = this;
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteBook f4 = new DeleteBook();
            f4.MdiParent = this;
            f4.Show();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit !", "EXIT", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
