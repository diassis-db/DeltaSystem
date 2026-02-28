using System;
using System.Windows.Forms;

namespace DeltaSystem
{
    public partial class F_principal : Form
    {
        public F_principal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do sistema?", "Aviso:", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void F_principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (MessageBox.Show("Deseja sair do sistema?", "Atenção:", MessageBoxButtons.YesNo) == DialogResult.Yes)
            Application.Exit();
        }

        private void vendasDiversasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            F_Usuario usuario = new F_Usuario();
            usuario.Show();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            F_Login v = new F_Login();
            v.ShowDialog();
              
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cad_cliente cli = new Cad_cliente();
            cli.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Produtos produto = new F_Produtos();
            produto.Show();
        }
    }
}
