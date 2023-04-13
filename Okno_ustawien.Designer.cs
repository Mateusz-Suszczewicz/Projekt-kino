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
            button1 = new Button();
            btn_ustawienia_zamknij = new Button();
            Label_info = new Label();
            btn_ustawienia_skrypty = new Button();
            SuspendLayout();
            // 
            // button_okno_ustawien_zapisz
            // 
            button_okno_ustawien_zapisz.Location = new Point(277, 208);
            button_okno_ustawien_zapisz.Margin = new Padding(3, 2, 3, 2);
            button_okno_ustawien_zapisz.Name = "button_okno_ustawien_zapisz";
            button_okno_ustawien_zapisz.Size = new Size(266, 28);
            button_okno_ustawien_zapisz.TabIndex = 0;
            button_okno_ustawien_zapisz.Text = "Zapisz";
            button_okno_ustawien_zapisz.UseVisualStyleBackColor = true;
            button_okno_ustawien_zapisz.Click += button_okno_ustawien_zapisz_Click;
            // 
            // textBox_okno_ustawien_serwer
            // 
            textBox_okno_ustawien_serwer.Location = new Point(277, 36);
            textBox_okno_ustawien_serwer.Margin = new Padding(3, 2, 3, 2);
            textBox_okno_ustawien_serwer.Name = "textBox_okno_ustawien_serwer";
            textBox_okno_ustawien_serwer.Size = new Size(266, 23);
            textBox_okno_ustawien_serwer.TabIndex = 1;
            // 
            // textBox_okno_ustawien_baza_danych
            // 
            textBox_okno_ustawien_baza_danych.Location = new Point(277, 71);
            textBox_okno_ustawien_baza_danych.Margin = new Padding(3, 2, 3, 2);
            textBox_okno_ustawien_baza_danych.Name = "textBox_okno_ustawien_baza_danych";
            textBox_okno_ustawien_baza_danych.Size = new Size(266, 23);
            textBox_okno_ustawien_baza_danych.TabIndex = 2;
            // 
            // textBox_okno_ustawien_login
            // 
            textBox_okno_ustawien_login.Location = new Point(277, 134);
            textBox_okno_ustawien_login.Margin = new Padding(3, 2, 3, 2);
            textBox_okno_ustawien_login.Name = "textBox_okno_ustawien_login";
            textBox_okno_ustawien_login.Size = new Size(266, 23);
            textBox_okno_ustawien_login.TabIndex = 3;
            // 
            // textBox_okno_ustawien_haslo
            // 
            textBox_okno_ustawien_haslo.Location = new Point(277, 170);
            textBox_okno_ustawien_haslo.Margin = new Padding(3, 2, 3, 2);
            textBox_okno_ustawien_haslo.Name = "textBox_okno_ustawien_haslo";
            textBox_okno_ustawien_haslo.Size = new Size(266, 23);
            textBox_okno_ustawien_haslo.TabIndex = 4;
            // 
            // checkBox_metoda_logowania
            // 
            checkBox_metoda_logowania.AutoSize = true;
            checkBox_metoda_logowania.Location = new Point(277, 106);
            checkBox_metoda_logowania.Margin = new Padding(3, 2, 3, 2);
            checkBox_metoda_logowania.Name = "checkBox_metoda_logowania";
            checkBox_metoda_logowania.Size = new Size(15, 14);
            checkBox_metoda_logowania.TabIndex = 5;
            checkBox_metoda_logowania.UseVisualStyleBackColor = true;
            checkBox_metoda_logowania.CheckedChanged += checkBox_metoda_logowania_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 38);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 6;
            label1.Text = "Serwer/nazwa komputera:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 71);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 7;
            label2.Text = "Baza danych:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 106);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 8;
            label3.Text = "Logowanie zintegrowane";
            // 
            // label_login
            // 
            label_login.AutoSize = true;
            label_login.Location = new Point(229, 134);
            label_login.Name = "label_login";
            label_login.Size = new Size(40, 15);
            label_login.TabIndex = 9;
            label_login.Text = "Login:";
            // 
            // label_haslo
            // 
            label_haslo.AutoSize = true;
            label_haslo.Location = new Point(228, 170);
            label_haslo.Name = "label_haslo";
            label_haslo.Size = new Size(40, 15);
            label_haslo.TabIndex = 10;
            label_haslo.Text = "Hasło:";
            // 
            // button1
            // 
            button1.Location = new Point(277, 240);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(266, 28);
            button1.TabIndex = 11;
            button1.Text = "Testuj połączenie";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btn_ustawienia_zamknij
            // 
            btn_ustawienia_zamknij.DialogResult = DialogResult.Cancel;
            btn_ustawienia_zamknij.Location = new Point(588, 299);
            btn_ustawienia_zamknij.Margin = new Padding(3, 2, 3, 2);
            btn_ustawienia_zamknij.Name = "btn_ustawienia_zamknij";
            btn_ustawienia_zamknij.Size = new Size(100, 28);
            btn_ustawienia_zamknij.TabIndex = 12;
            btn_ustawienia_zamknij.Text = "Zamknij";
            btn_ustawienia_zamknij.UseVisualStyleBackColor = true;
            // 
            // Label_info
            // 
            Label_info.AutoSize = true;
            Label_info.Location = new Point(24, 298);
            Label_info.Name = "Label_info";
            Label_info.Size = new Size(0, 15);
            Label_info.TabIndex = 13;
            // 
            // btn_ustawienia_skrypty
            // 
            btn_ustawienia_skrypty.Location = new Point(277, 272);
            btn_ustawienia_skrypty.Margin = new Padding(3, 2, 3, 2);
            btn_ustawienia_skrypty.Name = "btn_ustawienia_skrypty";
            btn_ustawienia_skrypty.Size = new Size(266, 28);
            btn_ustawienia_skrypty.TabIndex = 14;
            btn_ustawienia_skrypty.Text = "Zainstaluj skrypty";
            btn_ustawienia_skrypty.UseVisualStyleBackColor = true;
            btn_ustawienia_skrypty.Click += btn_ustawienia_skrypty_Click;
            // 
            // Okno_ustawien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(btn_ustawienia_skrypty);
            Controls.Add(Label_info);
            Controls.Add(btn_ustawienia_zamknij);
            Controls.Add(button1);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private Button button1;
        private Button btn_ustawienia_zamknij;
        private Label Label_info;
        private Button btn_ustawienia_skrypty;
    }
}