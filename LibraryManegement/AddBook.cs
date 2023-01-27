using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using MySql.Data.MySqlClient;

namespace LibraryManegement
{
    public partial class AddBook : Form
    {
        
        string myConnectionString = "server=127.0.0.1;uid=root;database=books";
        MySqlConnection connMysql;

  
        public AddBook()
        {
            InitializeComponent();
            timer1.Start();
            
            try
            {
                connMysql = new MySqlConnection(myConnectionString);
                connMysql.Open();
                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("yyyy");
            string sql = "insert into book values(" + txtISBN.Text + ",'" +
                txtTitle.Text + "','" +txtAuthor.Text+ "','" +txtEditor.Text+"','"+
                theDate+ "','"+CBType.Text+"')";
                
            try
            {
                connMysql = new MySqlConnection(myConnectionString);
                connMysql.Open();
                MySqlCommand Mysqlcmd;
                Mysqlcmd = new MySqlCommand(sql,connMysql);
                Mysqlcmd.ExecuteNonQuery();
                connMysql.Close();
                MessageBox.Show("Book added ! ", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtISBN.Text = "";
            txtAuthor.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            
        }
    }
}
