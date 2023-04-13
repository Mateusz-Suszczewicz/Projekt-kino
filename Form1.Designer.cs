namespace Projekt_kino
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            aktualny_czas = new Label();
            panel_menu_right = new Panel();
            ustawienia = new Button();
            przycisk_repertuar = new Button();
            panel_do_przycisku_konto = new Panel();
            Konto_subMenu_logowanie = new Button();
            Konto_subMenu_rejestracja = new Button();
            przycisk_konto = new Button();
            panel_logo = new Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1 = new Panel();
            panel_rejestracja = new Panel();
            button_rejestracja_zaloz_konto = new Button();
            textBox_rejestracja_haslo = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            linkLabel_rejestracja_zaloguj_sie = new LinkLabel();
            textBox_rejestracja_haslo_2 = new TextBox();
            textBox_rejestracja_haslo_1 = new TextBox();
            textBox_rejestracja_login = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel_logowanie = new Panel();
            button1 = new Button();
            linkLabel_logowanie_zarejestruj_sie = new LinkLabel();
            label9 = new Label();
            linkLabel1 = new LinkLabel();
            label8 = new Label();
            label7 = new Label();
            label_logowanie_haslo = new Label();
            label_logowanie_login = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            panel_menu_right.SuspendLayout();
            panel_do_przycisku_konto.SuspendLayout();
            panel_logo.SuspendLayout();
            panel_rejestracja.SuspendLayout();
            panel_logowanie.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(54, 323);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(886, 20);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // aktualny_czas
            // 
            aktualny_czas.Dock = DockStyle.Top;
            aktualny_czas.Font = new Font("Showcard Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point);
            aktualny_czas.ForeColor = Color.Gold;
            aktualny_czas.Location = new Point(0, 0);
            aktualny_czas.Name = "aktualny_czas";
            aktualny_czas.Size = new Size(200, 93);
            aktualny_czas.TabIndex = 4;
            aktualny_czas.Text = "Willkommen!";
            aktualny_czas.TextAlign = ContentAlignment.MiddleCenter;
            aktualny_czas.Click += label1_Click;
            // 
            // panel_menu_right
            // 
            panel_menu_right.AutoScroll = true;
            panel_menu_right.BackColor = Color.Firebrick;
            panel_menu_right.Controls.Add(ustawienia);
            panel_menu_right.Controls.Add(przycisk_repertuar);
            panel_menu_right.Controls.Add(panel_do_przycisku_konto);
            panel_menu_right.Controls.Add(przycisk_konto);
            panel_menu_right.Controls.Add(panel_logo);
            panel_menu_right.Dock = DockStyle.Right;
            panel_menu_right.Location = new Point(886, 0);
            panel_menu_right.Name = "panel_menu_right";
            panel_menu_right.Size = new Size(200, 721);
            panel_menu_right.TabIndex = 5;
            panel_menu_right.Paint += panel_menu_right_Paint;
            // 
            // ustawienia
            // 
            ustawienia.Location = new Point(94, 680);
            ustawienia.Name = "ustawienia";
            ustawienia.Size = new Size(94, 29);
            ustawienia.TabIndex = 4;
            ustawienia.Text = "ustawienia";
            ustawienia.UseVisualStyleBackColor = true;
            ustawienia.Click += ustawienia_Click;
            // 
            // przycisk_repertuar
            // 
            przycisk_repertuar.BackColor = Color.LightSalmon;
            przycisk_repertuar.Dock = DockStyle.Top;
            przycisk_repertuar.FlatStyle = FlatStyle.Flat;
            przycisk_repertuar.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            przycisk_repertuar.Location = new Point(0, 306);
            przycisk_repertuar.Name = "przycisk_repertuar";
            przycisk_repertuar.Size = new Size(200, 60);
            przycisk_repertuar.TabIndex = 3;
            przycisk_repertuar.Text = "Repertuar";
            przycisk_repertuar.UseVisualStyleBackColor = false;
            // 
            // panel_do_przycisku_konto
            // 
            panel_do_przycisku_konto.AutoSize = true;
            panel_do_przycisku_konto.BackColor = Color.IndianRed;
            panel_do_przycisku_konto.Controls.Add(Konto_subMenu_logowanie);
            panel_do_przycisku_konto.Controls.Add(Konto_subMenu_rejestracja);
            panel_do_przycisku_konto.Cursor = Cursors.No;
            panel_do_przycisku_konto.Dock = DockStyle.Top;
            panel_do_przycisku_konto.Location = new Point(0, 186);
            panel_do_przycisku_konto.Name = "panel_do_przycisku_konto";
            panel_do_przycisku_konto.Size = new Size(200, 120);
            panel_do_przycisku_konto.TabIndex = 2;
            // 
            // Konto_subMenu_logowanie
            // 
            Konto_subMenu_logowanie.Cursor = Cursors.Arrow;
            Konto_subMenu_logowanie.Dock = DockStyle.Top;
            Konto_subMenu_logowanie.FlatStyle = FlatStyle.Flat;
            Konto_subMenu_logowanie.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Konto_subMenu_logowanie.Location = new Point(0, 60);
            Konto_subMenu_logowanie.Margin = new Padding(0);
            Konto_subMenu_logowanie.Name = "Konto_subMenu_logowanie";
            Konto_subMenu_logowanie.Size = new Size(200, 60);
            Konto_subMenu_logowanie.TabIndex = 1;
            Konto_subMenu_logowanie.Text = "Logowanie •";
            Konto_subMenu_logowanie.UseVisualStyleBackColor = true;
            Konto_subMenu_logowanie.Click += Konto_subMenu_logowanie_Click;
            // 
            // Konto_subMenu_rejestracja
            // 
            Konto_subMenu_rejestracja.Cursor = Cursors.Arrow;
            Konto_subMenu_rejestracja.Dock = DockStyle.Top;
            Konto_subMenu_rejestracja.FlatStyle = FlatStyle.Flat;
            Konto_subMenu_rejestracja.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Konto_subMenu_rejestracja.Location = new Point(0, 0);
            Konto_subMenu_rejestracja.Margin = new Padding(0);
            Konto_subMenu_rejestracja.Name = "Konto_subMenu_rejestracja";
            Konto_subMenu_rejestracja.Size = new Size(200, 60);
            Konto_subMenu_rejestracja.TabIndex = 0;
            Konto_subMenu_rejestracja.Text = "Rejestracja •";
            Konto_subMenu_rejestracja.UseVisualStyleBackColor = true;
            Konto_subMenu_rejestracja.Click += Konto_subMenu_rejestracja_Click;
            // 
            // przycisk_konto
            // 
            przycisk_konto.BackColor = Color.LightSalmon;
            przycisk_konto.Dock = DockStyle.Top;
            przycisk_konto.FlatStyle = FlatStyle.Flat;
            przycisk_konto.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            przycisk_konto.Location = new Point(0, 126);
            przycisk_konto.Name = "przycisk_konto";
            przycisk_konto.Size = new Size(200, 60);
            przycisk_konto.TabIndex = 1;
            przycisk_konto.Text = "Konto ••";
            przycisk_konto.UseVisualStyleBackColor = false;
            przycisk_konto.Click += przycisk_konto_Click;
            // 
            // panel_logo
            // 
            panel_logo.Controls.Add(aktualny_czas);
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(200, 126);
            panel_logo.TabIndex = 0;
            panel_logo.Paint += panel_logo_Paint;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.IndianRed;
            panel1.Location = new Point(143, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 6;
            // 
            // panel_rejestracja
            // 
            panel_rejestracja.Anchor = AnchorStyles.None;
            panel_rejestracja.AutoSize = true;
            panel_rejestracja.BackColor = Color.IndianRed;
            panel_rejestracja.Controls.Add(button_rejestracja_zaloz_konto);
            panel_rejestracja.Controls.Add(textBox_rejestracja_haslo);
            panel_rejestracja.Controls.Add(label6);
            panel_rejestracja.Controls.Add(label5);
            panel_rejestracja.Controls.Add(label4);
            panel_rejestracja.Controls.Add(linkLabel_rejestracja_zaloguj_sie);
            panel_rejestracja.Controls.Add(textBox_rejestracja_haslo_2);
            panel_rejestracja.Controls.Add(textBox_rejestracja_haslo_1);
            panel_rejestracja.Controls.Add(textBox_rejestracja_login);
            panel_rejestracja.Controls.Add(label3);
            panel_rejestracja.Controls.Add(label2);
            panel_rejestracja.Controls.Add(label1);
            panel_rejestracja.Location = new Point(143, 200);
            panel_rejestracja.MinimumSize = new Size(100, 100);
            panel_rejestracja.Name = "panel_rejestracja";
            panel_rejestracja.Size = new Size(647, 398);
            panel_rejestracja.TabIndex = 7;
            // 
            // button_rejestracja_zaloz_konto
            // 
            button_rejestracja_zaloz_konto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button_rejestracja_zaloz_konto.Location = new Point(221, 251);
            button_rejestracja_zaloz_konto.Name = "button_rejestracja_zaloz_konto";
            button_rejestracja_zaloz_konto.Size = new Size(208, 40);
            button_rejestracja_zaloz_konto.TabIndex = 12;
            button_rejestracja_zaloz_konto.Text = "Załóż konto";
            button_rejestracja_zaloz_konto.UseVisualStyleBackColor = true;
            // 
            // textBox_rejestracja_haslo
            // 
            textBox_rejestracja_haslo.Location = new Point(189, 66);
            textBox_rejestracja_haslo.Name = "textBox_rejestracja_haslo";
            textBox_rejestracja_haslo.Size = new Size(276, 27);
            textBox_rejestracja_haslo.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(118, 62);
            label6.Name = "label6";
            label6.Size = new Size(63, 28);
            label6.TabIndex = 10;
            label6.Text = "Email:";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Yellow;
            label5.Location = new Point(43, 213);
            label5.Name = "label5";
            label5.Size = new Size(559, 35);
            label5.TabIndex = 9;
            label5.Text = "Nie widoczne, pojawi się w momencie kiedy zwróci jakiś błąd ";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(221, 308);
            label4.Name = "label4";
            label4.Size = new Size(208, 28);
            label4.TabIndex = 8;
            label4.Text = "Posiadasz już konto?";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabel_rejestracja_zaloguj_sie
            // 
            linkLabel_rejestracja_zaloguj_sie.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel_rejestracja_zaloguj_sie.Location = new Point(221, 336);
            linkLabel_rejestracja_zaloguj_sie.Name = "linkLabel_rejestracja_zaloguj_sie";
            linkLabel_rejestracja_zaloguj_sie.Size = new Size(208, 28);
            linkLabel_rejestracja_zaloguj_sie.TabIndex = 7;
            linkLabel_rejestracja_zaloguj_sie.TabStop = true;
            linkLabel_rejestracja_zaloguj_sie.Text = "Zaloguj się";
            linkLabel_rejestracja_zaloguj_sie.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel_rejestracja_zaloguj_sie.LinkClicked += linkLabel_rejestracja_zaloguj_sie_LinkClicked;
            // 
            // textBox_rejestracja_haslo_2
            // 
            textBox_rejestracja_haslo_2.Location = new Point(189, 169);
            textBox_rejestracja_haslo_2.Name = "textBox_rejestracja_haslo_2";
            textBox_rejestracja_haslo_2.Size = new Size(276, 27);
            textBox_rejestracja_haslo_2.TabIndex = 5;
            // 
            // textBox_rejestracja_haslo_1
            // 
            textBox_rejestracja_haslo_1.Location = new Point(189, 119);
            textBox_rejestracja_haslo_1.Name = "textBox_rejestracja_haslo_1";
            textBox_rejestracja_haslo_1.Size = new Size(276, 27);
            textBox_rejestracja_haslo_1.TabIndex = 4;
            // 
            // textBox_rejestracja_login
            // 
            textBox_rejestracja_login.Location = new Point(189, 22);
            textBox_rejestracja_login.Name = "textBox_rejestracja_login";
            textBox_rejestracja_login.Size = new Size(276, 27);
            textBox_rejestracja_login.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(30, 165);
            label3.Name = "label3";
            label3.Size = new Size(153, 28);
            label3.TabIndex = 2;
            label3.Text = "Potwierdź hasło:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(118, 115);
            label2.Name = "label2";
            label2.Size = new Size(65, 28);
            label2.TabIndex = 1;
            label2.Text = "Hasło:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(118, 18);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 0;
            label1.Text = "Login:";
            // 
            // panel_logowanie
            // 
            panel_logowanie.BackColor = Color.IndianRed;
            panel_logowanie.Controls.Add(button1);
            panel_logowanie.Controls.Add(linkLabel_logowanie_zarejestruj_sie);
            panel_logowanie.Controls.Add(label9);
            panel_logowanie.Controls.Add(linkLabel1);
            panel_logowanie.Controls.Add(label8);
            panel_logowanie.Controls.Add(label7);
            panel_logowanie.Controls.Add(label_logowanie_haslo);
            panel_logowanie.Controls.Add(label_logowanie_login);
            panel_logowanie.Controls.Add(textBox3);
            panel_logowanie.Controls.Add(textBox2);
            panel_logowanie.Location = new Point(146, 186);
            panel_logowanie.Name = "panel_logowanie";
            panel_logowanie.Size = new Size(638, 325);
            panel_logowanie.TabIndex = 8;
            panel_logowanie.Paint += panel_logowanie_Paint;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(272, 162);
            button1.Name = "button1";
            button1.Size = new Size(116, 38);
            button1.TabIndex = 9;
            button1.Text = "Zaloguj się";
            button1.UseVisualStyleBackColor = true;
            // 
            // linkLabel_logowanie_zarejestruj_sie
            // 
            linkLabel_logowanie_zarejestruj_sie.AutoSize = true;
            linkLabel_logowanie_zarejestruj_sie.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel_logowanie_zarejestruj_sie.Location = new Point(317, 262);
            linkLabel_logowanie_zarejestruj_sie.Name = "linkLabel_logowanie_zarejestruj_sie";
            linkLabel_logowanie_zarejestruj_sie.Size = new Size(131, 28);
            linkLabel_logowanie_zarejestruj_sie.TabIndex = 8;
            linkLabel_logowanie_zarejestruj_sie.TabStop = true;
            linkLabel_logowanie_zarejestruj_sie.Text = "Zarejestruj się";
            linkLabel_logowanie_zarejestruj_sie.LinkClicked += linkLabel_logowanie_zarejestruj_sie_LinkClicked;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(114, 263);
            label9.Name = "label9";
            label9.Size = new Size(197, 28);
            label9.TabIndex = 7;
            label9.Text = "Nie posiadasz konta?";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.Location = new Point(317, 216);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(162, 28);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Przypomnij hasło";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(118, 212);
            label8.Name = "label8";
            label8.Size = new Size(193, 28);
            label8.TabIndex = 5;
            label8.Text = "Nie pamiętasz hasła?";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Yellow;
            label7.Location = new Point(52, 129);
            label7.Name = "label7";
            label7.Size = new Size(544, 28);
            label7.TabIndex = 4;
            label7.Text = "Nie widoczne, pojawi się w momencie kiedy zwróci jakiś błąd ";
            // 
            // label_logowanie_haslo
            // 
            label_logowanie_haslo.AutoSize = true;
            label_logowanie_haslo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_logowanie_haslo.Location = new Point(116, 83);
            label_logowanie_haslo.Name = "label_logowanie_haslo";
            label_logowanie_haslo.Size = new Size(65, 28);
            label_logowanie_haslo.TabIndex = 3;
            label_logowanie_haslo.Text = "Hasło:";
            // 
            // label_logowanie_login
            // 
            label_logowanie_login.AutoSize = true;
            label_logowanie_login.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_logowanie_login.Location = new Point(118, 37);
            label_logowanie_login.Name = "label_logowanie_login";
            label_logowanie_login.Size = new Size(65, 28);
            label_logowanie_login.TabIndex = 2;
            label_logowanie_login.Text = "Login:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(189, 87);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(276, 27);
            textBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(189, 44);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(276, 27);
            textBox2.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1086, 721);
            Controls.Add(panel_logowanie);
            Controls.Add(panel_rejestracja);
            Controls.Add(panel1);
            Controls.Add(panel_menu_right);
            Controls.Add(textBox1);
            ForeColor = Color.Black;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(1024, 768);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel_menu_right.ResumeLayout(false);
            panel_menu_right.PerformLayout();
            panel_do_przycisku_konto.ResumeLayout(false);
            panel_logo.ResumeLayout(false);
            panel_rejestracja.ResumeLayout(false);
            panel_rejestracja.PerformLayout();
            panel_logowanie.ResumeLayout(false);
            panel_logowanie.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Label aktualny_czas;
        private Panel panel_menu_right;
        private Button przycisk_konto;
        private Panel panel_logo;
        private Panel panel_do_przycisku_konto;
        private Button Konto_subMenu_logowanie;
        private Button Konto_subMenu_rejestracja;
        private Button przycisk_repertuar;
        private Button ustawienia;
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private Panel panel_rejestracja;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label4;
        private LinkLabel linkLabel_rejestracja_zaloguj_sie;
        private TextBox textBox_rejestracja_haslo_2;
        private TextBox textBox_rejestracja_haslo_1;
        private TextBox textBox_rejestracja_login;
        private Label label3;
        private Button button_rejestracja_zaloz_konto;
        private TextBox textBox_rejestracja_haslo;
        private Label label6;
        private Panel panel_logowanie;
        private Button button1;
        private LinkLabel linkLabel_logowanie_zarejestruj_sie;
        private Label label9;
        private LinkLabel linkLabel1;
        private Label label8;
        private Label label7;
        private Label label_logowanie_haslo;
        private Label label_logowanie_login;
        private TextBox textBox3;
        private TextBox textBox2;
    }
}