using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FirstName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=MUB\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);

            try
            {
                con.Open();

                string firstName = textBox1.Text;
                string lastName = textBox2.Text;

                string query = "INSERT INTO Name (FIRSTNAME, LASTNAME) VALUES (@FirstName, @LastName)";
                SqlCommand cmd = new SqlCommand(query, con);

                // Adding parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data has been saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}

