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
            SuspendLayout();
            // 
            // label_pods_tytul
            // 
            label_pods_tytul.AutoSize = true;
            label_pods_tytul.Location = new Point(305, 19);
            label_pods_tytul.Name = "label_pods_tytul";
            label_pods_tytul.Size = new Size(50, 20);
            label_pods_tytul.TabIndex = 0;
            label_pods_tytul.Text = "label1";
            // 
            // label_pods_dzien
            // 
            label_pods_dzien.AutoSize = true;
            label_pods_dzien.Location = new Point(305, 84);
            label_pods_dzien.Name = "label_pods_dzien";
            label_pods_dzien.Size = new Size(50, 20);
            label_pods_dzien.TabIndex = 1;
            label_pods_dzien.Text = "label1";
            // 
            // label_pods_godzina
            // 
            label_pods_godzina.AutoSize = true;
            label_pods_godzina.Location = new Point(305, 151);
            label_pods_godzina.Name = "label_pods_godzina";
            label_pods_godzina.Size = new Size(50, 20);
            label_pods_godzina.TabIndex = 2;
            label_pods_godzina.Text = "label1";
            // 
            // label_pods_sala
            // 
            label_pods_sala.AutoSize = true;
            label_pods_sala.Location = new Point(305, 210);
            label_pods_sala.Name = "label_pods_sala";
            label_pods_sala.Size = new Size(50, 20);
            label_pods_sala.TabIndex = 3;
            label_pods_sala.Text = "label1";
            // 
            // label_pods_miejsca
            // 
            label_pods_miejsca.AutoSize = true;
            label_pods_miejsca.Location = new Point(305, 270);
            label_pods_miejsca.Name = "label_pods_miejsca";
            label_pods_miejsca.Size = new Size(50, 20);
            label_pods_miejsca.TabIndex = 4;
            label_pods_miejsca.Text = "label1";
            // 
            // podsumowanie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 729);
            Controls.Add(label_pods_miejsca);
            Controls.Add(label_pods_sala);
            Controls.Add(label_pods_godzina);
            Controls.Add(label_pods_dzien);
            Controls.Add(label_pods_tytul);
            MaximumSize = new Size(1104, 776);
            MinimumSize = new Size(1104, 776);
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
    }
}