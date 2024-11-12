using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace database_interface
{
    public partial class admin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=quiet_attic_films;Integrated Security=True");
        public admin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Please enter username and password!", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    string username = txtuser.Text;
                    SqlCommand command = new SqlCommand("SELECT * FROM logintbl WHERE username1 ='" + username + "'", conn);
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    string user = "";
                    string pass = "";
                    while (reader.Read())
                    {
                        user = reader[1].ToString();
                        pass = reader[2].ToString();
                    }

                    if (txtuser.Text == user && txtpass.Text == pass)
                    {
                        dashboard dashboard = new dashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!, Try again....", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtuser.Clear();
                        txtpass.Clear();
                        txtuser.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }

        }
    }
}
