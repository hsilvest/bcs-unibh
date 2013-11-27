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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalizador));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coluna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvErro = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linhas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.textboxTexTexto = new System.Windows.Forms.TextBox();
            this.labelResultado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResultados = new System.Windows.Forms.Label();
            this.labelErros = new System.Windows.Forms.Label();
            this.labelResultadoAnalise = new System.Windows.Forms.Label();
            this.textBoxArquivo = new System.Windows.Forms.TextBox();
            this.buttonProcurar = new System.Windows.Forms.Button();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integrantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelQuantErros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErro)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexema,
            this.tok,
            this.Coluna,
            this.Linha});
            this.dataGridView1.Location = new System.Drawing.Point(11, 259);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(603, 139);
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
            this.tok.FillWeight = 250F;
            this.tok.HeaderText = "Token";
            this.tok.Name = "tok";
            // 
            // Coluna
            // 
            this.Coluna.HeaderText = "Coluna";
            this.Coluna.Name = "Coluna";
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
            this.dataGridViewTextBoxColumn2,
            this.Linhas});
            this.dgvErro.Location = new System.Drawing.Point(12, 435);
            this.dgvErro.Name = "dgvErro";
            this.dgvErro.Size = new System.Drawing.Size(602, 139);
            this.dgvErro.TabIndex = 1;
            this.dgvErro.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Lexema";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Erro";
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Coluna";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Linhas
            // 
            this.Linhas.HeaderText = "Linha";
            this.Linhas.Name = "Linhas";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(565, 233);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAnalizar.Size = new System.Drawing.Size(53, 23);
            this.btnAnalizar.TabIndex = 2;
            this.btnAnalizar.Text = "Analisar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // textboxTexTexto
            // 
            this.textboxTexTexto.Location = new System.Drawing.Point(12, 82);
            this.textboxTexTexto.Multiline = true;
            this.textboxTexTexto.Name = "textboxTexTexto";
            this.textboxTexTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxTexTexto.Size = new System.Drawing.Size(602, 145);
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
            this.labelResultados.Location = new System.Drawing.Point(12, 238);
            this.labelResultados.Name = "labelResultados";
            this.labelResultados.Size = new System.Drawing.Size(120, 13);
            this.labelResultados.TabIndex = 7;
            this.labelResultados.Text = "Resultdados da analise:";
            this.labelResultados.Visible = false;
            // 
            // labelErros
            // 
            this.labelErros.AutoSize = true;
            this.labelErros.Location = new System.Drawing.Point(9, 419);
            this.labelErros.Name = "labelErros";
            this.labelErros.Size = new System.Drawing.Size(34, 13);
            this.labelErros.TabIndex = 8;
            this.labelErros.Text = "Erros:";
            this.labelErros.Visible = false;
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
            // textBoxArquivo
            // 
            this.textBoxArquivo.Location = new System.Drawing.Point(12, 38);
            this.textBoxArquivo.Name = "textBoxArquivo";
            this.textBoxArquivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxArquivo.Size = new System.Drawing.Size(288, 20);
            this.textBoxArquivo.TabIndex = 11;
            // 
            // buttonProcurar
            // 
            this.buttonProcurar.Location = new System.Drawing.Point(306, 37);
            this.buttonProcurar.Name = "buttonProcurar";
            this.buttonProcurar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonProcurar.Size = new System.Drawing.Size(97, 20);
            this.buttonProcurar.TabIndex = 13;
            this.buttonProcurar.Text = "Procurar";
            this.buttonProcurar.UseVisualStyleBackColor = true;
            this.buttonProcurar.Click += new System.EventHandler(this.buttonProcurar_Click);
            // 
            // ofd1
            // 
            this.ofd1.FileName = "ofd1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.integrantesToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // integrantesToolStripMenuItem
            // 
            this.integrantesToolStripMenuItem.Name = "integrantesToolStripMenuItem";
            this.integrantesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.integrantesToolStripMenuItem.Text = "Integrantes";
            this.integrantesToolStripMenuItem.Click += new System.EventHandler(this.integrantesToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::Analisadores.Properties.Resources.jaca__logo1;
            this.pictureBox1.Location = new System.Drawing.Point(547, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 76);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 16;
            this.label2.Visible = false;
            // 
            // labelQuantErros
            // 
            this.labelQuantErros.AutoSize = true;
            this.labelQuantErros.Location = new System.Drawing.Point(49, 419);
            this.labelQuantErros.Name = "labelQuantErros";
            this.labelQuantErros.Size = new System.Drawing.Size(26, 13);
            this.labelQuantErros.TabIndex = 17;
            this.labelQuantErros.Text = "Erro";
            this.labelQuantErros.Visible = false;
            // 
            // FormAnalizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(627, 259);
            this.Controls.Add(this.labelQuantErros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonProcurar);
            this.Controls.Add(this.textBoxArquivo);
            this.Controls.Add(this.labelResultadoAnalise);
            this.Controls.Add(this.labelErros);
            this.Controls.Add(this.labelResultados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.textboxTexTexto);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.dgvErro);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnalizador";
            this.Text = "Analisador Lexico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErro)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvErro;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.TextBox textboxTexTexto;
        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelResultados;
        private System.Windows.Forms.Label labelErros;
        private System.Windows.Forms.Label labelResultadoAnalise;
        private System.Windows.Forms.TextBox textBoxArquivo;
        private System.Windows.Forms.Button buttonProcurar;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linhas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integrantesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn tok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelQuantErros;
    }
}

