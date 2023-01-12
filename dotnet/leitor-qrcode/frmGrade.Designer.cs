
namespace leitor_qrcode
{
    partial class frmGrade
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
            this.dgNota = new System.Windows.Forms.DataGridView();
            this.NrmNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataEmissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaveAcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdTotalItens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgNota)).BeginInit();
            this.SuspendLayout();
            // 
            // dgNota
            // 
            this.dgNota.AllowUserToAddRows = false;
            this.dgNota.AllowUserToDeleteRows = false;
            this.dgNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NrmNota,
            this.serie,
            this.dataEmissao,
            this.chaveAcesso,
            this.qtdTotalItens,
            this.valorTotal,
            this.itens});
            this.dgNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgNota.Location = new System.Drawing.Point(0, 0);
            this.dgNota.Name = "dgNota";
            this.dgNota.ReadOnly = true;
            this.dgNota.RowHeadersVisible = false;
            this.dgNota.Size = new System.Drawing.Size(800, 450);
            this.dgNota.TabIndex = 0;
            // 
            // NrmNota
            // 
            this.NrmNota.DataPropertyName = "Numero";
            this.NrmNota.HeaderText = "Número";
            this.NrmNota.Name = "NrmNota";
            this.NrmNota.ReadOnly = true;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "Serie";
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            // 
            // dataEmissao
            // 
            this.dataEmissao.DataPropertyName = "Emissao";
            this.dataEmissao.HeaderText = "Emissão";
            this.dataEmissao.Name = "dataEmissao";
            this.dataEmissao.ReadOnly = true;
            // 
            // chaveAcesso
            // 
            this.chaveAcesso.DataPropertyName = "Chave";
            this.chaveAcesso.HeaderText = "Chave";
            this.chaveAcesso.Name = "chaveAcesso";
            this.chaveAcesso.ReadOnly = true;
            // 
            // qtdTotalItens
            // 
            this.qtdTotalItens.DataPropertyName = "Quantidade";
            this.qtdTotalItens.HeaderText = "Qtd Itens";
            this.qtdTotalItens.Name = "qtdTotalItens";
            this.qtdTotalItens.ReadOnly = true;
            // 
            // valorTotal
            // 
            this.valorTotal.DataPropertyName = "Total";
            this.valorTotal.HeaderText = "Total";
            this.valorTotal.Name = "valorTotal";
            this.valorTotal.ReadOnly = true;
            // 
            // itens
            // 
            this.itens.DataPropertyName = "Itens";
            this.itens.HeaderText = "Itens";
            this.itens.Name = "itens";
            this.itens.ReadOnly = true;
            // 
            // frmGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgNota);
            this.Name = "frmGrade";
            this.Text = "frmGrade";
            ((System.ComponentModel.ISupportInitialize)(this.dgNota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NrmNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataEmissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaveAcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdTotalItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn itens;
    }
}