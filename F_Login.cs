using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeltaSystem
{
    public partial class F_Login : Form
    {
        SqlConnection conectarLogin = new SqlConnection();
        public F_Login()
        {
            InitializeComponent();
            
        }

        private void bot_confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Preencher usuário e senha!");
                    textBox2.Focus();
                }
                else
                {
                    conectarLogin.Open();
                    string query = "SELECT * FROM Senha WHERE Nome='" + textBox2.Text + "' AND Senha='" + textBox1.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conectarLogin);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conectarLogin.Close();

                    if (dt.Rows.Count == 1)
                    {
                        this.Hide();
                        F_principal f = new F_principal();
                        f.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha não encontrado.");
                        textBox2.Focus();

                    }
                }
            }
            catch (SqlException sq)
            {
                MessageBox.Show(sq.ToString(), "ERROR: Falha de conexão com o Banco de dados!!! ");
            }
            
        }

        private void bot_fechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do sistema?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void F_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Converte o texto digitado em maiúsculo
            textBox2.Text = textBox2.Text.ToUpper();
            textBox2.SelectionStart = textBox2.Text.Length; // precisa destes comandos para o texto não sair invertido. 
            textBox2.SelectionLength = 0; // colocar este comando também.
        }
    }
}
