namespace Projekt_kino
{
    partial class sala_kinowa
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
            label1 = new Label();
            panel1 = new Panel();
            label_ekran = new Label();
            a1 = new DataGridViewTextBoxColumn();
            button_final = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 21);
            label1.Name = "label1";
            label1.Size = new Size(275, 20);
            label1.TabIndex = 0;
            label1.Text = "id + tytul + data emisji + godzina emisji";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ScrollBar;
            panel1.Controls.Add(label_ekran);
            panel1.Location = new Point(333, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(831, 29);
            panel1.TabIndex = 1;
            // 
            // label_ekran
            // 
            label_ekran.Anchor = AnchorStyles.Bottom;
            label_ekran.AutoSize = true;
            label_ekran.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_ekran.Location = new Point(382, 1);
            label_ekran.Name = "label_ekran";
            label_ekran.Size = new Size(65, 28);
            label_ekran.TabIndex = 0;
            label_ekran.Text = "Ekran";
            label_ekran.Click += label_ekran_Click_1;
            // 
            // a1
            // 
            a1.HeaderText = "LP";
            a1.MinimumWidth = 6;
            a1.Name = "a1";
            a1.Width = 125;
            // 
            // button_final
            // 
            button_final.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_final.Location = new Point(1321, 862);
            button_final.Name = "button_final";
            button_final.Size = new Size(149, 79);
            button_final.TabIndex = 2;
            button_final.Text = "Zakup";
            button_final.UseVisualStyleBackColor = true;
            button_final.Click += button_final_Click;
            // 
            // sala_kinowa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1482, 953);
            Controls.Add(button_final);
            Controls.Add(panel1);
            Controls.Add(label1);
            MaximumSize = new Size(1500, 1000);
            MinimumSize = new Size(1500, 1000);
            Name = "sala_kinowa";
            Text = "sala_kinowa";
            Load += sala_kinowa_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label_ekran;
        private DataGridViewTextBoxColumn a1;
        private Button button_final;
    }
}