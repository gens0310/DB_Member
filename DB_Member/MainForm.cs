using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DB_Member
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /* < Database Structure >
        ---------- sqlDB ----------
        | userTBL    | imgTBL     |
        ---------------------------
        | userID(PK) | num(PK)    |
        | name       | userID(FK) |
        | birthYear  | prodName   |
        | addr       | gruopName  |
        | mobile1    | price      |
        | mobile2    | amount     |
        | height     |            |
        | mDate      |            |
        --------------------------- */
        // Variable
        string cnnSTR = "Server=192.168.56.101;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        // string cnnSTR = "Server=127.0.0.1;Uid=nickUSER;Pwd=1234;Database=sqldb;Charset=UTF8";
        MySqlConnection cnn;
        MySqlCommand cmd;
        string sql;
        // Event Method
        private void Main_Load(object sender, EventArgs e)
        {
            cnn = new MySqlConnection(cnnSTR);
            cnn.Open();
            cmd = new MySqlCommand("", cnn);
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            MessageBox.Show("DB Closed");
        }
        private void btnSELECT_Click(object sender, EventArgs e)
        {
            SlctForm slct = new SlctForm();
            slct.ShowDialog();
        }
        private void btnINSERT_Click(object sender, EventArgs e)
        {
            IsrtForm isrt = new IsrtForm();
            isrt.ShowDialog();
        }
        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            string userID;
            userID = tbUpID.Text.ToString();
            UpdtForm upd = new UpdtForm(userID);
            upd.ShowDialog();
        }
        private void btnDELETE_Click(object sender, EventArgs e)
        {
            string userID;
            userID = tbDelID.Text.ToString();
            DelForm del = new DelForm(userID);
            del.ShowDialog();
        }
    }
}