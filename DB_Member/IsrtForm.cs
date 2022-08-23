using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DB_Member
{
    public partial class IsrtForm : Form
    {
        public IsrtForm()
        {
            InitializeComponent();
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql, userID, name, birthYear, addr, mobile1, mobile2, height, mDate;
        private void IsrtForm_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
        }
        private void IsrtForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Insert Closed");
        }
        private void btnCon_Click(object sender, EventArgs e)
        {
            userID = tbID.Text.ToString();
            name = tbName.Text.ToString();
            birthYear = tbBth.Text.ToString();
            addr = tbLoc.Text.ToString();
            mobile1 = tbArea.Text.ToString();
            mobile2 = tbPhone.Text.ToString();
            height = tbHght.Text.ToString();
            var toDay = DateTime.Now;
            mDate = toDay.Date.ToString("yyyy-M-d");
            // INSERT INTO userTBL VALUES('KJH', '김진혁', 1989, '길음', '010', '49409086', 181, '2022-8-23');
            sql = "INSERT INTO userTBL(userID, name, birthYear, addr, mobile1, mobile2, height, mDate) VALUES('";
            sql += userID + "', '";
            sql += name + "', ";
            sql += birthYear + ", '";
            sql += addr + "', '";
            sql += mobile1 + "', '";
            sql += mobile2 + "', ";
            sql += height + ", '";
            sql += mDate + "');";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            tbID.Clear();
            tbName.Clear();
            tbBth.Clear();
            tbLoc.Clear();
            tbArea.Clear();
            tbPhone.Clear();
            tbHght.Clear();
        }
    }
}