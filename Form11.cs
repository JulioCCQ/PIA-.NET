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
    public partial class Form11 : Form
    {
        string CantidadInv;
        int CantidadAntigua;
        int CantidadSumaResta;
        int CantidadFinal;
        public Form11()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrEmpty(numericUpDown1.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos");
            }
            else
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source= C:/Users/lossa/OneDrive/Documentos/Facultad/Sexto Semestre/Programación de Aplicaciones Locales/Visual Studio/PIA/BD/BDPIA6.db");
                conexion.Open();
                string select = "SELECT Cantidad FROM Inventario WHERE ID_Material= @tb1";
                SQLiteCommand comandoSelect = new SQLiteCommand(select, conexion);
                string ID = textBox1.Text;
                comandoSelect.Parameters.AddWithValue("@tb1", ID);
                SQLiteDataReader datos = comandoSelect.ExecuteReader();
                while (datos.Read())
                {
                    CantidadInv = (string)datos[0];
                }
                CantidadAntigua = Convert.ToInt32(CantidadInv);
                CantidadSumaResta = Convert.ToInt32(numericUpDown1.Value);

                if (comboBox1.Text== "Agregar")
                {
                    CantidadFinal = CantidadAntigua + CantidadSumaResta;
                }
                if (comboBox1.Text == "Retirar")
                {
                    CantidadFinal = CantidadAntigua - CantidadSumaResta;
                }

                string update = "UPDATE Inventario SET Cantidad=@num1 WHERE ID_Material= @tb1";
                SQLiteCommand comando = new SQLiteCommand(update, conexion);
                string Cantidad = Convert.ToString(CantidadFinal);
                comando.Parameters.AddWithValue("@tb1", ID);
                comando.Parameters.AddWithValue("@num1", Cantidad);
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
                    await Task.Delay(2000);
                    conexion.Close();
                    label5.Visible = false;
                    textBox1.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    numericUpDown1.Text = string.Empty;
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
    }
}
