using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DB_Member
{
    public partial class SlctForm : Form
    {
        public SlctForm()
        {
            InitializeComponent();
        }
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql;
        private void SlctForm_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
            sql = "SELECT userID, name, birthYear, addr, mobile1, mobile2, height, mDate FROM userTBL";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            listView1.View = View.Details;
            listView1.Columns.Add("ID");
            listView1.Columns.Add("NAME");
            listView1.Columns.Add("BIRTHYEAR");
            listView1.Columns.Add("ADDRESS");
            listView1.Columns.Add("AREA");
            listView1.Columns.Add("PHONE");
            listView1.Columns.Add("HEIGHT");
            listView1.Columns.Add("JOIN DATE");
            ListViewItem item;
            string userid, name, birthYear, addr, mobile1, mobile2, height, mDate;
            while (reader.Read())
            {
                userid = (string)reader["userID"];
                name = (string)reader["name"];
                birthYear = reader["birthYear"].ToString();
                addr = (string)reader["addr"];
                mobile1 = (string)reader["mobile1"];
                mobile2 = (string)reader["mobile2"];
                height = reader["height"].ToString();
                mDate = reader["mDate"].ToString();
                item = new ListViewItem(userid);
                item.SubItems.Add(name);
                item.SubItems.Add(birthYear);
                item.SubItems.Add(addr);
                item.SubItems.Add(mobile1);
                item.SubItems.Add(mobile2);
                item.SubItems.Add(height);
                item.SubItems.Add(mDate);
                listView1.Items.Add(item);
            }
            reader.Close();
        }
        private void SlctForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("Select Closed");
        }
    }
}