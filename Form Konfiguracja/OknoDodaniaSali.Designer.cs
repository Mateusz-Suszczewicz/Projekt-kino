﻿namespace Projekt_kino.Form_Konfiguracja
{
    partial class OknoDodaniaSali
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
            label1 = new Label();
            tb_numerSali = new TextBox();
            label2 = new Label();
            tb_opis = new TextBox();
            label3 = new Label();
            label4 = new Label();
            tb_iloscRzedow = new TextBox();
            tb_iloscMijesc = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 10);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "numer sali";
            // 
            // tb_numerSali
            // 
            tb_numerSali.Location = new Point(183, 7);
            tb_numerSali.Name = "tb_numerSali";
            tb_numerSali.Size = new Size(100, 23);
            tb_numerSali.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(460, 9);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Opis sali";
            // 
            // tb_opis
            // 
            tb_opis.Location = new Point(532, 7);
            tb_opis.Name = "tb_opis";
            tb_opis.Size = new Size(511, 23);
            tb_opis.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1, 46);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 4;
            label3.Text = "ilość rzędów (max 15):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 80);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 5;
            label4.Text = "ilość miejsc (max 10):";
            // 
            // tb_iloscRzedow
            // 
            tb_iloscRzedow.Location = new Point(183, 43);
            tb_iloscRzedow.Name = "tb_iloscRzedow";
            tb_iloscRzedow.Size = new Size(100, 23);
            tb_iloscRzedow.TabIndex = 6;
            tb_iloscRzedow.TextChanged += tb_iloscRzedow_TextChanged;
            // 
            // tb_iloscMijesc
            // 
            tb_iloscMijesc.Location = new Point(183, 77);
            tb_iloscMijesc.Name = "tb_iloscMijesc";
            tb_iloscMijesc.Size = new Size(100, 23);
            tb_iloscMijesc.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(945, 76);
            button1.Name = "button1";
            button1.Size = new Size(98, 23);
            button1.TabIndex = 8;
            button1.Text = "przeładuj salę";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1197, 826);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Zamknij";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1116, 826);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "Zapisz";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(2, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(1261, 714);
            panel1.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(333, 80);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 12;
            // 
            // OknoDodaniaSali
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 991);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tb_iloscMijesc);
            Controls.Add(tb_iloscRzedow);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tb_opis);
            Controls.Add(label2);
            Controls.Add(tb_numerSali);
            Controls.Add(label1);
            MaximumSize = new Size(1300, 1100);
            MinimumSize = new Size(1300, 1030);
            Name = "OknoDodaniaSali";
            Text = "Dodanie Sali";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_numerSali;
        private Label label2;
        private TextBox tb_opis;
        private Label label3;
        private Label label4;
        private TextBox tb_iloscRzedow;
        private TextBox tb_iloscMijesc;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Label label5;
    }
}