namespace Projekt_kino.Form_Konfiguracja
{
    partial class OknoStworzeniaAktora
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
            label2 = new Label();
            label3 = new Label();
            tb_imie = new TextBox();
            tb_nazwisko = new TextBox();
            tb_kraj = new TextBox();
            button1 = new Button();
            button2 = new Button();
            info = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 93);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Imie";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 120);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Nazwisko";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 147);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 2;
            label3.Text = "Kraj";
            // 
            // tb_imie
            // 
            tb_imie.Location = new Point(196, 90);
            tb_imie.Name = "tb_imie";
            tb_imie.Size = new Size(100, 23);
            tb_imie.TabIndex = 3;
            // 
            // tb_nazwisko
            // 
            tb_nazwisko.Location = new Point(196, 117);
            tb_nazwisko.Name = "tb_nazwisko";
            tb_nazwisko.Size = new Size(100, 23);
            tb_nazwisko.TabIndex = 4;
            // 
            // tb_kraj
            // 
            tb_kraj.Location = new Point(196, 144);
            tb_kraj.Name = "tb_kraj";
            tb_kraj.Size = new Size(100, 23);
            tb_kraj.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(713, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Zamknij";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(622, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "dodaj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Location = new Point(12, 419);
            info.Name = "info";
            info.Size = new Size(0, 15);
            info.TabIndex = 8;
            // 
            // OknoStworzeniaAktora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(info);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tb_kraj);
            Controls.Add(tb_nazwisko);
            Controls.Add(tb_imie);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OknoStworzeniaAktora";
            Text = "OknoStworzeniaAktora";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tb_imie;
        private TextBox tb_nazwisko;
        private TextBox tb_kraj;
        private Button button1;
        private Button button2;
        private Label info;
    }
}