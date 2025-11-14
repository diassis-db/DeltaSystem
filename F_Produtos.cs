using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DeltaSystem
{
    public partial class F_Produtos : Form
    {
        public F_Produtos()
        {
            InitializeComponent();
        }

        private void F_Produtos_Load(object sender, EventArgs e)
        {
            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = false;
            tb_descricao.Enabled = false;
            tb_preco.Enabled = false;
            tb_quantidade.Enabled = false;
        }
        private void tb_preco_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_preco.Text, out decimal preco)) 
            {
                tb_preco.Text = preco.ToString("N2"); // código para aceitar apenas 2 casas decimais
            }
            else
            {
                tb_preco.Text = "0,00";
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            btn_novo.Enabled = false;
            tb_descricao.Enabled = true;
            tb_preco.Enabled = true;
            tb_quantidade.Enabled = true;
            btn_gravar.Enabled=true;
            btn_cancelar.Enabled=true;
            btn_consulta.Enabled = false;
            tb_Id.Clear();
            tb_descricao.Clear();
            tb_preco.Clear();
            tb_quantidade.Clear();
            tb_descricao.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_novo.Enabled = true;
            btn_consulta.Enabled = true;
            btn_gravar.Enabled = false;
            tb_descricao.Enabled = false;
            tb_preco.Enabled = false;
            tb_quantidade.Enabled = false;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if (tb_descricao.Text == "")
            {
                MessageBox.Show("Preencher a descrição do Produto.");
                tb_descricao.Focus();
            }
            else
            {
                    Produto produto = new Produto();
                    produto.Nome = tb_descricao.Text;
                    produto.Preco = Convert.ToDecimal(tb_preco.Text);
                    produto.Quantidade = Convert.ToInt32(tb_quantidade.Text);
                    BancoSQL.GravarNovoProduto(produto);

                    tb_descricao.Enabled = false;
                    tb_preco.Enabled = false;
                    tb_quantidade.Enabled = false;
                    btn_fechar.Focus();
                    btn_novo.Enabled = true;
                    btn_consulta.Enabled = true;
                    btn_gravar.Enabled = false;
            }
        }

        private void tb_descricao_TextChanged(object sender, EventArgs e)
        {
            tb_descricao.Text = tb_descricao.Text.ToUpper();
            tb_descricao.SelectionStart = tb_descricao.Text.Length;
            tb_descricao.SelectionLength = 0;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            var consutar = new FConsultaProduto();
            if(consutar.ShowDialog() == DialogResult.OK)
            {
                tb_Id.Text = consutar.dgv_consultaProdutos.CurrentRow.Cells[0].Value.ToString();
                tb_descricao.Text = consutar.dgv_consultaProdutos.CurrentRow.Cells[1].Value.ToString();
                tb_preco.Text = consutar.dgv_consultaProdutos.CurrentRow.Cells[2].Value.ToString();
                tb_quantidade.Text = consutar.dgv_consultaProdutos.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void tb_quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & e.KeyChar != 44 & e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
    }
}
