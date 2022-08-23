using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DB_Member
{
    public partial class UpdtForm : Form
    {
        string userID;
        public UpdtForm(string para)
        {
            InitializeComponent();
            userID = para;
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql;
        private void UpdtForm_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            // SELECT * FROM userTBL WHERE userID = 'KJH';
            sql = "SELECT * FROM userTBL WHERE userID = '";
            sql += userID + "';";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            string name, birthYear, addr, mobile1, mobile2, height, mDate;
            name = birthYear = addr = mobile1 = mobile2 = height = mDate = "NULL";
            while (reader.Read())
            {
                name = (string)reader["name"];
                birthYear = reader["birthYear"].ToString();
                addr = (string)reader["addr"];
                mobile1 = (string)reader["mobile1"];
                mobile2 = (string)reader["mobile2"];
                height = reader["height"].ToString();
                mDate = reader["mDate"].ToString();
            }
            tbID.Text = userID;
            tbName.Text = name;
            tbBth.Text = birthYear;
            tbLoc.Text = addr;
            tbArea.Text = mobile1;
            tbPhone.Text = mobile2;
            tbHght.Text = height;
            tbDate.Text = mDate;
            reader.Close();
        }
        private void UpdtForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Update Closed");
        }
        private void btnCon_Click(object sender, EventArgs e)
        {
            string name, birthYear, addr, mobile1, mobile2, height, mDate;
            name = tbName.Text.ToString();
            birthYear = tbBth.Text.ToString();
            addr = tbLoc.Text.ToString();
            mobile1 = tbArea.Text.ToString();
            mobile2 = tbPhone.Text.ToString();
            height = tbHght.Text.ToString();
            mDate = tbDate.Text.ToString();
            // UPDATE userTBL SET
            // name = '김진혁',
            // birthYear = 1989,
            // addr = '길음',
            // mobile1 = '010',
            // mobile2 = '49409086',
            // height = 181,
            // mDate = '2022-8-23'
            // WHERE userID = 'KJH';
            sql = "UPDATE userTBL SET ";
            sql += "name = '" + name + "', ";
            sql += "birthYear = " + birthYear + ", ";
            sql += "addr = '" + addr + "', ";
            sql += "mobile1 = '" + mobile1 + "', ";
            sql += "mobile2 = '" + mobile2 + "', ";
            sql += "height = " + height + ", ";
            sql += "mDate = '" + mDate + "' ";
            sql += "WHERE userID = '" + userID + "';";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            tbID.Clear();
            tbName.Clear();
            tbBth.Clear();
            tbLoc.Clear();
            tbArea.Clear();
            tbPhone.Clear();
            tbHght.Clear();
            tbDate.Clear();
        }
    }
}