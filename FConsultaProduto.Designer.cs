namespace DeltaSystem
{
    partial class FConsultaProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_consultaProdutos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultaProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_consultaProdutos
            // 
            this.dgv_consultaProdutos.AllowUserToAddRows = false;
            this.dgv_consultaProdutos.AllowUserToDeleteRows = false;
            this.dgv_consultaProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_consultaProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_consultaProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_consultaProdutos.Location = new System.Drawing.Point(7, 10);
            this.dgv_consultaProdutos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_consultaProdutos.MultiSelect = false;
            this.dgv_consultaProdutos.Name = "dgv_consultaProdutos";
            this.dgv_consultaProdutos.ReadOnly = true;
            this.dgv_consultaProdutos.RowHeadersVisible = false;
            this.dgv_consultaProdutos.RowHeadersWidth = 51;
            this.dgv_consultaProdutos.RowTemplate.Height = 24;
            this.dgv_consultaProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_consultaProdutos.Size = new System.Drawing.Size(377, 219);
            this.dgv_consultaProdutos.TabIndex = 0;
            this.dgv_consultaProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_consultaProdutos_CellDoubleClick);
            // 
            // FConsultaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 239);
            this.Controls.Add(this.dgv_consultaProdutos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FConsultaProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Produtos";
            this.Load += new System.EventHandler(this.FConsultaProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultaProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_consultaProdutos;
    }
}