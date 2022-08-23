using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DB_Member
{
    public partial class DelForm : Form
    {
        string userID;
        public DelForm(string para)
        {
            InitializeComponent();
            userID = para;
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql;
        private void DelForm_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            // SELECT * FROM userTBL WHERE userID = 'KJH';
            sql = "SELECT * FROM userTBL WHERE userID = '";
            sql += userID + "';";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            string name, birthYear;
            name = birthYear = "NULL";
            while (reader.Read())
            {
                name = (string)reader["name"];
                birthYear = reader["birthYear"].ToString();
            }
            tbID.Text = userID;
            tbName.Text = name;
            tbBth.Text = birthYear;
            reader.Close();
        }
        private void DelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Delete Closed");
        }
        private void btnCon_Click(object sender, EventArgs e)
        {
            sql = "DELETE FROM userTBL WHERE userID = '" + userID + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            tbID.Clear();
            tbName.Clear();
            tbBth.Clear();
        }
    }
}