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
            label1.Location = new Point(26, 16);
            label1.Name = "label1";
            label1.Size = new Size(216, 15);
            label1.TabIndex = 0;
            label1.Text = "id + tytul + data emisji + godzina emisji";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ScrollBar;
            panel1.Controls.Add(label_ekran);
            panel1.Location = new Point(291, 51);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(727, 22);
            panel1.TabIndex = 1;
            // 
            // label_ekran
            // 
            label_ekran.Anchor = AnchorStyles.Bottom;
            label_ekran.AutoSize = true;
            label_ekran.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_ekran.Location = new Point(334, 1);
            label_ekran.Name = "label_ekran";
            label_ekran.Size = new Size(53, 21);
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
            button_final.Location = new Point(1156, 646);
            button_final.Margin = new Padding(3, 2, 3, 2);
            button_final.Name = "button_final";
            button_final.Size = new Size(130, 59);
            button_final.TabIndex = 2;
            button_final.Text = "Zakup";
            button_final.UseVisualStyleBackColor = true;
            button_final.Click += button_final_Click;
            // 
            // sala_kinowa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 1061);
            Controls.Add(button_final);
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(1400, 1100);
            MinimumSize = new Size(1400, 1030);
            Name = "sala_kinowa";
            Text = "Sala kinowa";
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