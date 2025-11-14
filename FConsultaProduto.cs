using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace DeltaSystem
{
    public partial class FConsultaProduto : Form
    {
        public FConsultaProduto()
        {
            InitializeComponent();
        }

        private void FConsultaProduto_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var conectar = BancoSQL.conexaoBanco();
            var cmd = conectar.CreateCommand();
            cmd.CommandText = @"SELECT Id,Descricao,Preco, Quantidade from Produtos";
            da = new SqlDataAdapter(cmd.CommandText, conectar);
            da.Fill(dt);
            dgv_consultaProdutos.DataSource = dt;
            conectar.Close();
        }

        private void dgv_consultaProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_consultaProdutos.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
