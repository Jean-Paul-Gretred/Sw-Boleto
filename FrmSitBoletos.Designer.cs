namespace SwBoleto
{
    partial class FrmSitBoletos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSitBoletos));
            panel1 = new Panel();
            btn_pesquisar = new Button();
            label3 = new Label();
            cbx_situacao = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            txt_data_fim = new TextBox();
            txt_data_ini = new TextBox();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            stlEmpresa = new ToolStripStatusLabel();
            stlSW = new ToolStripStatusLabel();
            stlServidoBD = new ToolStripStatusLabel();
            stlDataComputador = new ToolStripStatusLabel();
            stlUsuario = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_pesquisar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbx_situacao);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txt_data_fim);
            panel1.Controls.Add(txt_data_ini);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 76);
            panel1.TabIndex = 1;
            // 
            // btn_pesquisar
            // 
            btn_pesquisar.BackColor = SystemColors.ActiveCaption;
            btn_pesquisar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_pesquisar.FlatAppearance.BorderColor = Color.Black;
            btn_pesquisar.FlatAppearance.BorderSize = 2;
            btn_pesquisar.FlatAppearance.MouseDownBackColor = Color.Black;
            btn_pesquisar.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_pesquisar.ForeColor = Color.Black;
            btn_pesquisar.Location = new Point(593, 23);
            btn_pesquisar.Name = "btn_pesquisar";
            btn_pesquisar.Size = new Size(149, 30);
            btn_pesquisar.TabIndex = 15;
            btn_pesquisar.Text = "Pesquisar";
            btn_pesquisar.UseVisualStyleBackColor = false;
            btn_pesquisar.Click += btn_pesquisar_Click;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(404, 16);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 14;
            label3.Text = "Situação";
            // 
            // cbx_situacao
            // 
            cbx_situacao.BackColor = SystemColors.Info;
            cbx_situacao.FormattingEnabled = true;
            cbx_situacao.Location = new Point(404, 30);
            cbx_situacao.Name = "cbx_situacao";
            cbx_situacao.Size = new Size(121, 23);
            cbx_situacao.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(288, 16);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 12;
            label2.Text = "Data Fim";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(170, 16);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 11;
            label1.Text = "Data Inicio";
            // 
            // txt_data_fim
            // 
            txt_data_fim.BackColor = SystemColors.Info;
            txt_data_fim.Location = new Point(288, 30);
            txt_data_fim.Name = "txt_data_fim";
            txt_data_fim.Size = new Size(100, 23);
            txt_data_fim.TabIndex = 10;
            // 
            // txt_data_ini
            // 
            txt_data_ini.BackColor = SystemColors.Info;
            txt_data_ini.Location = new Point(170, 30);
            txt_data_ini.Name = "txt_data_ini";
            txt_data_ini.Size = new Size(100, 23);
            txt_data_ini.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(141, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Info;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 76);
            dataGridView1.MinimumSize = new Size(887, 390);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(887, 390);
            dataGridView1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { stlEmpresa, stlSW, stlServidoBD, stlDataComputador, stlUsuario });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 25;
            statusStrip1.Text = "statusStrip1";
            // 
            // stlEmpresa
            // 
            stlEmpresa.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            stlEmpresa.BorderStyle = Border3DStyle.SunkenOuter;
            stlEmpresa.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            stlEmpresa.Name = "stlEmpresa";
            stlEmpresa.Size = new Size(60, 17);
            stlEmpresa.Text = "Empresa";
            // 
            // stlSW
            // 
            stlSW.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            stlSW.BorderStyle = Border3DStyle.SunkenOuter;
            stlSW.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            stlSW.Name = "stlSW";
            stlSW.Size = new Size(132, 17);
            stlSW.Text = "Software Informática";
            // 
            // stlServidoBD
            // 
            stlServidoBD.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            stlServidoBD.BorderStyle = Border3DStyle.SunkenOuter;
            stlServidoBD.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            stlServidoBD.Name = "stlServidoBD";
            stlServidoBD.Size = new Size(158, 17);
            stlServidoBD.Text = "Servidor + BancoDeDados";
            // 
            // stlDataComputador
            // 
            stlDataComputador.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            stlDataComputador.BorderStyle = Border3DStyle.SunkenOuter;
            stlDataComputador.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            stlDataComputador.Name = "stlDataComputador";
            stlDataComputador.Size = new Size(128, 17);
            stlDataComputador.Text = "Data do Computador";
            // 
            // stlUsuario
            // 
            stlUsuario.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            stlUsuario.BorderStyle = Border3DStyle.SunkenOuter;
            stlUsuario.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            stlUsuario.Name = "stlUsuario";
            stlUsuario.Size = new Size(54, 17);
            stlUsuario.Text = "Usuario";
            // 
            // FrmSitBoletos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "FrmSitBoletos";
            Text = "FmrSitBoletos";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btn_pesquisar;
        private Label label3;
        private ComboBox cbx_situacao;
        private Label label2;
        private Label label1;
        private TextBox txt_data_fim;
        private TextBox txt_data_ini;
        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel stlEmpresa;
        private ToolStripStatusLabel stlSW;
        private ToolStripStatusLabel stlServidoBD;
        private ToolStripStatusLabel stlDataComputador;
        private ToolStripStatusLabel stlUsuario;
    }
}