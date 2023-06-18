namespace Projekt_kino.Form_Konfiguracja
{
    partial class OknoDodaniaSeansu
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
            sala = new Label();
            listBox1 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            tb_dataRoz = new TextBox();
            tb_godzRoz = new TextBox();
            tb_godzZak = new TextBox();
            tb_dataZak = new TextBox();
            SuspendLayout();
            // 
            // sala
            // 
            sala.AutoSize = true;
            sala.Location = new Point(41, 42);
            sala.Name = "sala";
            sala.Size = new Size(69, 15);
            sala.TabIndex = 0;
            sala.Text = "Sala kinowa";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(116, 42);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 34);
            listBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(322, 9);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "FIlm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 97);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 3;
            label3.Text = "Data rozpoczęcia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 5;
            label4.Text = "Data zakończenia";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 97);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 9;
            label5.Text = "Godzina rozpoczęcia";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(322, 138);
            label6.Name = "label6";
            label6.Size = new Size(117, 15);
            label6.TabIndex = 10;
            label6.Text = "Godzina zakończenia";
            // 
            // button1
            // 
            button1.Location = new Point(713, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Zamknij";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(632, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "Zapisz";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tb_dataRoz
            // 
            tb_dataRoz.Location = new Point(136, 94);
            tb_dataRoz.Name = "tb_dataRoz";
            tb_dataRoz.Size = new Size(100, 23);
            tb_dataRoz.TabIndex = 13;
            // 
            // tb_godzRoz
            // 
            tb_godzRoz.Location = new Point(464, 94);
            tb_godzRoz.Name = "tb_godzRoz";
            tb_godzRoz.Size = new Size(100, 23);
            tb_godzRoz.TabIndex = 14;
            // 
            // tb_godzZak
            // 
            tb_godzZak.Enabled = false;
            tb_godzZak.Location = new Point(464, 138);
            tb_godzZak.Name = "tb_godzZak";
            tb_godzZak.Size = new Size(100, 23);
            tb_godzZak.TabIndex = 15;
            // 
            // tb_dataZak
            // 
            tb_dataZak.Enabled = false;
            tb_dataZak.Location = new Point(136, 138);
            tb_dataZak.Name = "tb_dataZak";
            tb_dataZak.Size = new Size(100, 23);
            tb_dataZak.TabIndex = 16;
            // 
            // OknoDodaniaSeansu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tb_dataZak);
            Controls.Add(tb_godzZak);
            Controls.Add(tb_godzRoz);
            Controls.Add(tb_dataRoz);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(sala);
            Name = "OknoDodaniaSeansu";
            Text = "Dodanie Seansu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label sala;
        private ListBox listBox1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtp_dataRoz;
        private Label label4;
        private DateTimePicker dtp_godzZak;
        private DateTimePicker dtp_dataZak;
        private DateTimePicker dtp_godzRozp;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
        private TextBox tb_dataRoz;
        private TextBox tb_godzRoz;
        private TextBox tb_godzZak;
        private TextBox tb_dataZak;
    }
}