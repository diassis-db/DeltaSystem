using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DeltaSystem
{
    public partial class FormConsultaCliente : Form
    {
        
        public FormConsultaCliente()
        {
            InitializeComponent();
        }

        private void FormConsultaCliente_Load(object sender, EventArgs e)
        {
            //dataGridView2.Columns[0].Width = 80;
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var conectar = BancoSQL.ConexaoBanco();
            var cmd = conectar.CreateCommand();
            cmd.CommandText = @"SELECT Id, Nome, Celular, CPF, Endereco, Cep, UF, cidade FROM  Cliente";
            da = new SqlDataAdapter(cmd.CommandText, conectar);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            conectar.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dataGridView2.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                
                this.Close();
            }
        }
    }
}
