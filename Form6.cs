using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PIA
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos");
            }
            else 
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source= C:/Users/lossa/OneDrive/Documentos/Facultad/Sexto Semestre/Programación de Aplicaciones Locales/Visual Studio/PIA/BD/BDPIA6.db");
                conexion.Open();
                string insert = "INSERT INTO Empleados(ID_Empleado, Contrasena, Nombre_Empleado, ApellidoP_Empleado, ApellidoM_Empleado, Area) VALUES(@tb1,@tb2,@tb3,@tb4,@tb5,@cb1)";
                SQLiteCommand comando = new SQLiteCommand(insert, conexion);
                string ID = textBox1.Text;
                string Contraseña = textBox2.Text;
                string Nombre= textBox3.Text;
                string ApellidoP = textBox4.Text;
                string ApellidoM = textBox5.Text;
                string Area = comboBox1.Text;
                comando.Parameters.AddWithValue("@tb1", ID);
                comando.Parameters.AddWithValue("@tb2", Contraseña);
                comando.Parameters.AddWithValue("@tb3", Nombre);
                comando.Parameters.AddWithValue("@tb4", ApellidoP);
                comando.Parameters.AddWithValue("@tb5", ApellidoM);
                comando.Parameters.AddWithValue("@cb1", Area);
                try
                {
                    comando.ExecuteNonQuery();
                    label8.Visible = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error);
                }
                finally
                {
                    await Task.Delay(2000);
                    conexion.Close();
                    label8.Visible = false;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
