using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaSystem
{
    public partial class F_consultaUsuario : Form
    {
        public F_consultaUsuario()
        {
            InitializeComponent();
        }

        private void F_consultaUsuario_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            var conectar = BancoSQL.conexaoBanco();
            var cmd = conectar.CreateCommand();
            cmd.CommandText = @"Select Nome, Senha from Senha";
            da = new SqlDataAdapter(cmd.CommandText, conectar);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
            conectar.Close();
                        
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
