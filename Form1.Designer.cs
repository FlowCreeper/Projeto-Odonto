namespace PovaIgor
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
            tabPage2 = new TabPage();
            monthCalendar1 = new MonthCalendar();
            maskedTextBox1 = new MaskedTextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBox4 = new TextBox();
            label6 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            monthCalendar2 = new MonthCalendar();
            label7 = new Label();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            tabPage2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(monthCalendar1);
            tabPage2.Controls.Add(maskedTextBox1);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(823, 463);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Agendar";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(12, 244);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 20;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(12, 90);
            maskedTextBox1.Mask = "(00) 00000-0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(94, 27);
            maskedTextBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(127, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(154, 27);
            textBox2.TabIndex = 17;
            textBox2.Text = "email@mail.com";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(269, 27);
            textBox1.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 221);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 21;
            label4.Text = "Data:";
            // 
            // button2
            // 
            button2.Location = new Point(474, 428);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 19;
            button2.Text = "Limpar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(723, 428);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 18;
            button1.Text = "Agendar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 66);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 16;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 66);
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(831, 496);
            tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(monthCalendar2);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(label5);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(823, 463);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Horários";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 96);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(269, 27);
            textBox4.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 73);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 17;
            label6.Text = "Consultório:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 35);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(269, 27);
            textBox3.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 12);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 15;
            label5.Text = "Nome:";
            // 
            // monthCalendar2
            // 
            monthCalendar2.Location = new Point(12, 244);
            monthCalendar2.Name = "monthCalendar2";
            monthCalendar2.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 221);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 22;
            label7.Text = "Data:";
            // 
            // button3
            // 
            button3.Location = new Point(475, 428);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 24;
            button3.Text = "Limpar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(704, 428);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 23;
            button4.Text = "Cadastrar";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(475, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(323, 387);
            dataGridView1.TabIndex = 25;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(474, 36);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(323, 386);
            dataGridView2.TabIndex = 26;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(293, 244);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 28);
            comboBox1.TabIndex = 27;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(293, 244);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(176, 28);
            comboBox2.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(293, 221);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 29;
            label8.Text = "Horário:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(293, 221);
            label9.Name = "label9";
            label9.Size = new Size(63, 20);
            label9.TabIndex = 28;
            label9.Text = "Horário:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 520);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Sistema Odonto";
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private MonthCalendar monthCalendar1;
        private MaskedTextBox maskedTextBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private Label label5;
        private TextBox textBox4;
        private Label label6;
        private Label label7;
        private MonthCalendar monthCalendar2;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private Label label9;
        private ComboBox comboBox1;
        private Label label8;
        private ComboBox comboBox2;
    }
}