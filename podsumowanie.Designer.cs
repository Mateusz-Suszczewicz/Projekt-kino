using System.Windows.Forms;

namespace Projekt_kino
{
    partial class podsumowanie
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
            label_pods_tytul = new Label();
            label_pods_dzien = new Label();
            label_pods_godzina = new Label();
            label_pods_sala = new Label();
            label_pods_miejsca = new Label();
            button_zatwierdz = new Button();
            label_koszyk = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // label_pods_tytul
            // 
            label_pods_tytul.AutoSize = true;
            label_pods_tytul.Location = new Point(267, 14);
            label_pods_tytul.Name = "label_pods_tytul";
            label_pods_tytul.Size = new Size(38, 15);
            label_pods_tytul.TabIndex = 0;
            label_pods_tytul.Text = "label1";
            // 
            // label_pods_dzien
            // 
            label_pods_dzien.AutoSize = true;
            label_pods_dzien.Location = new Point(267, 63);
            label_pods_dzien.Name = "label_pods_dzien";
            label_pods_dzien.Size = new Size(38, 15);
            label_pods_dzien.TabIndex = 1;
            label_pods_dzien.Text = "label1";
            // 
            // label_pods_godzina
            // 
            label_pods_godzina.AutoSize = true;
            label_pods_godzina.Location = new Point(267, 113);
            label_pods_godzina.Name = "label_pods_godzina";
            label_pods_godzina.Size = new Size(38, 15);
            label_pods_godzina.TabIndex = 2;
            label_pods_godzina.Text = "label1";
            // 
            // label_pods_sala
            // 
            label_pods_sala.AutoSize = true;
            label_pods_sala.Location = new Point(267, 158);
            label_pods_sala.Name = "label_pods_sala";
            label_pods_sala.Size = new Size(27, 15);
            label_pods_sala.TabIndex = 3;
            label_pods_sala.Text = "sala";
            // 
            // label_pods_miejsca
            // 
            label_pods_miejsca.AutoSize = true;
            label_pods_miejsca.Location = new Point(267, 202);
            label_pods_miejsca.Name = "label_pods_miejsca";
            label_pods_miejsca.Size = new Size(38, 15);
            label_pods_miejsca.TabIndex = 4;
            label_pods_miejsca.Text = "label1";
            // 
            // button_zatwierdz
            // 
            button_zatwierdz.Location = new Point(925, 638);
            button_zatwierdz.Name = "button_zatwierdz";
            button_zatwierdz.Size = new Size(149, 79);
            button_zatwierdz.TabIndex = 5;
            button_zatwierdz.Text = "Zatwierdź";
            button_zatwierdz.UseVisualStyleBackColor = true;
            button_zatwierdz.Click += button_zatwierdz_Click;
            // 
            // label_koszyk
            // 
            label_koszyk.AutoSize = true;
            label_koszyk.Location = new Point(836, 9);
            label_koszyk.Name = "label_koszyk";
            label_koszyk.Size = new Size(38, 15);
            label_koszyk.TabIndex = 6;
            label_koszyk.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(836, 504);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Potwierdź";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(731, 504);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Zamknij";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(724, 395);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(847, 450);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "test";
            button3.UseVisualStyleBackColor = true;
            // 
            // podsumowanie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 553);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label_koszyk);
            Controls.Add(button_zatwierdz);
            Controls.Add(label_pods_miejsca);
            Controls.Add(label_pods_sala);
            Controls.Add(label_pods_godzina);
            Controls.Add(label_pods_dzien);
            Controls.Add(label_pods_tytul);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(968, 592);
            MinimumSize = new Size(968, 592);
            Name = "podsumowanie";
            Text = "Podsumowanie";
            Load += podsumowanie_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_pods_tytul;
        private Label label_pods_dzien;
        private Label label_pods_godzina;
        private Label label_pods_sala;
        private Label label_pods_miejsca;
        private Button button_zatwierdz;
        private Label label_koszyk;
        private Button button1;
        private Button button2;
        private Label label1;
        private Button button3;
    }
}