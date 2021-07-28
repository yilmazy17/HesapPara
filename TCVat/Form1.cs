using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCVat
{
    public partial class Form1 : Form
    {
        private VadesizHesap h1 = new VadesizHesap();
        public Form1()
        {
            h1.Bakiye = 250m;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(h1.ParaCek(numericUpDown1.Value));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(h1.ParaYatir(numericUpDown1.Value));
        }
    }
}
