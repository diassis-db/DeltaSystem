using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DeltaSystem
{
    class BancoSQL
    {
        private static string connectionString =
            @"";
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
    }
}
