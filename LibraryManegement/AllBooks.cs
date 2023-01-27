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
    public partial class AllBooks : Form
    {
        string myConnectionString = "server=127.0.0.1;uid=root;database=books";
        MySqlConnection connMysql;
        public AllBooks()
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
                MessageBox.Show(ex.Message);
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
                    reader.GetString(5)};
                dataGridBook.Rows.Add(row);
            }
            reader.Close();
            connect.Close();
        }

        private void dataGridBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            
        }


    }
}
