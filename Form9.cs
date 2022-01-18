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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos");
            }
            else
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source= C:/Users/lossa/OneDrive/Documentos/Facultad/Sexto Semestre/Programación de Aplicaciones Locales/Visual Studio/PIA/BD/BDPIA6.db");
                conexion.Open();
                string delete = "DELETE FROM Empleados WHERE ID_Empleado= @tb1";
                SQLiteCommand comando = new SQLiteCommand(delete, conexion);
                string ID = textBox1.Text;
                comando.Parameters.AddWithValue("@tb1", ID);
 
                try
                {
                    comando.ExecuteNonQuery();
                    label3.Visible = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error);
                }
                finally
                {
                    await Task.Delay(2000);
                    conexion.Close();
                    label3.Visible = false;
                    textBox1.Text = string.Empty;
                }
            }
        }
    }
}
