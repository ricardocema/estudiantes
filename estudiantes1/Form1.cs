using logica;
using logica.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estudiantes1
{
    public partial class Form1 : Form
    {
        private LEstudiantes estudiante;
        
        public Form1()
        {
            InitializeComponent();

        

            var listTextBox = new List<TextBox>();
            listTextBox.Add(textBox1);
            listTextBox.Add(textBox2);
            listTextBox.Add(textBox3);
            listTextBox.Add(textBox4);
            var listLabel = new List<Label>();
            listLabel.Add(labelNid);
            listLabel.Add(labelNombre);
            listLabel.Add(labelApellido);
            listLabel.Add(labelEmail);
            listLabel.Add(labelPagina);

            Object[] objects = { 
                pictureBoxImage,
                Properties.Resources.Csharp_Logo,
                dataGridView1,
                numericUpDown1
            };
            estudiante = new LEstudiantes(listTextBox, listLabel, objects);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            estudiante.SearchStudent(textBoxBuscar.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                labelNid.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelNid.ForeColor = Color.Green;
                labelNid.Text = "Nid";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(""))
            {
                labelEmail.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelEmail.ForeColor = Color.Green;
                labelEmail.Text = "Email";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))
            {
                labelApellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelApellido.ForeColor = Color.Green;
                labelApellido.Text = "Apellido";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estudiante.Registrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            estudiante.uploadImage.CargarImagen(pictureBoxImage);
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.numberKeyPress(e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                labelNombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelNombre.ForeColor = Color.Green;
                labelNombre.Text = "Nombre";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.textKeyPress(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.textKeyPress(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            estudiante.Paginador("anterior");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            estudiante.Paginador("Primero");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("siguiente");
        }

        private void buttonUltimo_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("ultimo");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                estudiante.GetEstudiante();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                estudiante.GetEstudiante();
        }
    }
}
