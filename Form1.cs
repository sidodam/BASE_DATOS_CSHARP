using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {

        private string imageName;
        private byte[] image = null;
        private List<Estudiante> estudianteList = new List<Estudiante>();

        string conncectionString;
        SqlConnection cnn;

        public Form1()
        {
            InitializeComponent();

            conncectionString = @"Data Source=localhost;Initial Catalog=estudiosDB; Integrated Security=True;";

            cnn = new SqlConnection(conncectionString);
            cnn.Open();

            SqlCommand sqlQuery = new SqlCommand("select nombre from ciclo", cnn);

            SqlDataReader datareader;
            string sql;

            datareader = sqlQuery.ExecuteReader();

            while (datareader.Read())
            {

                comboBox1.Items.Add(datareader.GetString(0));
            }
            cnn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FILLDATAGRID();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ChangeLabelColor(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;

            if (textBox1.Text.Length == 0)
            {
                label1.ForeColor = Color.Black;
            }
        }

        private void ChangeLabelColor2(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;

            if (textBox3.Text.Length == 0)
            {
                label2.ForeColor = Color.Black;
            }

        }

        private void ChangeLabelColor3(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;

            if (textBox4.Text.Length == 0)
            {
                label3.ForeColor = Color.Black;
            }

        }

        private void ChangeLabelColor4(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;

            if (textBox2.Text.Length == 0)
            {
                label4.ForeColor = Color.Black;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                imageName = opnfd.FileName.ToString();

            }

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            try
            {

               

                Image img = pictureBox1.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                //INSERT INTO estudiante VALUES(1  , 'NIDO' , 'DIDO', 'RIDO' , 'SIDO@GAM.COM' )
                String sqlQuery = $"INSERT INTO estudiante VALUES( '{textBox1.Text}' , '{textBox3.Text}' , '{textBox4.Text}', '{textBox6.Text}' , '{textBox2.Text}' , '{comboBox1.SelectedItem}' , '{arr}'   )";

                cnn = new SqlConnection(conncectionString);
                cnn.Open();
                SqlCommand cl = new SqlCommand(sqlQuery, cnn);

                cl.ExecuteNonQuery();

                MessageBox.Show("datos añadidos");

                cnn.Close();

                FILLDATAGRID();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            Close();
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FILLDATAGRID()
        {

            try
            {

                cnn.Open();

                string query = "select clave , nombre , primerApellido, segundoApellido , correo , ciclo from estudiante";
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

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                Image img = pictureBox1.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                String sqlQuery = $"UPDATE estudiante SET nombre = '{textBox3.Text}' , primerApellido = '{textBox4.Text}' ,  ciclo = '{comboBox1.SelectedItem}'   , imagen = '{arr}'    WHERE clave = '{textBox1.Text}'  ";

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

        private void button3_Click_1(object sender, EventArgs e)
        {

            try
            {

                if (textBox1.Text.Length == 0)
                {

                    MessageBox.Show("Introduzca la clave");

                }

                else
                {

                    String sqlQuery = $"DELETE FROM estudiante WHERE clave = '{textBox1.Text}'  ";

                    cnn = new SqlConnection(conncectionString);
                    cnn.Open();
                    SqlCommand cl = new SqlCommand(sqlQuery, cnn);

                    cl.ExecuteNonQuery();

                    MessageBox.Show("datos borrados");

                    cnn.Close();

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}

