using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DeltaSystem
{
    public partial class F_Usuario : Form
    {
        public F_Usuario()
        {
            InitializeComponent();
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"INSERT INTO Senha (Senha, Nome)
                       VALUES (@senha, @nome)";

                var parametros = new Dictionary<string, object>
                {
                    { "@senha", tb_senha.Text },
                    { "@nome", tb_User.Text }
                };

                BancoSQL.Dml(sql, parametros, "Usuário cadastrado com sucesso!");

                tb_senha.Clear();
                tb_User.Clear();
                btn_novo.Focus();
            }
            catch (SqlException sq)
            {
                MessageBox.Show(sq.Message, "Error:");
            }
        }

        private void F_Usuario_Load(object sender, EventArgs e)
        {
            btn_gravar.Enabled = false;
            btn_novo.TabIndex = 0;
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cancela_Click(object sender, EventArgs e)
        {
            btn_gravar.Enabled = false;
            btn_excluir.Enabled = true;
            btn_novo.Enabled = true;
            tb_senha.ReadOnly = false;
            tb_User.ReadOnly = false;
            btn_fechar.Enabled = true;
            btn_consulta.Enabled = true;
            tb_senha.Enabled = false;
            tb_User.Enabled = false;
            btn_novo.TabIndex = 0;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            var g = new F_consultaUsuario();
            if (g.ShowDialog() == DialogResult.OK)
            {
                tb_User.Text = g.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb_senha.Text = g.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void tb_User_TextChanged(object sender, EventArgs e)
        {
            tb_User.Text = tb_User.Text.ToUpper();
            tb_User.SelectionStart = tb_User.Text.Length;
            tb_User.SelectionLength = 0;
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            var consulta = new F_consultaUsuario();

            if (consulta.ShowDialog() == DialogResult.OK)
            {
                // Verifica se existe linha selecionada
                if (consulta.dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Nenhum usuário selecionado.");
                    return;
                }

                string nome = consulta.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb_User.Text = nome;

                DialogResult res = MessageBox.Show(
                    $"Deseja excluir o usuário '{nome}'?",
                    "Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (res == DialogResult.Yes)
                {
                    string sql = @"DELETE FROM Senha WHERE Nome = @nome";

                    var parametros = new Dictionary<string, object>
                    {
                        { "@nome", nome }
                    };

                    BancoSQL.Dml(sql, parametros, "Usuário excluído com sucesso!");

                    tb_User.Clear();
                }
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            btn_gravar.Enabled = true;
            btn_consulta.Enabled = false;
            btn_novo.Enabled = false;
            btn_cancela.Enabled = true;
            tb_senha.ReadOnly = false;
            tb_User.ReadOnly = false;
            tb_senha.Enabled = true;
            tb_User.Enabled = true;
            tb_User.Clear();
            tb_senha.Clear();
            tb_senha.Focus();
            btn_excluir.Enabled = false;
        }
    }
}
