using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_Cliente
{
    public partial class FormCadastro : System.Windows.Forms.Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        
        

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            
            
            if(string.IsNullOrEmpty(aaa.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(mskData.Text))
            {
                MessageBox.Show("Não deixe campos vazios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Software_Cadastro;Integrated Security=True";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = strDeConexao;

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Clientes(CPF, NOME, DATA_NASC) VALUES (@CPF, @NOME, @DATA_NASC)", cn);
                cn.Open();

                cmd.Parameters.Add(new SqlParameter("@CPF", mskCPF.Text));
                cmd.Parameters.Add(new SqlParameter("@NOME", txtNome.Text));
                cmd.Parameters.Add(new SqlParameter("@DATA_NASC", mskData.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Inserção feita com sucesso.");
                mskCPF.Clear();
                txtNome.Clear();
                mskData.Clear();
                mskCPF.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro na inserção");
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            FormConsulta formConsulta = new FormConsulta(this);
            formConsulta.ShowDialog();
        }
    }
}
