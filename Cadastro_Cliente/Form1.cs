using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cadastro_Cliente
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastro abreForm = new FormCadastro();
            abreForm.ShowDialog();

        }

        private void informaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desenvolvido por NIGHTINSIDE", "Software TEST", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
