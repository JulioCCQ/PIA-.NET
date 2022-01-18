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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            MostrarPacientes();
        }

        private void MostrarPacientes()
        {
            dataGridView1.Rows.Clear();
            SQLiteConnection conexion = new SQLiteConnection("Data Source= C:/Users/lossa/OneDrive/Documentos/Facultad/Sexto Semestre/Programación de Aplicaciones Locales/Visual Studio/PIA/BD/BDPIA6.db");
            conexion.Open();

            string select = "SELECT * FROM Pacientes";
            SQLiteCommand comando = new SQLiteCommand(select, conexion);
            SQLiteDataReader datos = comando.ExecuteReader();
            while (datos.Read())
            {
                dataGridView1.Rows.Insert(0, datos.GetString(0), datos.GetString(1), datos.GetString(2), datos.GetString(3), datos.GetString(4));
            }
            conexion.Close();
        }
    }
}
