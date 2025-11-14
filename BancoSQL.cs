using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DeltaSystem
{
    class BancoSQL
    {
        public static SqlConnection conexaoBanco()
        {
            string caminho = @"Data Source = DIASSIS-PC; Initial CATALOG=Delta; User ID = sa; Password=12345";
            SqlConnection conexao = new SqlConnection(caminho);
            try
            {
                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                return conexao;
            }
            catch (SqlException sq)
            {
                MessageBox.Show(sq.Message, "ERROR: Falha de conexão com o Banco de dados!!! ");
                return null;
            }
        }

        public static void dml(string v, string msgOK = null, string msgErro = null)
        {
            SqlDataAdapter da = null;
            try
            {
                var cp = conexaoBanco();
                var cmd = cp.CreateCommand();
                cmd.CommandText = v;
                da = new SqlDataAdapter(cmd.CommandText, cp);
                cmd.ExecuteNonQuery();
                cp.Close();
                if (msgOK != null)
                {
                    MessageBox.Show(msgOK);
                }
            }
            catch (Exception ex)
            {
                if (msgErro != null)
                {
                    MessageBox.Show(msgErro + "\n" + ex.Message);
                }
            }
        }

        public static void GravarNovoProduto(Produto p)
        {
            try
            {
                var cmd = conexaoBanco().CreateCommand();
                cmd.CommandText = "INSERT INTO Produtos(Descricao , Preco, Quantidade) VALUES(@nome , @preco, @quantidade)";
                cmd.Parameters.AddWithValue("@nome", p.Nome);
                cmd.Parameters.AddWithValue("@preco", p.Preco);
                cmd.Parameters.AddWithValue("@quantidade", p.Quantidade);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto cadastrado com sucesso.");
                conexaoBanco().Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "ERROR:");
            }
        }
    }
}
