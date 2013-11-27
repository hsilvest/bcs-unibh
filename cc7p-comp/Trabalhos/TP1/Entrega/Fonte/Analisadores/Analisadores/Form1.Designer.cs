namespace Analisadores
{
    partial class FormAnalizador
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvErro = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.textboxTexTexto = new System.Windows.Forms.TextBox();
            this.labelResultado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResultados = new System.Windows.Forms.Label();
            this.labelErros = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelResultadoAnalise = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErro)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexema,
            this.tok,
            this.Posicao,
            this.Linha});
            this.dataGridView1.Location = new System.Drawing.Point(55, 258);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 125);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            // 
            // tok
            // 
            this.tok.HeaderText = "Token";
            this.tok.Name = "tok";
            // 
            // Posicao
            // 
            this.Posicao.HeaderText = "Posicao";
            this.Posicao.Name = "Posicao";
            // 
            // Linha
            // 
            this.Linha.HeaderText = "Linha";
            this.Linha.Name = "Linha";
            // 
            // dgvErro
            // 
            this.dgvErro.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvErro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.dataGridViewTextBoxColumn2});
            this.dgvErro.Location = new System.Drawing.Point(533, 258);
            this.dgvErro.Name = "dgvErro";
            this.dgvErro.Size = new System.Drawing.Size(344, 125);
            this.dgvErro.TabIndex = 1;
            this.dgvErro.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "lexema";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "token";
            this.Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Posicao";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(802, 214);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAnalizar.Size = new System.Drawing.Size(75, 23);
            this.btnAnalizar.TabIndex = 2;
            this.btnAnalizar.Text = "Analisar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // textboxTexTexto
            // 
            this.textboxTexTexto.Location = new System.Drawing.Point(55, 63);
            this.textboxTexTexto.Multiline = true;
            this.textboxTexTexto.Name = "textboxTexTexto";
            this.textboxTexTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxTexTexto.Size = new System.Drawing.Size(822, 145);
            this.textboxTexTexto.TabIndex = 3;
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Location = new System.Drawing.Point(427, 403);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(0, 13);
            this.labelResultado.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // labelResultados
            // 
            this.labelResultados.AutoSize = true;
            this.labelResultados.Location = new System.Drawing.Point(52, 241);
            this.labelResultados.Name = "labelResultados";
            this.labelResultados.Size = new System.Drawing.Size(120, 13);
            this.labelResultados.TabIndex = 7;
            this.labelResultados.Text = "Resultdados da analise:";
            this.labelResultados.Visible = false;
            // 
            // labelErros
            // 
            this.labelErros.AutoSize = true;
            this.labelErros.Location = new System.Drawing.Point(530, 241);
            this.labelErros.Name = "labelErros";
            this.labelErros.Size = new System.Drawing.Size(34, 13);
            this.labelErros.TabIndex = 8;
            this.labelErros.Text = "Erros:";
            this.labelErros.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTitulo.Location = new System.Drawing.Point(794, 35);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(83, 25);
            this.labelTitulo.TabIndex = 9;
            this.labelTitulo.Text = "JACA+";
            // 
            // labelResultadoAnalise
            // 
            this.labelResultadoAnalise.AutoSize = true;
            this.labelResultadoAnalise.Location = new System.Drawing.Point(189, 241);
            this.labelResultadoAnalise.Name = "labelResultadoAnalise";
            this.labelResultadoAnalise.Size = new System.Drawing.Size(0, 13);
            this.labelResultadoAnalise.TabIndex = 10;
            this.labelResultadoAnalise.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelResultadoAnalise.Visible = false;
            // 
            // FormAnalizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 395);
            this.Controls.Add(this.labelResultadoAnalise);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelErros);
            this.Controls.Add(this.labelResultados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.textboxTexTexto);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.dgvErro);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormAnalizador";
            this.Text = "Analisador Lexico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvErro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn tok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.TextBox textboxTexTexto;
        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelResultados;
        private System.Windows.Forms.Label labelErros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linha;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelResultadoAnalise;
    }
}

