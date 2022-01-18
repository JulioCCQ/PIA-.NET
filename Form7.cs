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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos");
            }
            else
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source= C:/Users/lossa/OneDrive/Documentos/Facultad/Sexto Semestre/Programación de Aplicaciones Locales/Visual Studio/PIA/BD/BDPIA6.db");
                conexion.Open();
                string delete = "DELETE FROM Pacientes WHERE ID_Paciente= @tb1";
                string insert = "INSERT INTO Salidas(ID_Paciente, Motivo_Salida) VALUES(@tb1, @tb2)";
                SQLiteCommand comando = new SQLiteCommand(delete, conexion);
                SQLiteCommand comandoInsert = new SQLiteCommand(insert, conexion);
                string ID = textBox1.Text;
                string Motivo = textBox2.Text;
                comando.Parameters.AddWithValue("@tb1", ID);
                comandoInsert.Parameters.AddWithValue("@tb1", ID);
                comandoInsert.Parameters.AddWithValue("@tb2", Motivo);
                try
                {
                    comando.ExecuteNonQuery();
                    comandoInsert.ExecuteNonQuery();
                    label2.Visible = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error);
                }
                finally
                {
                    await Task.Delay(2000);
                    conexion.Close();
                    label2.Visible = false;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
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
