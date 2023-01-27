using MySql.Data.MySqlClient;
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
    public partial class DeleteBook : Form
    {
        string myConnectionString = "server=127.0.0.1;uid=root;database=books";
        MySqlConnection connMysql;
        public DeleteBook()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtISBN.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string txtinsert;
            txtinsert = "DELETE FROM book WHERE book.ISBN =" + txtISBN.Text;
            try
            {
                connMysql = new MySqlConnection(myConnectionString);
                connMysql.Open();
                
                MySqlCommand Mysqlcmd;
                Mysqlcmd = new MySqlCommand(txtinsert, connMysql);
                Mysqlcmd.ExecuteNonQuery();
                connMysql.Close();
                MessageBox.Show("Book deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}
