using System;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                string vquery = String.Format(@"INSERT INTO Senha(Senha , Nome)
                                            VALUES('{0}','{1}')", tb_senha.Text, tb_User.Text);
                BancoSQL.dml(vquery);
                MessageBox.Show("Usuário cadastrado com sucesso.");
                tb_senha.Clear();
                tb_User.Clear();
                btn_novo.Focus();
            }catch(SqlException sq)
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
            var exc = new F_consultaUsuario();
            if (exc.ShowDialog() == DialogResult.OK)
            {
                DialogResult res = MessageBox.Show("Deseja Excluir usuário?: ", "Exclusão ", MessageBoxButtons.YesNo);
                {
                    tb_User.Text = exc.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    if (res == DialogResult.Yes)
                    {
                        string delete = @"DELETE FROM Senha where nome='" + tb_User.Text + "'";
                        BancoSQL.dml(delete);
                        MessageBox.Show("Usuário Excluido com sucesso");
                        tb_User.Clear();
                    }
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
