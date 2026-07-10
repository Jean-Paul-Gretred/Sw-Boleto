namespace SwBoleto
{

    partial class FrmAcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcesso));
            txtUS_NOME = new TextBox();
            label1 = new Label();
            txtUS_SENHA = new TextBox();
            label2 = new Label();
            btnOK = new Button();
            btnSair = new Button();
            btnHelp = new Button();
            btnSairFrm = new Button();
            SuspendLayout();
            // 
            // txtUS_NOME
            // 
            txtUS_NOME.BackColor = SystemColors.Info;
            txtUS_NOME.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUS_NOME.Location = new Point(33, 33);
            txtUS_NOME.Margin = new Padding(4, 3, 4, 3);
            txtUS_NOME.MaxLength = 20;
            txtUS_NOME.Name = "txtUS_NOME";
            txtUS_NOME.Size = new Size(180, 22);
            txtUS_NOME.TabIndex = 0;
            txtUS_NOME.KeyDown += ENTER_KeyDown;
            txtUS_NOME.Leave += txtUS_NOME_Leave;
            txtUS_NOME.PreviewKeyDown += ESCAPE_PreviewKeyDown;
            txtUS_NOME.Validating += txtUS_NOME_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 14;
            label1.Text = "Usuario";
            // 
            // txtUS_SENHA
            // 
            txtUS_SENHA.BackColor = SystemColors.Info;
            txtUS_SENHA.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUS_SENHA.Location = new Point(33, 81);
            txtUS_SENHA.Margin = new Padding(4, 3, 4, 3);
            txtUS_SENHA.MaxLength = 30;
            txtUS_SENHA.Name = "txtUS_SENHA";
            txtUS_SENHA.PasswordChar = '*';
            txtUS_SENHA.Size = new Size(219, 22);
            txtUS_SENHA.TabIndex = 1;
            txtUS_SENHA.KeyDown += ENTER_KeyDown;
            txtUS_SENHA.PreviewKeyDown += ESCAPE_PreviewKeyDown;
            txtUS_SENHA.Validating += txtUS_SENHA_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 62);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 16;
            label2.Text = "Senha";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(52, 138);
            btnOK.Margin = new Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 29);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnSair
            // 
            btnSair.CausesValidation = false;
            btnSair.Location = new Point(147, 138);
            btnSair.Margin = new Padding(4, 3, 4, 3);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(88, 29);
            btnSair.TabIndex = 3;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.Transparent;
            btnHelp.CausesValidation = false;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnHelp.Image = (Image)resources.GetObject("btnHelp.Image");
            btnHelp.Location = new Point(221, 27);
            btnHelp.Margin = new Padding(4, 3, 4, 3);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(32, 35);
            btnHelp.TabIndex = 5;
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnSairFrm
            // 
            btnSairFrm.CausesValidation = false;
            btnSairFrm.DialogResult = DialogResult.Cancel;
            btnSairFrm.Location = new Point(220, 138);
            btnSairFrm.Margin = new Padding(4, 3, 4, 3);
            btnSairFrm.Name = "btnSairFrm";
            btnSairFrm.Size = new Size(14, 29);
            btnSairFrm.TabIndex = 17;
            btnSairFrm.UseVisualStyleBackColor = true;
            btnSairFrm.Click += btnSairFrm_Click;
            // 
            // FrmAcesso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSairFrm;
            ClientSize = new Size(532, 202);
            Controls.Add(btnHelp);
            Controls.Add(btnSair);
            Controls.Add(btnOK);
            Controls.Add(txtUS_SENHA);
            Controls.Add(label2);
            Controls.Add(txtUS_NOME);
            Controls.Add(label1);
            Controls.Add(btnSairFrm);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmAcesso";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SwNFe4 - FrmAcesso";
            FormClosed += FrmAcesso_FormClosed;
            Load += FrmMotivoCancelamentoNFe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUS_NOME;
        private Label label1;
        private TextBox txtUS_SENHA;
        private Label label2;
        private Button btnOK;
        private Button btnSair;
        private Button btnHelp;
        private Button btnSairFrm;
    }

}