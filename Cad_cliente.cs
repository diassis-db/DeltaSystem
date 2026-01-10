using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DeltaSystem
{
    public partial class Cad_cliente : Form
    {
        string foto;
        string origemCompleto;
        string destinoCompleto;
        string pastaDestino = System.Environment.CurrentDirectory;
        public Cad_cliente()
        {
            InitializeComponent();
        }

        #region Formulário Load do Cliente
        private void Cad_cliente_Load(object sender, EventArgs e)
        {
            tb_nome.Enabled = false;
            mtb_celular.Enabled = false;
            mtb_cep.Enabled = false;
            mtb_cpf.Enabled = false;
            tb_endereco.Enabled = false;
            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_foto.Enabled = false;
            cb_uf.Enabled = false;
            tb_cidade.Enabled = false;
            btn_alterar.Enabled = true;
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(11, "RO");
            d.Add(12, "AC");
            d.Add(13, "AM");
            d.Add(14, "RR");
            d.Add(15, "PA");
            d.Add(16, "AP");
            d.Add(17, "TO");
            d.Add(21, "MA");
            d.Add(22, "PI");
            d.Add(23, "CE");
            d.Add(24, "RN");
            d.Add(25, "PB");
            d.Add(26, "PE");
            d.Add(27, "AL");
            d.Add(28, "SE");
            d.Add(29, "BA");
            d.Add(31, "MG");
            d.Add(32, "ES");
            d.Add(33, "RJ");
            d.Add(35, "SP");
            d.Add(41, "PR");
            d.Add(42, "SC");
            d.Add(43, "RS");
            d.Add(50, "MS");
            d.Add(51, "MT");
            d.Add(52, "GO");
            d.Add(53, "DF");
            cb_uf.DataSource = new BindingSource(d, null);
            cb_uf.DisplayMember = "Value";
            cb_uf.ValueMember = "Value";
            cb_uf.SelectedIndex = -1;
        }

        #endregion

        #region Botões do Formulário Cliente
        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_nome.Enabled = true;
            tb_nome.Clear();
            tb_nome.Focus();
            mtb_celular.Enabled = true;
            mtb_celular.Clear();
            mtb_cep.Enabled = true;
            mtb_cep.Clear();
            mtb_cpf.Enabled = true;
            mtb_cpf.Clear();
            tb_endereco.Enabled = true;
            tb_endereco.Clear();
            tb_codigo.Clear();
            tb_cidade.Clear();
            btn_novo.Enabled = false;
            btn_gravar.Enabled = true;
            btn_alterar.Enabled = false;
            btn_consulta.Enabled = false;
            btn_foto.Enabled = true;
            cb_uf.Enabled = true;
            tb_cidade.Enabled = true;
            btn_cancelar.Enabled = true;
            cb_uf.SelectedIndex = -1;

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tb_nome.Enabled = false;
            mtb_celular.Enabled = false;
            mtb_cep.Enabled = false;
            mtb_cpf.Enabled = false;
            tb_endereco.Enabled = false;
            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_consulta.Enabled = true;
            btn_foto.Enabled = false;
            cb_uf.Enabled = false;
            tb_cidade.Enabled = false;
            btn_novo.Enabled = true;
            btn_alterar.Enabled = true;
            pb_foto.ImageLocation = string.Empty;
        }

        private void btn_fechar_Click(object sender, EventArgs e) => this.Close();

        private void btn_foto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                origemCompleto = openFileDialog1.FileName;
                foto = openFileDialog1.SafeFileName;
                destinoCompleto = pastaDestino + foto;

            }
            pb_foto.ImageLocation = origemCompleto;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_nome.Text) ||
                string.IsNullOrWhiteSpace(tb_cidade.Text) ||
                string.IsNullOrWhiteSpace(tb_endereco.Text) ||
                string.IsNullOrWhiteSpace(mtb_celular.Text) ||
                string.IsNullOrWhiteSpace(cb_uf.Text))
            {
                MessageBox.Show("Cadastro Incompleto!");
                tb_nome.Focus();
                return;
            }

            try
            {
                string sql;
                Dictionary<string, object> parametros;

                // Novo cliente
                if (string.IsNullOrEmpty(tb_codigo.Text))
                {
                    sql = @"INSERT INTO Cliente 
                    (Nome, Celular, CPF, Endereco, cep, UF, cidade)
                    VALUES (@nome, @celular, @cpf, @endereco, @cep, @uf, @cidade)";

                    parametros = new Dictionary<string, object>
                    {
                        { "@nome", tb_nome.Text },
                        { "@celular", mtb_celular.Text },
                        { "@cpf", mtb_cpf.Text },
                        { "@endereco", tb_endereco.Text },
                        { "@cep", mtb_cep.Text },
                        { "@uf", cb_uf.Text },
                        { "@cidade", tb_cidade.Text }
                    };

                    BancoSQL.Dml(sql, parametros, "Cliente cadastrado com sucesso!");
                }
                // Atualizar cliente existente
                else
                {
                    sql = @"UPDATE Cliente SET 
                        Nome = @nome,
                        Celular = @celular,
                        CPF = @cpf,
                        Endereco = @endereco,
                        cep = @cep,
                        UF = @uf,
                        cidade = @cidade
                    WHERE Id = @id";

                    parametros = new Dictionary<string, object>
                    {
                        { "@nome", tb_nome.Text },
                        { "@celular", mtb_celular.Text },
                        { "@cpf", mtb_cpf.Text },
                        { "@endereco", tb_endereco.Text },
                        { "@cep", mtb_cep.Text },
                        { "@uf", cb_uf.Text },
                        { "@cidade", tb_cidade.Text },
                        { "@id", Convert.ToInt32(tb_codigo.Text) }
                    };

                    BancoSQL.Dml(sql, parametros, "Cliente atualizado com sucesso!");
                }

                tb_nome.Clear();
                tb_endereco.Clear();
                tb_cidade.Clear();
                mtb_cpf.Clear();
                mtb_cep.Clear();
                mtb_celular.Clear();

                tb_nome.Enabled = false;
                mtb_celular.Enabled = false;
                mtb_cep.Enabled = false;
                mtb_cpf.Enabled = false;
                tb_endereco.Enabled = false;
                btn_gravar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_foto.Enabled = false;
                cb_uf.Enabled = false;
                tb_cidade.Enabled = false;
                btn_novo.Enabled = true;
                btn_consulta.Enabled = true;

            }
            catch (SqlException sq) { MessageBox.Show(sq.Message, "ERROR:"); }
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            FormConsultaCliente ccliente = new FormConsultaCliente();
            if (ccliente.ShowDialog() == DialogResult.OK)
            {
                tb_codigo.Text = ccliente.dataGridView2.CurrentRow.Cells[0].Value.ToString();
                tb_nome.Text = ccliente.dataGridView2.CurrentRow.Cells[1].Value.ToString();
                mtb_celular.Text = ccliente.dataGridView2.CurrentRow.Cells[2].Value.ToString();
                mtb_cpf.Text = ccliente.dataGridView2.CurrentRow.Cells[3].Value.ToString();
                tb_endereco.Text = ccliente.dataGridView2.CurrentRow.Cells[4].Value.ToString();
                mtb_cep.Text = ccliente.dataGridView2.CurrentRow.Cells[5].Value.ToString();
                cb_uf.Text = ccliente.dataGridView2.CurrentRow.Cells[6].Value.ToString();
                tb_cidade.Text = ccliente.dataGridView2.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            FormConsultaCliente ccliente = new FormConsultaCliente();
            if (ccliente.ShowDialog() == DialogResult.OK)
            {
                tb_codigo.Text = ccliente.dataGridView2.CurrentRow.Cells[0].Value.ToString();
                tb_nome.Text = ccliente.dataGridView2.CurrentRow.Cells[1].Value.ToString();
                mtb_celular.Text = ccliente.dataGridView2.CurrentRow.Cells[2].Value.ToString();
                mtb_cpf.Text = ccliente.dataGridView2.CurrentRow.Cells[3].Value.ToString();
                tb_endereco.Text = ccliente.dataGridView2.CurrentRow.Cells[4].Value.ToString();
                mtb_cep.Text = ccliente.dataGridView2.CurrentRow.Cells[5].Value.ToString();
                cb_uf.Text = ccliente.dataGridView2.CurrentRow.Cells[6].Value.ToString();
                tb_cidade.Text = ccliente.dataGridView2.CurrentRow.Cells[7].Value.ToString();

                tb_nome.Enabled = true;
                mtb_celular.Enabled = true;
                mtb_cep.Enabled = true;
                mtb_cpf.Enabled = true;
                tb_endereco.Enabled = true;
                btn_gravar.Enabled = true;
                btn_cancelar.Enabled = true;
                btn_foto.Enabled = true;
                cb_uf.Enabled = true;
                tb_cidade.Enabled = true;

                btn_novo.Enabled = false;
                btn_consulta.Enabled = false;
                btn_alterar.Enabled = false;
            }
        }
        #endregion

    }
}
