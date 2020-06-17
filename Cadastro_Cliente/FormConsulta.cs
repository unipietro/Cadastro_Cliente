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
    public partial class FormConsulta : Form
    {
        FormCadastro formCadCli;
        public FormConsulta(FormCadastro formCadCli1)
        {
            this.formCadCli = formCadCli1;
            InitializeComponent();
        }

        string strDeConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Software_Cadastro;Integrated Security=True";
        SqlConnection cn = new SqlConnection();
        

        private void FormConsulta_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = strDeConexao;
            string sqlQuery;
            sqlQuery = "SELECT COD_CLIENTE, CPF, NOME, DATA_NASC FROM Clientes ORDER BY COD_CLIENTE";
            SqlDataAdapter dta = new SqlDataAdapter(sqlQuery, cn);
            DataTable dt = new DataTable();

            try
            {
                dta.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
                dataGridView1.Columns[0].HeaderCell.Value = "Código Cliente";
                dataGridView1.Columns[1].HeaderCell.Value = "CPF";
                dataGridView1.Columns[2].HeaderCell.Value = "Nome";
                dataGridView1.Columns[3].HeaderCell.Value = "Dt. Nasc.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deu ruim lek");
            }
            finally
            {
                if(cn != null)
                {
                    cn.Close();
                }
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            string codCli;
            codCli = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string sqlQuery;
            cn.ConnectionString = strDeConexao;

            SqlDataReader dtr = null;

            sqlQuery = "SELECT COD_CLIENTE, CPF, NOME, DATA_NASC FROM Clientes WHERE COD_CLIENTE = @COD_CLIENTE";


            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, cn);
                cmd.Parameters.Add(new SqlParameter("@COD_CLIENTE", Convert.ToInt32(codCli)));
                dtr = cmd.ExecuteReader();

                if (dtr.Read())
                {
                    formCadCli.txtCodigo.Text = dtr["COD_CLIENTE"].ToString();
                    formCadCli.mskCPF.Text = dtr["CPF"].ToString();
                    formCadCli.txtNome.Text = dtr["NOME"].ToString();
                    formCadCli.mskData.Text = dtr["DATA_NASC"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro - Seleção de dados - Cliente");
            }
            finally
            {
                if (dtr != null)
                {
                    dtr.Close();
                }
                if(cn != null)
                {
                    cn.Close();
                }
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
