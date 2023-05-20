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
            label_pods_sala.Size = new Size(38, 15);
            label_pods_sala.TabIndex = 3;
            label_pods_sala.Text = "label1";
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
            label_koszyk.Size = new Size(50, 20);
            label_koszyk.TabIndex = 6;
            label_koszyk.Text = "label1";
            // 
            // podsumowanie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 729);
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
            Text = "podsumowanie";
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
    }
}