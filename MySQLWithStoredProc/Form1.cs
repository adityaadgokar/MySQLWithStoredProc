using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MySQLWithStoredProc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["mysqlcs"].ConnectionString;
            DataTable dt = new DataTable();
            using (MySqlConnection mscon = new MySqlConnection(cs))
            {
                MySqlCommand cmd = new MySqlCommand("spSelect", mscon);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            dataGridView1.DataSource = dt;

        }
    }
}
