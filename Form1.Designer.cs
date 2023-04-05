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
            panel_menu_right.SuspendLayout();
            panel_do_przycisku_konto.SuspendLayout();
            panel_logo.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(14, 323);
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
            panel_menu_right.Location = new Point(806, 0);
            panel_menu_right.Name = "panel_menu_right";
            panel_menu_right.Size = new Size(200, 721);
            panel_menu_right.TabIndex = 5;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1006, 721);
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
    }
}