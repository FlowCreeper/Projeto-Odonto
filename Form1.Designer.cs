﻿namespace PovaIgor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabPage2 = new TabPage();
            btnDelCliente = new Button();
            bntReagendar = new Button();
            label12 = new Label();
            cbxMedico = new ComboBox();
            lblMedico = new Label();
            label9 = new Label();
            cbxHorario = new ComboBox();
            dgvCliente = new DataGridView();
            mclCliente = new MonthCalendar();
            mtbTelefone = new MaskedTextBox();
            tbxEmail = new TextBox();
            tbxNomeCliente = new TextBox();
            label4 = new Label();
            btnLimpar2 = new Button();
            btnAgendar = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage1 = new TabPage();
            label10 = new Label();
            mtbConsultorio = new MaskedTextBox();
            label8 = new Label();
            cbxHorario1 = new ComboBox();
            dgvCadastro = new DataGridView();
            btnLimpar1 = new Button();
            btnCadastrar = new Button();
            label7 = new Label();
            mclCadastro = new MonthCalendar();
            tbxNomeDr = new TextBox();
            label6 = new Label();
            label5 = new Label();
            tabControl1 = new TabControl();
            btnDelDr = new Button();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCliente).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCadastro).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnDelCliente);
            tabPage2.Controls.Add(bntReagendar);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(cbxMedico);
            tabPage2.Controls.Add(lblMedico);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(cbxHorario);
            tabPage2.Controls.Add(dgvCliente);
            tabPage2.Controls.Add(mclCliente);
            tabPage2.Controls.Add(mtbTelefone);
            tabPage2.Controls.Add(tbxEmail);
            tabPage2.Controls.Add(tbxNomeCliente);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(btnLimpar2);
            tabPage2.Controls.Add(btnAgendar);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(823, 443);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Agendar";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDelCliente
            // 
            btnDelCliente.Location = new Point(423, 408);
            btnDelCliente.Name = "btnDelCliente";
            btnDelCliente.Size = new Size(94, 29);
            btnDelCliente.TabIndex = 35;
            btnDelCliente.Text = "Excluir";
            btnDelCliente.UseVisualStyleBackColor = true;
            btnDelCliente.Click += btnDelCliente_Click;
            // 
            // bntReagendar
            // 
            bntReagendar.Location = new Point(523, 408);
            bntReagendar.Name = "bntReagendar";
            bntReagendar.Size = new Size(94, 29);
            bntReagendar.TabIndex = 34;
            bntReagendar.Text = "Reagendar ";
            bntReagendar.UseVisualStyleBackColor = true;
            bntReagendar.Click += bntReagendar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(306, 13);
            label12.Name = "label12";
            label12.Size = new Size(64, 20);
            label12.TabIndex = 33;
            label12.Text = "Agenda:";
            // 
            // cbxMedico
            // 
            cbxMedico.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMedico.Location = new Point(80, 128);
            cbxMedico.Name = "cbxMedico";
            cbxMedico.Size = new Size(201, 28);
            cbxMedico.TabIndex = 30;
            cbxMedico.SelectedValueChanged += cbxMedico_SelectedValueChanged;
            // 
            // lblMedico
            // 
            lblMedico.AutoSize = true;
            lblMedico.Location = new Point(11, 131);
            lblMedico.Name = "lblMedico";
            lblMedico.Size = new Size(62, 20);
            lblMedico.TabIndex = 29;
            lblMedico.Text = "Médico:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 411);
            label9.Name = "label9";
            label9.Size = new Size(63, 20);
            label9.TabIndex = 28;
            label9.Text = "Horário:";
            // 
            // cbxHorario
            // 
            cbxHorario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxHorario.FormattingEnabled = true;
            cbxHorario.Location = new Point(80, 408);
            cbxHorario.Name = "cbxHorario";
            cbxHorario.Size = new Size(201, 28);
            cbxHorario.TabIndex = 27;
            // 
            // dgvCliente
            // 
            dgvCliente.AllowUserToAddRows = false;
            dgvCliente.AllowUserToDeleteRows = false;
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Location = new Point(306, 36);
            dgvCliente.Name = "dgvCliente";
            dgvCliente.RowHeadersWidth = 51;
            dgvCliente.RowTemplate.Height = 29;
            dgvCliente.Size = new Size(511, 366);
            dgvCliente.TabIndex = 26;
            dgvCliente.CellEndEdit += dgvCliente_CellEndEdit;
            // 
            // mclCliente
            // 
            mclCliente.Location = new Point(13, 195);
            mclCliente.Name = "mclCliente";
            mclCliente.TabIndex = 20;
            mclCliente.DateSelected += mclCliente_DateSelected;
            // 
            // mtbTelefone
            // 
            mtbTelefone.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtbTelefone.Location = new Point(11, 91);
            mtbTelefone.Mask = "(00) 00000-0000";
            mtbTelefone.Name = "mtbTelefone";
            mtbTelefone.Size = new Size(110, 27);
            mtbTelefone.TabIndex = 15;
            mtbTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // tbxEmail
            // 
            tbxEmail.Location = new Point(127, 91);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.Size = new Size(154, 27);
            tbxEmail.TabIndex = 17;
            tbxEmail.Text = "email@mail.com";
            tbxEmail.Enter += tbxEmail_Enter;
            tbxEmail.Leave += tbxEmail_Leave;
            // 
            // tbxNomeCliente
            // 
            tbxNomeCliente.Location = new Point(13, 36);
            tbxNomeCliente.Name = "tbxNomeCliente";
            tbxNomeCliente.Size = new Size(269, 27);
            tbxNomeCliente.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 165);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 21;
            label4.Text = "Data:";
            // 
            // btnLimpar2
            // 
            btnLimpar2.Location = new Point(623, 408);
            btnLimpar2.Name = "btnLimpar2";
            btnLimpar2.Size = new Size(94, 29);
            btnLimpar2.TabIndex = 19;
            btnLimpar2.Text = "Limpar";
            btnLimpar2.UseVisualStyleBackColor = true;
            btnLimpar2.Click += btnLimpar2_Click;
            // 
            // btnAgendar
            // 
            btnAgendar.Location = new Point(723, 407);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(94, 29);
            btnAgendar.TabIndex = 18;
            btnAgendar.Text = "Agendar";
            btnAgendar.UseVisualStyleBackColor = true;
            btnAgendar.Click += btnAgendar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 67);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 16;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 67);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 14;
            label2.Text = "Telefone:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 13;
            label1.Text = "Nome:";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnDelDr);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(mtbConsultorio);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(cbxHorario1);
            tabPage1.Controls.Add(dgvCadastro);
            tabPage1.Controls.Add(btnLimpar1);
            tabPage1.Controls.Add(btnCadastrar);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(mclCadastro);
            tabPage1.Controls.Add(tbxNomeDr);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(823, 443);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Cadastro";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(328, 12);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 31;
            label10.Text = "Horários:";
            // 
            // mtbConsultorio
            // 
            mtbConsultorio.Location = new Point(11, 96);
            mtbConsultorio.Mask = "99999";
            mtbConsultorio.Name = "mtbConsultorio";
            mtbConsultorio.Size = new Size(179, 27);
            mtbConsultorio.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 402);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 29;
            label8.Text = "Horário:";
            // 
            // cbxHorario1
            // 
            cbxHorario1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxHorario1.FormattingEnabled = true;
            cbxHorario1.Location = new Point(80, 399);
            cbxHorario1.Name = "cbxHorario1";
            cbxHorario1.Size = new Size(175, 28);
            cbxHorario1.TabIndex = 28;
            // 
            // dgvCadastro
            // 
            dgvCadastro.AllowUserToAddRows = false;
            dgvCadastro.AllowUserToDeleteRows = false;
            dgvCadastro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCadastro.Location = new Point(328, 35);
            dgvCadastro.Name = "dgvCadastro";
            dgvCadastro.RowHeadersWidth = 51;
            dgvCadastro.RowTemplate.Height = 29;
            dgvCadastro.Size = new Size(470, 357);
            dgvCadastro.TabIndex = 25;
            dgvCadastro.CellEndEdit += dgvCadastro_CellEndEdit;
            // 
            // btnLimpar1
            // 
            btnLimpar1.Location = new Point(604, 398);
            btnLimpar1.Name = "btnLimpar1";
            btnLimpar1.Size = new Size(94, 29);
            btnLimpar1.TabIndex = 24;
            btnLimpar1.Text = "Limpar";
            btnLimpar1.UseVisualStyleBackColor = true;
            btnLimpar1.Click += btnLimpar1_Click;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(704, 399);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(94, 29);
            btnCadastrar.TabIndex = 23;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 144);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 22;
            label7.Text = "Data:";
            // 
            // mclCadastro
            // 
            mclCadastro.Location = new Point(11, 167);
            mclCadastro.Name = "mclCadastro";
            mclCadastro.TabIndex = 21;
            mclCadastro.DateSelected += mclCadastro_DateSelected;
            // 
            // tbxNomeDr
            // 
            tbxNomeDr.Location = new Point(11, 35);
            tbxNomeDr.Name = "tbxNomeDr";
            tbxNomeDr.Size = new Size(269, 27);
            tbxNomeDr.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 73);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 17;
            label6.Text = "Consultório:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 12);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 15;
            label5.Text = "Nome:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(11, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(831, 476);
            tabControl1.TabIndex = 12;
            // 
            // btnDelDr
            // 
            btnDelDr.Location = new Point(504, 398);
            btnDelDr.Name = "btnDelDr";
            btnDelDr.Size = new Size(94, 29);
            btnDelDr.TabIndex = 32;
            btnDelDr.Text = "Excluir";
            btnDelDr.UseVisualStyleBackColor = true;
            btnDelDr.Click += btnDelDr_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 499);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Odonto";
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCliente).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCadastro).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage2;
        private Label lblMedico;
        private Label label9;
        private ComboBox cbxHorario;
        private DataGridView dgvCliente;
        private MonthCalendar mclCliente;
        private MaskedTextBox mtbTelefone;
        private TextBox tbxEmail;
        private TextBox tbxNomeCliente;
        private Label label4;
        private Button btnLimpar2;
        private Button btnAgendar;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage tabPage1;
        private Label label8;
        private ComboBox cbxHorario1;
        private DataGridView dgvCadastro;
        private Button btnLimpar1;
        private Button btnCadastrar;
        private Label label7;
        private MonthCalendar mclCadastro;
        private TextBox tbxNomeDr;
        private Label label6;
        private Label label5;
        private TabControl tabControl1;
        private ComboBox cbxMedico;
        private Label label12;
        private Button bntReagendar;
        private MaskedTextBox mtbConsultorio;
        private Label label10;
        private Button btnDelCliente;
        private Button btnDelDr;
    }
}