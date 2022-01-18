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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos");
            }
            else
            { 
                SQLiteConnection conexion = new SQLiteConnection("Data Source= C:/Users/lossa/OneDrive/Documentos/Facultad/Sexto Semestre/Programación de Aplicaciones Locales/Visual Studio/PIA/BD/BDPIA6.db");
                conexion.Open();
                string insert = "INSERT INTO Inventario(ID_Material, Nombre_Material, Descripcion_Material, Cantidad) VALUES(@tb1,@tb2,@tb3, 0)";
                SQLiteCommand comando = new SQLiteCommand(insert, conexion);
                string ID = textBox1.Text;
                string Nombre = textBox2.Text;
                string Descripcion = textBox3.Text;
                comando.Parameters.AddWithValue("@tb1", ID);
                comando.Parameters.AddWithValue("@tb2", Nombre);
                comando.Parameters.AddWithValue("@tb3", Descripcion);
                try
                {
                    comando.ExecuteNonQuery();
                    label5.Visible = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error);
                }
                finally
                {
                    conexion.Close();
                    await Task.Delay(2000);
                    label5.Visible = false;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
