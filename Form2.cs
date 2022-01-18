using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AbrirForms(new Form4());
        }

        private void AbrirForms(object Ventanas)
        {
            if (this.panel4.Controls.Count > 0)
                this.panel4.Controls.RemoveAt(0);
            Form Ventana = Ventanas as Form;
            Ventana.TopLevel = false;
            Ventana.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(Ventana);
            this.panel4.Tag = Ventana;
            Ventana.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form3());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form4());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form5());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form6());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form7());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form8());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form9());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form10());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form11());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AbrirForms(new Form12());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.Red;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Transparent;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.BackColor = Color.Blue;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.BackColor = Color.Transparent;
        }
    }
}
