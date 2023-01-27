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
    public partial class ModifyBook : Form
    {
        string myConnectionString = "server=127.0.0.1;uid=root;database=books";
        MySqlConnection connMysql;
        public ModifyBook()
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
                MessageBox.Show(ex.Message,"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sql = " SELECT * FROM book  ";
            MySqlConnection connect = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] row = new string[] {
                    reader.GetValue(0).ToString(),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),};
                dataGridBook.Rows.Add(row);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string theDate = dateTimePicker1.Value.ToString("yyyy");
            string txtsql = "update book set title = '" + txtTitle.Text +"',author= '"+txtEditor.Text+"',editor= '"+txtEditor.Text+
           "',dateS='" + theDate+
           "',type='" + CBType.Text +
           "' where ISBN = " + txtISBN.Text + "";
            try
            {
                MySqlConnection connMysql = new MySqlConnection(myConnectionString);
                connMysql.Open();

                MySqlCommand Mysqlcmd;
                Mysqlcmd = new MySqlCommand(txtsql, connMysql);
                Mysqlcmd.ExecuteNonQuery();
                connMysql.Close();
                MessageBox.Show("Book Modified ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtISBN.Text = "";
            txtEditor.Text = "";
            txtAuthor.Text = "";
            txtTitle.Text = "";
        }

        private void selectcolumn(object sender, DataGridViewCellEventArgs e)
        {
            int lignecourrant;

            string theDate = dateTimePicker1.Value.ToString("yyyy");

            if (dataGridBook.RowCount == 0)
                return;
            lignecourrant = dataGridBook.CurrentRow.Index;

            string ISBN = dataGridBook.Rows[lignecourrant].Cells[0].Value.ToString();
            string title = dataGridBook.Rows[lignecourrant].Cells[1].Value.ToString();
            string author = dataGridBook.Rows[lignecourrant].Cells[2].Value.ToString();
            string editor = dataGridBook.Rows[lignecourrant].Cells[3].Value.ToString();
            string date = dataGridBook.Rows[lignecourrant].Cells[4].Value.ToString();
            string type = dataGridBook.Rows[lignecourrant].Cells[5].Value.ToString();

            txtISBN.Text = ISBN;
            txtAuthor.Text = author;
            txtEditor.Text = editor;
            txtTitle.Text = title;
            theDate = date;
            CBType.Text = type;

            txtISBN.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            
        }
    }
}
