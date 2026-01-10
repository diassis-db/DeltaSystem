using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DeltaSystem
{
    class BancoSQL
    {
        private static string connectionString =
            @"Data Source=DIASSIS-PC; Initial Catalog=Delta; User ID=sa; Password=12345";
        public static SqlConnection ConexaoBanco()
        {
            return new SqlConnection(connectionString);
        }

        public static void Dml(string sql, Dictionary<string, object> parametros,
                               string msgOK = null, string msgErro = null)
        {
            try
            {
                using (SqlConnection conexao = ConexaoBanco())
                {
                    conexao.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        if (parametros != null)
                        {
                            foreach (var p in parametros)
                                cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                if (!string.IsNullOrEmpty(msgOK))
                    MessageBox.Show(msgOK);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(msgErro))
                    MessageBox.Show(msgErro + "\n" + ex.Message);
            }
        }

        public static void GravarNovoProduto(Produto p)
        {
                string sql = @"INSERT INTO Produtos (Descricao, Preco, Quantidade)
                           VALUES (@desc, @preco, @qtd)";
                var parametros = new Dictionary<string, object>
                {
                    { "@desc", p.Nome },
                    { "@preco", p.Preco },
                    { "@qtd", p.Quantidade }
                };

                Dml(sql, parametros, "Produto cadastrado com sucesso!",
                    "Erro ao cadastrar produto");
        }

        public static DataTable VerificarUsuarioESenhaExistente(string sql, Dictionary<string, object> parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    using (var comando = new SqlCommand(sql, conexao))
                    {
                        foreach (var par in parametros)
                        {
                            comando.Parameters.AddWithValue(par.Key, par.Value);
                        }
                        SqlDataAdapter da = new SqlDataAdapter(comando);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
