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

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {

        string conncectionString;
        SqlConnection cnn;

        public Form3()
        {
            InitializeComponent();

            conncectionString = @"Data Source=localhost;Initial Catalog=estudiosDB; Integrated Security=True;";

            cnn = new SqlConnection(conncectionString);
            cnn.Open();
            cnn.Close();

            SqlDataReader datareader;
            string sql;



        }




        private void Form3_Load(object sender, EventArgs e)
        {
            FILLDATAGRID();

        }


        private void FILLDATAGRID()
        {

            try
            {

                cnn.Open();

                string query = "select id , nombre  from ciclo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Close();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                {
                    String sqlQuery = $"INSERT INTO ciclo VALUES( '{textBox1.Text}' , '{textBox2.Text}'  )";

                    cnn = new SqlConnection(conncectionString);
                    cnn.Open();
                    SqlCommand cl = new SqlCommand(sqlQuery, cnn);

                    cl.ExecuteNonQuery();

                    MessageBox.Show("datos añadidos");

                    cnn.Close();


                    FILLDATAGRID();


                }

                else
                {

                    MessageBox.Show("Introduzca datos correctos");

                }

              

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                String sqlQuery = $"UPDATE ciclo SET nombre = '{textBox2.Text}' WHERE id = '{textBox1.Text}'  ";

                cnn = new SqlConnection(conncectionString);
                cnn.Open();
                SqlCommand cl = new SqlCommand(sqlQuery, cnn);

                cl.ExecuteNonQuery();

                MessageBox.Show("datos modificados");

                cnn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String sqlQuery = $"DELETE FROM ciclo WHERE id = '{textBox1.Text}'  ";

                cnn = new SqlConnection(conncectionString);
                cnn.Open();
                SqlCommand cl = new SqlCommand(sqlQuery, cnn);

                cl.ExecuteNonQuery();

                MessageBox.Show("datos borrados");

                cnn.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
