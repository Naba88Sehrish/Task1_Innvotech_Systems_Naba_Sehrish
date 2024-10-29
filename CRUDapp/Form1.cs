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

namespace CRUDapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=CrudDB;Integrated Security=True;Encrypt=false;TrustServerCertificate=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM TeacherTable", con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Insertbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=CrudDB;Integrated Security=True;Encrypt=false;TrustServerCertificate=True"))
                {
                    con.Open();

                    // Corrected SQL query with proper column names and closing parenthesis
                    SqlCommand cmd = new SqlCommand("INSERT INTO TeacherTable (Id, Name, Address, Salary) VALUES (@id, @name, @address, @salary)", con);

                    // Adding parameters safely
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));       
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);            
                    cmd.Parameters.AddWithValue("@address", textBox3.Text);              
                    cmd.Parameters.AddWithValue("@salary", decimal.Parse(textBox4.Text)); 


                    // Execute the query
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    con.Close();

                    MessageBox.Show("Successfully insert record.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=CrudDB;Integrated Security=True;Encrypt=false;TrustServerCertificate=True"))
                {
                    con.Open();

                    // Corrected SQL query with proper column names and closing parenthesis
                    SqlCommand cmd = new SqlCommand("update TeacherTable set Name=@name, Address=@address, Salary=@salary where Id=@id", con);

                    // Updating parameters safely
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@address", textBox3.Text);
                    cmd.Parameters.AddWithValue("@salary", decimal.Parse(textBox4.Text));

                    // Execute the query
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    con.Close();

                    MessageBox.Show("Successfully update record");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=CrudDB;Integrated Security=True;Encrypt=false;TrustServerCertificate=True"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("select * from  TeacherTable where Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox5.Text));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    // Execute the query
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    con.Close();

                    MessageBox.Show("Successfully search record");
                    textBox5.Text = "";
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=CrudDB;Integrated Security=True;Encrypt=false;TrustServerCertificate=True"))
                {
                    con.Open();

                    // Corrected SQL query with proper column names and closing parenthesis
                    SqlCommand cmd = new SqlCommand("delete TeacherTable  where Id=@id", con);

                    // Deleting parameters safely
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

                    // Execute the query
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    con.Close();

                    MessageBox.Show("Successfully Delete record");
                    textBox1.Text = "";
                    LoadData();

                }
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShowAllbtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
