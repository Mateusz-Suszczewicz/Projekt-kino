namespace Projekt_kino.Form_Konfiguracja
{
    partial class OknoKonfiguracji
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
            tabControl = new TabControl();
            tabsale = new TabPage();
            info = new Label();
            button6 = new Button();
            button3 = new Button();
            dgvSale = new DataGridView();
            tabfilmy = new TabPage();
            button5 = new Button();
            button2 = new Button();
            dgvFilm = new DataGridView();
            tabOper = new TabPage();
            button4 = new Button();
            button1 = new Button();
            dgvOper = new DataGridView();
            tabKat = new TabPage();
            label1 = new Label();
            button8 = new Button();
            button7 = new Button();
            dgvKategorie = new DataGridView();
            tabAktorzy = new TabPage();
            label2 = new Label();
            btn_dodajAktora = new Button();
            btn_usunAktora = new Button();
            dgvAktorzy = new DataGridView();
            tabControl.SuspendLayout();
            tabsale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSale).BeginInit();
            tabfilmy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFilm).BeginInit();
            tabOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOper).BeginInit();
            tabKat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKategorie).BeginInit();
            tabAktorzy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAktorzy).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabsale);
            tabControl.Controls.Add(tabfilmy);
            tabControl.Controls.Add(tabOper);
            tabControl.Controls.Add(tabKat);
            tabControl.Controls.Add(tabAktorzy);
            tabControl.Location = new Point(14, 16);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(887, 568);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // tabsale
            // 
            tabsale.Controls.Add(info);
            tabsale.Controls.Add(button6);
            tabsale.Controls.Add(button3);
            tabsale.Controls.Add(dgvSale);
            tabsale.Location = new Point(4, 29);
            tabsale.Margin = new Padding(3, 4, 3, 4);
            tabsale.Name = "tabsale";
            tabsale.Padding = new Padding(3, 4, 3, 4);
            tabsale.Size = new Size(879, 535);
            tabsale.TabIndex = 0;
            tabsale.Text = "Sale kinowe";
            tabsale.UseVisualStyleBackColor = true;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Location = new Point(10, 504);
            info.Name = "info";
            info.Size = new Size(0, 20);
            info.TabIndex = 4;
            // 
            // button6
            // 
            button6.Location = new Point(693, 500);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(86, 31);
            button6.TabIndex = 3;
            button6.Text = "dodaj sale";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button3
            // 
            button3.Location = new Point(785, 500);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 2;
            button3.Text = "Usuń sale";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dgvSale
            // 
            dgvSale.AllowUserToAddRows = false;
            dgvSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSale.Location = new Point(7, 8);
            dgvSale.Margin = new Padding(3, 4, 3, 4);
            dgvSale.Name = "dgvSale";
            dgvSale.RowHeadersWidth = 51;
            dgvSale.RowTemplate.Height = 25;
            dgvSale.Size = new Size(864, 488);
            dgvSale.TabIndex = 1;
            dgvSale.CellDoubleClick += addSala;
            // 
            // tabfilmy
            // 
            tabfilmy.Controls.Add(button5);
            tabfilmy.Controls.Add(button2);
            tabfilmy.Controls.Add(dgvFilm);
            tabfilmy.Location = new Point(4, 29);
            tabfilmy.Margin = new Padding(3, 4, 3, 4);
            tabfilmy.Name = "tabfilmy";
            tabfilmy.Padding = new Padding(3, 4, 3, 4);
            tabfilmy.Size = new Size(879, 535);
            tabfilmy.TabIndex = 1;
            tabfilmy.Text = "Filmy";
            tabfilmy.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(693, 496);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(86, 31);
            button5.TabIndex = 2;
            button5.Text = "dodaj film";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.Location = new Point(785, 496);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 1;
            button2.Text = "usuń film";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dgvFilm
            // 
            dgvFilm.AllowUserToAddRows = false;
            dgvFilm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFilm.Location = new Point(7, 8);
            dgvFilm.Margin = new Padding(3, 4, 3, 4);
            dgvFilm.Name = "dgvFilm";
            dgvFilm.RowHeadersWidth = 51;
            dgvFilm.RowTemplate.Height = 25;
            dgvFilm.Size = new Size(864, 488);
            dgvFilm.TabIndex = 0;
            dgvFilm.CellDoubleClick += addFilm;
            // 
            // tabOper
            // 
            tabOper.Controls.Add(button4);
            tabOper.Controls.Add(button1);
            tabOper.Controls.Add(dgvOper);
            tabOper.Location = new Point(4, 29);
            tabOper.Margin = new Padding(3, 4, 3, 4);
            tabOper.Name = "tabOper";
            tabOper.Padding = new Padding(3, 4, 3, 4);
            tabOper.Size = new Size(879, 535);
            tabOper.TabIndex = 2;
            tabOper.Text = "Użytkownicy";
            tabOper.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(598, 496);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(142, 31);
            button4.TabIndex = 2;
            button4.Text = "dodaj użytkownika";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(746, 496);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(125, 31);
            button1.TabIndex = 1;
            button1.Text = "usuń operatora";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvOper
            // 
            dgvOper.AllowUserToAddRows = false;
            dgvOper.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOper.Location = new Point(3, 4);
            dgvOper.Margin = new Padding(3, 4, 3, 4);
            dgvOper.Name = "dgvOper";
            dgvOper.RowHeadersWidth = 51;
            dgvOper.RowTemplate.Height = 25;
            dgvOper.Size = new Size(867, 485);
            dgvOper.TabIndex = 0;
            dgvOper.CellDoubleClick += addOper;
            // 
            // tabKat
            // 
            tabKat.Controls.Add(label1);
            tabKat.Controls.Add(button8);
            tabKat.Controls.Add(button7);
            tabKat.Controls.Add(dgvKategorie);
            tabKat.Location = new Point(4, 29);
            tabKat.Margin = new Padding(3, 4, 3, 4);
            tabKat.Name = "tabKat";
            tabKat.Padding = new Padding(3, 4, 3, 4);
            tabKat.Size = new Size(879, 535);
            tabKat.TabIndex = 3;
            tabKat.Text = "Kategorie";
            tabKat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 497);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 3;
            // 
            // button8
            // 
            button8.Location = new Point(625, 492);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(112, 31);
            button8.TabIndex = 2;
            button8.Text = "dodaj kategorię";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(744, 492);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(127, 31);
            button7.TabIndex = 1;
            button7.Text = "usuń kategorię";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // dgvKategorie
            // 
            dgvKategorie.AllowUserToAddRows = false;
            dgvKategorie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKategorie.Location = new Point(7, 8);
            dgvKategorie.Margin = new Padding(3, 4, 3, 4);
            dgvKategorie.Name = "dgvKategorie";
            dgvKategorie.RowHeadersWidth = 51;
            dgvKategorie.RowTemplate.Height = 25;
            dgvKategorie.Size = new Size(864, 476);
            dgvKategorie.TabIndex = 0;
            dgvKategorie.CellDoubleClick += addKat;
            // 
            // tabAktorzy
            // 
            tabAktorzy.Controls.Add(label2);
            tabAktorzy.Controls.Add(btn_dodajAktora);
            tabAktorzy.Controls.Add(btn_usunAktora);
            tabAktorzy.Controls.Add(dgvAktorzy);
            tabAktorzy.Location = new Point(4, 29);
            tabAktorzy.Margin = new Padding(3, 4, 3, 4);
            tabAktorzy.Name = "tabAktorzy";
            tabAktorzy.Padding = new Padding(3, 4, 3, 4);
            tabAktorzy.Size = new Size(879, 535);
            tabAktorzy.TabIndex = 4;
            tabAktorzy.Text = "Aktorzy";
            tabAktorzy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 497);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 6;
            // 
            // btn_dodajAktora
            // 
            btn_dodajAktora.Location = new Point(625, 492);
            btn_dodajAktora.Margin = new Padding(3, 4, 3, 4);
            btn_dodajAktora.Name = "btn_dodajAktora";
            btn_dodajAktora.Size = new Size(112, 31);
            btn_dodajAktora.TabIndex = 5;
            btn_dodajAktora.Text = "dodaj aktora";
            btn_dodajAktora.UseVisualStyleBackColor = true;
            btn_dodajAktora.Click += btn_dodajAktora_Click;
            // 
            // btn_usunAktora
            // 
            btn_usunAktora.Location = new Point(744, 492);
            btn_usunAktora.Margin = new Padding(3, 4, 3, 4);
            btn_usunAktora.Name = "btn_usunAktora";
            btn_usunAktora.Size = new Size(127, 31);
            btn_usunAktora.TabIndex = 4;
            btn_usunAktora.Text = "usuń aktora";
            btn_usunAktora.UseVisualStyleBackColor = true;
            btn_usunAktora.Click += btn_usunAktora_Click;
            // 
            // dgvAktorzy
            // 
            dgvAktorzy.AllowUserToAddRows = false;
            dgvAktorzy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAktorzy.Location = new Point(7, 8);
            dgvAktorzy.Margin = new Padding(3, 4, 3, 4);
            dgvAktorzy.Name = "dgvAktorzy";
            dgvAktorzy.RowHeadersWidth = 51;
            dgvAktorzy.RowTemplate.Height = 25;
            dgvAktorzy.Size = new Size(864, 476);
            dgvAktorzy.TabIndex = 3;
            dgvAktorzy.CellDoubleClick += addAkt;
            // 
            // OknoKonfiguracji
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(tabControl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "OknoKonfiguracji";
            Text = "OknoKonfiguracji";
            Load += OknoKonfiguracji_Load;
            tabControl.ResumeLayout(false);
            tabsale.ResumeLayout(false);
            tabsale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSale).EndInit();
            tabfilmy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFilm).EndInit();
            tabOper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOper).EndInit();
            tabKat.ResumeLayout(false);
            tabKat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKategorie).EndInit();
            tabAktorzy.ResumeLayout(false);
            tabAktorzy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAktorzy).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private TabControl tabControl;
        private TabPage tabsale;
        private TabPage tabfilmy;
        private TabPage tabOper;
        private DataGridView dgvOper;
        private Button button1;
        private DataGridView dgvFilm;
        private DataGridView dgvSale;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private TabPage tabKat;
        private Button button8;
        private Button button7;
        private DataGridView dgvKategorie;
        private Label label1;
        private TabPage tabAktorzy;
        private Button btn_dodajAktora;
        private Button btn_usunAktora;
        private DataGridView dgvAktorzy;
        private Label label2;
        private Label info;
    }
}