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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source= C:/Users/lossa/OneDrive/Documentos/Facultad/Sexto Semestre/Programación de Aplicaciones Locales/Visual Studio/PIA/BD/BDPIA6.db");
            conexion.Open();

            string Login= "SELECT Contrasena FROM Empleados WHERE ID_Empleado= @textBox1";
            SQLiteCommand comando = new SQLiteCommand(Login, conexion);
            comando.Parameters.Add(new SQLiteParameter("@textBox1", textBox1.Text));
            SQLiteDataReader datos = comando.ExecuteReader();
            string contrasena= null;
            while (datos.Read()) 
            {
                contrasena = (string)datos[0];
            }
            if  (contrasena == textBox2.Text)
            {
                conexion.Close();
                this.Hide();
                Form2 f = new Form2();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                textBox3.Visible = true;
                await Task.Delay(2000);
                textBox3.Visible = false;
            }
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Blue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }
    }
}
