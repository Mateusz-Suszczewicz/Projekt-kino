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
            info = new Label();
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
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 426);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // tabsale
            // 
            tabsale.Controls.Add(info);
            tabsale.Controls.Add(button6);
            tabsale.Controls.Add(button3);
            tabsale.Controls.Add(dgvSale);
            tabsale.Location = new Point(4, 24);
            tabsale.Name = "tabsale";
            tabsale.Padding = new Padding(3);
            tabsale.Size = new Size(768, 398);
            tabsale.TabIndex = 0;
            tabsale.Text = "Sale kinowe";
            tabsale.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(606, 375);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 3;
            button6.Text = "dodaj sale";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button3
            // 
            button3.Location = new Point(687, 375);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Usuń sale";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dgvSale
            // 
            dgvSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSale.Location = new Point(6, 6);
            dgvSale.Name = "dgvSale";
            dgvSale.RowTemplate.Height = 25;
            dgvSale.Size = new Size(756, 366);
            dgvSale.TabIndex = 1;
            dgvSale.CellDoubleClick += addSala;
            // 
            // tabfilmy
            // 
            tabfilmy.Controls.Add(button5);
            tabfilmy.Controls.Add(button2);
            tabfilmy.Controls.Add(dgvFilm);
            tabfilmy.Location = new Point(4, 24);
            tabfilmy.Name = "tabfilmy";
            tabfilmy.Padding = new Padding(3);
            tabfilmy.Size = new Size(768, 398);
            tabfilmy.TabIndex = 1;
            tabfilmy.Text = "Filmy";
            tabfilmy.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(606, 372);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 2;
            button5.Text = "dodaj film";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.Location = new Point(687, 372);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "usuń film";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dgvFilm
            // 
            dgvFilm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFilm.Location = new Point(6, 6);
            dgvFilm.Name = "dgvFilm";
            dgvFilm.RowTemplate.Height = 25;
            dgvFilm.Size = new Size(756, 366);
            dgvFilm.TabIndex = 0;
            dgvFilm.CellDoubleClick += addFilm;
            // 
            // tabOper
            // 
            tabOper.Controls.Add(button4);
            tabOper.Controls.Add(button1);
            tabOper.Controls.Add(dgvOper);
            tabOper.Location = new Point(4, 24);
            tabOper.Name = "tabOper";
            tabOper.Padding = new Padding(3);
            tabOper.Size = new Size(768, 398);
            tabOper.TabIndex = 2;
            tabOper.Text = "Użytkownicy";
            tabOper.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(523, 372);
            button4.Name = "button4";
            button4.Size = new Size(124, 23);
            button4.TabIndex = 2;
            button4.Text = "dodaj użytkownika";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(653, 372);
            button1.Name = "button1";
            button1.Size = new Size(109, 23);
            button1.TabIndex = 1;
            button1.Text = "usuń operatora";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvOper
            // 
            dgvOper.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOper.Location = new Point(3, 3);
            dgvOper.Name = "dgvOper";
            dgvOper.RowTemplate.Height = 25;
            dgvOper.Size = new Size(759, 364);
            dgvOper.TabIndex = 0;
            dgvOper.CellDoubleClick += addOper;
            // 
            // tabKat
            // 
            tabKat.Controls.Add(label1);
            tabKat.Controls.Add(button8);
            tabKat.Controls.Add(button7);
            tabKat.Controls.Add(dgvKategorie);
            tabKat.Location = new Point(4, 24);
            tabKat.Name = "tabKat";
            tabKat.Padding = new Padding(3);
            tabKat.Size = new Size(768, 398);
            tabKat.TabIndex = 3;
            tabKat.Text = "Kategorie";
            tabKat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 373);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // button8
            // 
            button8.Location = new Point(547, 369);
            button8.Name = "button8";
            button8.Size = new Size(98, 23);
            button8.TabIndex = 2;
            button8.Text = "dodaj kategorię";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(651, 369);
            button7.Name = "button7";
            button7.Size = new Size(111, 23);
            button7.TabIndex = 1;
            button7.Text = "usuń kategorię";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // dgvKategorie
            // 
            dgvKategorie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKategorie.Location = new Point(6, 6);
            dgvKategorie.Name = "dgvKategorie";
            dgvKategorie.RowTemplate.Height = 25;
            dgvKategorie.Size = new Size(756, 357);
            dgvKategorie.TabIndex = 0;
            dgvKategorie.CellDoubleClick += addKat;
            // 
            // tabAktorzy
            // 
            tabAktorzy.Controls.Add(label2);
            tabAktorzy.Controls.Add(btn_dodajAktora);
            tabAktorzy.Controls.Add(btn_usunAktora);
            tabAktorzy.Controls.Add(dgvAktorzy);
            tabAktorzy.Location = new Point(4, 24);
            tabAktorzy.Name = "tabAktorzy";
            tabAktorzy.Padding = new Padding(3);
            tabAktorzy.Size = new Size(768, 398);
            tabAktorzy.TabIndex = 4;
            tabAktorzy.Text = "Aktorzy";
            tabAktorzy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 373);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 6;
            // 
            // btn_dodajAktora
            // 
            btn_dodajAktora.Location = new Point(547, 369);
            btn_dodajAktora.Name = "btn_dodajAktora";
            btn_dodajAktora.Size = new Size(98, 23);
            btn_dodajAktora.TabIndex = 5;
            btn_dodajAktora.Text = "dodaj aktora";
            btn_dodajAktora.UseVisualStyleBackColor = true;
            btn_dodajAktora.Click += btn_dodajAktora_Click;
            // 
            // btn_usunAktora
            // 
            btn_usunAktora.Location = new Point(651, 369);
            btn_usunAktora.Name = "btn_usunAktora";
            btn_usunAktora.Size = new Size(111, 23);
            btn_usunAktora.TabIndex = 4;
            btn_usunAktora.Text = "usuń aktora";
            btn_usunAktora.UseVisualStyleBackColor = true;
            btn_usunAktora.Click += btn_usunAktora_Click;
            // 
            // dgvAktorzy
            // 
            dgvAktorzy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAktorzy.Location = new Point(6, 6);
            dgvAktorzy.Name = "dgvAktorzy";
            dgvAktorzy.RowTemplate.Height = 25;
            dgvAktorzy.Size = new Size(756, 357);
            dgvAktorzy.TabIndex = 3;
            dgvAktorzy.CellDoubleClick += addAkt;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Location = new Point(9, 378);
            info.Name = "info";
            info.Size = new Size(0, 15);
            info.TabIndex = 4;
            // 
            // OknoKonfiguracji
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Name = "OknoKonfiguracji";
            Text = "OknoKonfiguracji";
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