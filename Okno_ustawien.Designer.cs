namespace Projekt_kino
{
    partial class Okno_ustawien
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
            button_okno_ustawien_zapisz = new Button();
            textBox_okno_ustawien_serwer = new TextBox();
            textBox_okno_ustawien_baza_danych = new TextBox();
            textBox_okno_ustawien_login = new TextBox();
            textBox_okno_ustawien_haslo = new TextBox();
            checkBox_metoda_logowania = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label_login = new Label();
            label_haslo = new Label();
            SuspendLayout();
            // 
            // button_okno_ustawien_zapisz
            // 
            button_okno_ustawien_zapisz.Location = new Point(317, 277);
            button_okno_ustawien_zapisz.Name = "button_okno_ustawien_zapisz";
            button_okno_ustawien_zapisz.Size = new Size(304, 69);
            button_okno_ustawien_zapisz.TabIndex = 0;
            button_okno_ustawien_zapisz.Text = "Zapisz";
            button_okno_ustawien_zapisz.UseVisualStyleBackColor = true;
            button_okno_ustawien_zapisz.Click += button_okno_ustawien_zapisz_Click;
            // 
            // textBox_okno_ustawien_serwer
            // 
            textBox_okno_ustawien_serwer.Location = new Point(317, 48);
            textBox_okno_ustawien_serwer.Name = "textBox_okno_ustawien_serwer";
            textBox_okno_ustawien_serwer.Size = new Size(304, 27);
            textBox_okno_ustawien_serwer.TabIndex = 1;
            textBox_okno_ustawien_serwer.TextChanged += textBox_okno_ustawien_serwer_TextChanged;
            // 
            // textBox_okno_ustawien_baza_danych
            // 
            textBox_okno_ustawien_baza_danych.Location = new Point(317, 95);
            textBox_okno_ustawien_baza_danych.Name = "textBox_okno_ustawien_baza_danych";
            textBox_okno_ustawien_baza_danych.Size = new Size(304, 27);
            textBox_okno_ustawien_baza_danych.TabIndex = 2;
            textBox_okno_ustawien_baza_danych.TextChanged += textBox_okno_ustawien_baza_danych_TextChanged;
            // 
            // textBox_okno_ustawien_login
            // 
            textBox_okno_ustawien_login.Location = new Point(317, 178);
            textBox_okno_ustawien_login.Name = "textBox_okno_ustawien_login";
            textBox_okno_ustawien_login.Size = new Size(304, 27);
            textBox_okno_ustawien_login.TabIndex = 3;
            textBox_okno_ustawien_login.TextChanged += textBox_okno_ustawien_login_TextChanged;
            // 
            // textBox_okno_ustawien_haslo
            // 
            textBox_okno_ustawien_haslo.Location = new Point(317, 226);
            textBox_okno_ustawien_haslo.Name = "textBox_okno_ustawien_haslo";
            textBox_okno_ustawien_haslo.Size = new Size(304, 27);
            textBox_okno_ustawien_haslo.TabIndex = 4;
            textBox_okno_ustawien_haslo.TextChanged += textBox_okno_ustawien_haslo_TextChanged;
            // 
            // checkBox_metoda_logowania
            // 
            checkBox_metoda_logowania.AutoSize = true;
            checkBox_metoda_logowania.Location = new Point(317, 141);
            checkBox_metoda_logowania.Name = "checkBox_metoda_logowania";
            checkBox_metoda_logowania.Size = new Size(18, 17);
            checkBox_metoda_logowania.TabIndex = 5;
            checkBox_metoda_logowania.UseVisualStyleBackColor = true;
            checkBox_metoda_logowania.CheckedChanged += checkBox_metoda_logowania_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 51);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 6;
            label1.Text = "Serwer/nazwa komputera:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 95);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 7;
            label2.Text = "Baza danych:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(173, 138);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 8;
            label3.Text = "Metoda logowania:";
            // 
            // label_login
            // 
            label_login.AutoSize = true;
            label_login.Location = new Point(262, 178);
            label_login.Name = "label_login";
            label_login.Size = new Size(49, 20);
            label_login.TabIndex = 9;
            label_login.Text = "Login:";
            label_login.Click += label_login_Click;
            // 
            // label_haslo
            // 
            label_haslo.AutoSize = true;
            label_haslo.Location = new Point(261, 226);
            label_haslo.Name = "label_haslo";
            label_haslo.Size = new Size(50, 20);
            label_haslo.TabIndex = 10;
            label_haslo.Text = "Hasło:";
            label_haslo.Click += label_haslo_Click;
            // 
            // Okno_ustawien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_haslo);
            Controls.Add(label_login);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBox_metoda_logowania);
            Controls.Add(textBox_okno_ustawien_haslo);
            Controls.Add(textBox_okno_ustawien_login);
            Controls.Add(textBox_okno_ustawien_baza_danych);
            Controls.Add(textBox_okno_ustawien_serwer);
            Controls.Add(button_okno_ustawien_zapisz);
            Name = "Okno_ustawien";
            Text = "Okno_ustawien";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_okno_ustawien_zapisz;
        private TextBox textBox_okno_ustawien_serwer;
        private TextBox textBox_okno_ustawien_baza_danych;
        private TextBox textBox_okno_ustawien_login;
        private TextBox textBox_okno_ustawien_haslo;
        private CheckBox checkBox_metoda_logowania;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label_login;
        private Label label_haslo;
    }
}