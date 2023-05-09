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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 22);
            label1.Name = "label1";
            label1.Size = new Size(275, 20);
            label1.TabIndex = 0;
            label1.Text = "id + tytul + data emisji + godzina emisji";
            // 
            // sala_kinowa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 853);
            Controls.Add(label1);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(1300, 900);
            Name = "sala_kinowa";
            Text = "sala_kinowa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}