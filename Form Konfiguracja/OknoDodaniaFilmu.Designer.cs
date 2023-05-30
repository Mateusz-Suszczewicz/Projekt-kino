namespace Projekt_kino.Form_Konfiguracja
{
    partial class OknoDodaniaFilmu
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
            tyul = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tb_name = new TextBox();
            tb_duration = new TextBox();
            tb_language = new TextBox();
            tb_translate = new TextBox();
            tb_production = new TextBox();
            rtb_opis = new RichTextBox();
            btn_zamknij = new Button();
            btn_zapiszFilm = new Button();
            tabControl1 = new TabControl();
            tabPage_kategorie = new TabPage();
            dgv_kategoria = new DataGridView();
            btn_edytujKategorie = new Button();
            tabPage_zdjecia = new TabPage();
            dgv_zdjecia = new DataGridView();
            btn_usunZdjecia = new Button();
            btn_dodajZdjecia = new Button();
            tabPage_seanse = new TabPage();
            dgv_seanse = new DataGridView();
            btn_usunSeans = new Button();
            btn_dodajSeans = new Button();
            tp_aktorzy = new TabPage();
            dgv_aktorzy = new DataGridView();
            btn_usunAktora = new Button();
            btn_dodajAktora = new Button();
            tabControl1.SuspendLayout();
            tabPage_kategorie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_kategoria).BeginInit();
            tabPage_zdjecia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_zdjecia).BeginInit();
            tabPage_seanse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_seanse).BeginInit();
            tp_aktorzy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_aktorzy).BeginInit();
            SuspendLayout();
            // 
            // tyul
            // 
            tyul.AutoSize = true;
            tyul.Location = new Point(11, 19);
            tyul.Name = "tyul";
            tyul.Size = new Size(32, 15);
            tyul.TabIndex = 0;
            tyul.Text = "Tytuł";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(449, 22);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Opis";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 61);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Długość";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 100);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 3;
            label3.Text = "jezyk";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(232, 22);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 4;
            label4.Text = "tłumaczenie";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(232, 56);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 5;
            label5.Text = "produkcja";
            // 
            // tb_name
            // 
            tb_name.Location = new Point(70, 17);
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(100, 23);
            tb_name.TabIndex = 6;
            // 
            // tb_duration
            // 
            tb_duration.Location = new Point(70, 58);
            tb_duration.Name = "tb_duration";
            tb_duration.Size = new Size(100, 23);
            tb_duration.TabIndex = 7;
            // 
            // tb_language
            // 
            tb_language.Location = new Point(70, 100);
            tb_language.Name = "tb_language";
            tb_language.Size = new Size(100, 23);
            tb_language.TabIndex = 8;
            // 
            // tb_translate
            // 
            tb_translate.Location = new Point(309, 22);
            tb_translate.Name = "tb_translate";
            tb_translate.Size = new Size(100, 23);
            tb_translate.TabIndex = 9;
            // 
            // tb_production
            // 
            tb_production.Location = new Point(309, 56);
            tb_production.Name = "tb_production";
            tb_production.Size = new Size(100, 23);
            tb_production.TabIndex = 10;
            // 
            // rtb_opis
            // 
            rtb_opis.Location = new Point(486, 19);
            rtb_opis.Name = "rtb_opis";
            rtb_opis.Size = new Size(290, 115);
            rtb_opis.TabIndex = 11;
            rtb_opis.Text = "";
            // 
            // btn_zamknij
            // 
            btn_zamknij.Location = new Point(713, 425);
            btn_zamknij.Name = "btn_zamknij";
            btn_zamknij.Size = new Size(75, 23);
            btn_zamknij.TabIndex = 12;
            btn_zamknij.Text = "Zamknij";
            btn_zamknij.UseVisualStyleBackColor = true;
            btn_zamknij.Click += btn_zamknij_Click;
            // 
            // btn_zapiszFilm
            // 
            btn_zapiszFilm.Location = new Point(624, 425);
            btn_zapiszFilm.Name = "btn_zapiszFilm";
            btn_zapiszFilm.Size = new Size(83, 23);
            btn_zapiszFilm.TabIndex = 13;
            btn_zapiszFilm.Text = "Zapisz film";
            btn_zapiszFilm.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage_kategorie);
            tabControl1.Controls.Add(tabPage_zdjecia);
            tabControl1.Controls.Add(tabPage_seanse);
            tabControl1.Controls.Add(tp_aktorzy);
            tabControl1.Location = new Point(6, 140);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(782, 279);
            tabControl1.TabIndex = 14;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // tabPage_kategorie
            // 
            tabPage_kategorie.Controls.Add(dgv_kategoria);
            tabPage_kategorie.Controls.Add(btn_edytujKategorie);
            tabPage_kategorie.Location = new Point(4, 24);
            tabPage_kategorie.Name = "tabPage_kategorie";
            tabPage_kategorie.Padding = new Padding(3);
            tabPage_kategorie.Size = new Size(774, 251);
            tabPage_kategorie.TabIndex = 0;
            tabPage_kategorie.Text = "Kategorie";
            tabPage_kategorie.UseVisualStyleBackColor = true;
            // 
            // dgv_kategoria
            // 
            dgv_kategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_kategoria.Location = new Point(6, 3);
            dgv_kategoria.Name = "dgv_kategoria";
            dgv_kategoria.RowTemplate.Height = 25;
            dgv_kategoria.Size = new Size(684, 242);
            dgv_kategoria.TabIndex = 2;
            dgv_kategoria.CellClick += editKat;
            // 
            // btn_edytujKategorie
            // 
            btn_edytujKategorie.Location = new Point(696, 6);
            btn_edytujKategorie.Name = "btn_edytujKategorie";
            btn_edytujKategorie.Size = new Size(75, 23);
            btn_edytujKategorie.TabIndex = 0;
            btn_edytujKategorie.Text = "Dodaj";
            btn_edytujKategorie.UseVisualStyleBackColor = true;
            btn_edytujKategorie.Click += editKat;
            // 
            // tabPage_zdjecia
            // 
            tabPage_zdjecia.Controls.Add(dgv_zdjecia);
            tabPage_zdjecia.Controls.Add(btn_usunZdjecia);
            tabPage_zdjecia.Controls.Add(btn_dodajZdjecia);
            tabPage_zdjecia.Location = new Point(4, 24);
            tabPage_zdjecia.Name = "tabPage_zdjecia";
            tabPage_zdjecia.Padding = new Padding(3);
            tabPage_zdjecia.Size = new Size(774, 251);
            tabPage_zdjecia.TabIndex = 1;
            tabPage_zdjecia.Text = "Zdjęcia";
            tabPage_zdjecia.UseVisualStyleBackColor = true;
            // 
            // dgv_zdjecia
            // 
            dgv_zdjecia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_zdjecia.Location = new Point(5, 4);
            dgv_zdjecia.Name = "dgv_zdjecia";
            dgv_zdjecia.RowTemplate.Height = 25;
            dgv_zdjecia.Size = new Size(684, 242);
            dgv_zdjecia.TabIndex = 5;
            dgv_zdjecia.CellDoubleClick += edytujZdjecie;
            // 
            // btn_usunZdjecia
            // 
            btn_usunZdjecia.Location = new Point(695, 36);
            btn_usunZdjecia.Name = "btn_usunZdjecia";
            btn_usunZdjecia.Size = new Size(75, 23);
            btn_usunZdjecia.TabIndex = 4;
            btn_usunZdjecia.Text = "Usuń";
            btn_usunZdjecia.UseVisualStyleBackColor = true;
            btn_usunZdjecia.Click += btn_usunZdjecia_Click;
            // 
            // btn_dodajZdjecia
            // 
            btn_dodajZdjecia.Location = new Point(695, 7);
            btn_dodajZdjecia.Name = "btn_dodajZdjecia";
            btn_dodajZdjecia.Size = new Size(75, 23);
            btn_dodajZdjecia.TabIndex = 3;
            btn_dodajZdjecia.Text = "Dodaj";
            btn_dodajZdjecia.UseVisualStyleBackColor = true;
            btn_dodajZdjecia.Click += btn_dodajZdjecia_Click;
            // 
            // tabPage_seanse
            // 
            tabPage_seanse.Controls.Add(dgv_seanse);
            tabPage_seanse.Controls.Add(btn_usunSeans);
            tabPage_seanse.Controls.Add(btn_dodajSeans);
            tabPage_seanse.Location = new Point(4, 24);
            tabPage_seanse.Name = "tabPage_seanse";
            tabPage_seanse.Padding = new Padding(3);
            tabPage_seanse.Size = new Size(774, 251);
            tabPage_seanse.TabIndex = 2;
            tabPage_seanse.Text = "Seanse";
            tabPage_seanse.UseVisualStyleBackColor = true;
            // 
            // dgv_seanse
            // 
            dgv_seanse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_seanse.Location = new Point(5, 4);
            dgv_seanse.Name = "dgv_seanse";
            dgv_seanse.RowTemplate.Height = 25;
            dgv_seanse.Size = new Size(684, 242);
            dgv_seanse.TabIndex = 5;
            dgv_seanse.CellDoubleClick += edytujSeans;
            // 
            // btn_usunSeans
            // 
            btn_usunSeans.Location = new Point(695, 36);
            btn_usunSeans.Name = "btn_usunSeans";
            btn_usunSeans.Size = new Size(75, 23);
            btn_usunSeans.TabIndex = 4;
            btn_usunSeans.Text = "Usuń";
            btn_usunSeans.UseVisualStyleBackColor = true;
            btn_usunSeans.Click += btn_usunSeans_Click;
            // 
            // btn_dodajSeans
            // 
            btn_dodajSeans.Location = new Point(695, 7);
            btn_dodajSeans.Name = "btn_dodajSeans";
            btn_dodajSeans.Size = new Size(75, 23);
            btn_dodajSeans.TabIndex = 3;
            btn_dodajSeans.Text = "Dodaj";
            btn_dodajSeans.UseVisualStyleBackColor = true;
            btn_dodajSeans.Click += btn_dodajSeans_Click;
            // 
            // tp_aktorzy
            // 
            tp_aktorzy.Controls.Add(dgv_aktorzy);
            tp_aktorzy.Controls.Add(btn_usunAktora);
            tp_aktorzy.Controls.Add(btn_dodajAktora);
            tp_aktorzy.Location = new Point(4, 24);
            tp_aktorzy.Name = "tp_aktorzy";
            tp_aktorzy.Padding = new Padding(3);
            tp_aktorzy.Size = new Size(774, 251);
            tp_aktorzy.TabIndex = 3;
            tp_aktorzy.Text = "Aktorzy";
            tp_aktorzy.UseVisualStyleBackColor = true;
            // 
            // dgv_aktorzy
            // 
            dgv_aktorzy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_aktorzy.Location = new Point(5, 4);
            dgv_aktorzy.Name = "dgv_aktorzy";
            dgv_aktorzy.RowTemplate.Height = 25;
            dgv_aktorzy.Size = new Size(684, 242);
            dgv_aktorzy.TabIndex = 8;
            // 
            // btn_usunAktora
            // 
            btn_usunAktora.Location = new Point(695, 36);
            btn_usunAktora.Name = "btn_usunAktora";
            btn_usunAktora.Size = new Size(75, 23);
            btn_usunAktora.TabIndex = 7;
            btn_usunAktora.Text = "Usuń";
            btn_usunAktora.UseVisualStyleBackColor = true;
            // 
            // btn_dodajAktora
            // 
            btn_dodajAktora.Location = new Point(695, 7);
            btn_dodajAktora.Name = "btn_dodajAktora";
            btn_dodajAktora.Size = new Size(75, 23);
            btn_dodajAktora.TabIndex = 6;
            btn_dodajAktora.Text = "Dodaj";
            btn_dodajAktora.UseVisualStyleBackColor = true;
            // 
            // OknoDodaniaFilmu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(btn_zapiszFilm);
            Controls.Add(btn_zamknij);
            Controls.Add(rtb_opis);
            Controls.Add(tb_production);
            Controls.Add(tb_translate);
            Controls.Add(tb_language);
            Controls.Add(tb_duration);
            Controls.Add(tb_name);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tyul);
            Name = "OknoDodaniaFilmu";
            Text = "OknoDodaniaFilmu";
            tabControl1.ResumeLayout(false);
            tabPage_kategorie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_kategoria).EndInit();
            tabPage_zdjecia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_zdjecia).EndInit();
            tabPage_seanse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_seanse).EndInit();
            tp_aktorzy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_aktorzy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tyul;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox tb_name;
        private TextBox tb_duration;
        private TextBox tb_language;
        private TextBox tb_translate;
        private TextBox tb_production;
        private RichTextBox rtb_opis;
        private Button btn_zamknij;
        private Button btn_zapiszFilm;
        private TabControl tabControl1;
        private TabPage tabPage_kategorie;
        private DataGridView dgv_kategoria;
        private Button btn_usunKategorie;
        private Button btn_edytujKategorie;
        private TabPage tabPage_zdjecia;
        private TabPage tabPage_seanse;
        private DataGridView dgv_zdjecia;
        private Button btn_usunZdjecia;
        private Button btn_dodajZdjecia;
        private DataGridView dgv_seanse;
        private Button btn_usunSeans;
        private Button btn_dodajSeans;
        private TabPage tp_aktorzy;
        private DataGridView dgv_aktorzy;
        private Button btn_usunAktora;
        private Button btn_dodajAktora;
    }
}