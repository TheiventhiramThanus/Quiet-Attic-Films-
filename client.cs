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
using System.Collections;

namespace database_interface
{
    public partial class client : Form
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=quiet_attic_films;Integrated Security=True");

        public client()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          

          
           dashboard dash = new dashboard();
           dash.Show();
            this.Hide();
        }

        private void client_Load(object sender, EventArgs e)
        {
            {
                search_id();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtphone.Focus();
                
        }

        private void txtaddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtname.Focus();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtid.Focus();
            }
           
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtaddress.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clear successfully!");
            txtid.Clear();
            txtname.Clear();
            txtaddress.Clear();
            txtphone.Clear();
            txtid.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtphone.Text == "")
            {
                MessageBox.Show("Please fill the values..!", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    Conn.Open();
                    int client_id = int.Parse(txtid.Text);
                    string client_name = txtname.Text;
                    string client_Address = txtaddress.Text;
                    string client_phone_number = txtphone.Text;
                    SqlCommand command = new SqlCommand("INSERT INTO client VALUES(" + client_id + ",'" + client_name + "','" + client_Address + "','" + client_phone_number + "')", Conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Inserted successfully!");

                    txtid.Clear();
                    txtname.Clear();
                    txtaddress.Clear();
                    txtname.Clear();
                    txtphone.Clear();
                    txtid.Focus();

                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                finally { Conn.Close(); }
                {
                    search_id();
                        
                }
            }
        }

        public void search_id()
        {
            try
            {
                Conn.Open();
                SqlCommand command = new SqlCommand("SELECT client_id FROM client", Conn);
                SqlDataReader reader;
                reader = command.ExecuteReader();
                ArrayList ids = new ArrayList();
                while (reader.Read())
                {
                    ids.Add(reader[0].ToString());
                }
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(ids.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Conn.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtphone.Text == "" )
            {
                MessageBox.Show("Please fill the values..!", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    Conn.Open();
                    int client_id = int.Parse(txtid.Text);
                    string client_name = txtname.Text;
                    string client_address = txtaddress.Text;
                    string client_phone_number = txtphone.Text;
                    SqlCommand command = new SqlCommand("UPDATE client SET client_name='" + client_name + "',client_address='" + client_address + "',client_phone_number='" + client_phone_number + "' WHERE client_id =" + client_id + "", Conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully!");
                    txtid.Clear();
                    txtaddress.Clear();
                    txtname.Clear();
                    txtphone.Clear();
                    txtid.Focus();


                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                finally
                {
                    Conn.Close();
                }
                {
                    search_id();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                Conn.Open();
                int client_id = int.Parse(comboBox1.Text);

                SqlCommand command = new SqlCommand("SELECT * FROM client WHERE client_id = " + client_id + "", Conn);
                SqlDataReader reader;
                reader = command.ExecuteReader();
                string ids = "";
                string client_name = "";
                string client_Address = "";
                string client_phone_number = "";
                
                while (reader.Read())
                {
                    ids = reader[0].ToString();
                    client_name = reader[1].ToString();
                    client_Address = reader[2].ToString();
                    client_phone_number = reader[3].ToString();
                    


                }
                txtid.Text = ids;
                txtname.Text = client_name;
                txtaddress.Text = client_Address;
                txtphone.Text = client_phone_number;
                


            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally
            {
                Conn.Close();
            }
            {
                search_id();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtphone.Text == "" )
            {
                MessageBox.Show("Please select id..!", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure that you want to delete?", "Confirmation..!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        Conn.Open();
                        int client_id = int.Parse(txtid.Text);

                        SqlCommand command = new SqlCommand("DELETE FROM client WHERE client_id=" + client_id + "", Conn);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Deleted successfully!");
                        txtid.Clear();
                        txtaddress.Clear();
                        txtname.Clear();
                        txtphone.Clear();
                        txtid.Focus();


                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    finally
                    {
                        Conn.Close();
                    }
                    {
                        search_id();
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
