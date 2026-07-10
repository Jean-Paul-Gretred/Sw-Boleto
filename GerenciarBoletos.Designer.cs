namespace SwBoleto
{
    partial class GerenciarBoletos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerenciarBoletos));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            checkedListBox1 = new CheckedListBox();
            btn_status = new Button();
            button_cancelar = new Button();
            btn_enviar = new Button();
            btn_pesquisar = new Button();
            label3 = new Label();
            cbx_situacao = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            txt_data_fim = new TextBox();
            txt_data_ini = new TextBox();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            Col1 = new DataGridViewCheckBoxColumn();
            statusStrip1 = new StatusStrip();
            stlEmpresa = new ToolStripStatusLabel();
            stlSW = new ToolStripStatusLabel();
            stlServidoBD = new ToolStripStatusLabel();
            stlDataComputador = new ToolStripStatusLabel();
            stlUsuario = new ToolStripStatusLabel();
            lblEmpresa = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.CausesValidation = false;
            panel1.Controls.Add(checkedListBox1);
            panel1.Controls.Add(btn_status);
            panel1.Controls.Add(button_cancelar);
            panel1.Controls.Add(btn_enviar);
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
            panel1.Size = new Size(1263, 68);
            panel1.TabIndex = 23;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = SystemColors.Menu;
            checkedListBox1.CausesValidation = false;
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Data Emissão ", "Data Vencimento" });
            checkedListBox1.Location = new Point(168, 23);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.RightToLeft = RightToLeft.No;
            checkedListBox1.Size = new Size(110, 34);
            checkedListBox1.TabIndex = 11;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // btn_status
            // 
            btn_status.BackColor = SystemColors.ActiveCaption;
            btn_status.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_status.Location = new Point(824, 17);
            btn_status.Name = "btn_status";
            btn_status.Size = new Size(143, 43);
            btn_status.TabIndex = 10;
            btn_status.Text = "Checar Status";
            btn_status.UseVisualStyleBackColor = false;
            btn_status.Click += btn_checar_status;
            // 
            // button_cancelar
            // 
            button_cancelar.BackColor = SystemColors.ActiveCaption;
            button_cancelar.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_cancelar.Location = new Point(1122, 17);
            button_cancelar.Name = "button_cancelar";
            button_cancelar.Size = new Size(138, 43);
            button_cancelar.TabIndex = 9;
            button_cancelar.Text = "Cancelar boletos";
            button_cancelar.UseVisualStyleBackColor = false;
            button_cancelar.Click += btn_Cancelar_click;
            // 
            // btn_enviar
            // 
            btn_enviar.BackColor = SystemColors.ActiveCaption;
            btn_enviar.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_enviar.Location = new Point(973, 17);
            btn_enviar.Name = "btn_enviar";
            btn_enviar.Size = new Size(143, 43);
            btn_enviar.TabIndex = 8;
            btn_enviar.Text = "Enviar boletos";
            btn_enviar.UseVisualStyleBackColor = false;
            btn_enviar.Click += btn_enviar_Click;
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
            btn_pesquisar.Location = new Point(623, 28);
            btn_pesquisar.Name = "btn_pesquisar";
            btn_pesquisar.Size = new Size(144, 33);
            btn_pesquisar.TabIndex = 7;
            btn_pesquisar.Text = "Pesquisar";
            btn_pesquisar.UseVisualStyleBackColor = false;
            btn_pesquisar.Click += btn_pesquisar_Click;
            btn_pesquisar.KeyDown += ENTER_KeyDown_pesquisar;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(496, 22);
            label3.Name = "label3";
            label3.Size = new Size(49, 13);
            label3.TabIndex = 6;
            label3.Text = "Situação";
            // 
            // cbx_situacao
            // 
            cbx_situacao.BackColor = SystemColors.Info;
            cbx_situacao.FormattingEnabled = true;
            cbx_situacao.Location = new Point(496, 36);
            cbx_situacao.Name = "cbx_situacao";
            cbx_situacao.Size = new Size(121, 21);
            cbx_situacao.TabIndex = 5;
            cbx_situacao.KeyDown += ENTER_KeyDown;
            cbx_situacao.Leave += cbxSituação_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(390, 22);
            label2.Name = "label2";
            label2.Size = new Size(49, 13);
            label2.TabIndex = 4;
            label2.Text = "Data Fim";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(284, 22);
            label1.Name = "label1";
            label1.Size = new Size(58, 13);
            label1.TabIndex = 3;
            label1.Text = "Data Inicio";
            // 
            // txt_data_fim
            // 
            txt_data_fim.BackColor = SystemColors.Info;
            txt_data_fim.Location = new Point(390, 36);
            txt_data_fim.Name = "txt_data_fim";
            txt_data_fim.Size = new Size(100, 20);
            txt_data_fim.TabIndex = 2;
            txt_data_fim.KeyDown += ENTER_KeyDown;
            txt_data_fim.Validating += txtDataFim_Validating;
            // 
            // txt_data_ini
            // 
            txt_data_ini.BackColor = SystemColors.Info;
            txt_data_ini.Location = new Point(284, 37);
            txt_data_ini.Name = "txt_data_ini";
            txt_data_ini.Size = new Size(100, 20);
            txt_data_ini.TabIndex = 1;
            txt_data_ini.KeyDown += ENTER_KeyDown;
            txt_data_ini.Validating += txtDataInicio_Validating;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(141, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Info;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Col1 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1263, 458);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
            // 
            // Col1
            // 
            Col1.FalseValue = "false";
            Col1.HeaderText = "";
            Col1.Name = "Col1";
            Col1.TrueValue = "true";
            Col1.Width = 5;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { stlEmpresa, stlSW, stlServidoBD, stlDataComputador, stlUsuario });
            statusStrip1.Location = new Point(0, 526);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1263, 22);
            statusStrip1.TabIndex = 24;
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
            // lblEmpresa
            // 
            lblEmpresa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEmpresa.AutoSize = true;
            lblEmpresa.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmpresa.Location = new Point(20, 3909);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(0, 13);
            lblEmpresa.TabIndex = 25;
            lblEmpresa.TextAlign = ContentAlignment.BottomCenter;
            // 
            // GerenciarBoletos
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1263, 548);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(lblEmpresa);
            Controls.Add(statusStrip1);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(804, 574);
            Name = "GerenciarBoletos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SwBoleto";
            WindowState = FormWindowState.Maximized;
            Load += GerenciarBoletos_Load;
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
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private TextBox txt_data_fim;
        private TextBox txt_data_ini;
        private Label label3;
        private ComboBox cbx_situacao;
        private Label label2;
        private Label label1;
        private Button btn_pesquisar;
        private Button btn_enviar;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel stlEmpresa;
        private ToolStripStatusLabel stlSW;
        private ToolStripStatusLabel stlServidoBD;
        private ToolStripStatusLabel stlDataComputador;
        private ToolStripStatusLabel stlUsuario;
        private Label lblEmpresa;
        private DataGridViewCheckBoxColumn Col1;
        private Button button_cancelar;
        private Button btn_status;
        private CheckedListBox checkedListBox1;
    }
}