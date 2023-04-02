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
            button1 = new Button();
            textBox1 = new TextBox();
            przycisk_konto = new Button();
            aktualny_czas = new Label();
            bilet_ulgowy = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(755, 93);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(145, 45);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 323);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(886, 27);
            textBox1.TabIndex = 1;
            // 
            // przycisk_konto
            // 
            przycisk_konto.Location = new Point(755, 41);
            przycisk_konto.Name = "przycisk_konto";
            przycisk_konto.Size = new Size(147, 45);
            przycisk_konto.TabIndex = 3;
            przycisk_konto.Text = "Konto";
            przycisk_konto.UseVisualStyleBackColor = true;
            przycisk_konto.Click += przycisk_konto_Click;
            // 
            // aktualny_czas
            // 
            aktualny_czas.AutoSize = true;
            aktualny_czas.Location = new Point(756, 12);
            aktualny_czas.Name = "aktualny_czas";
            aktualny_czas.Size = new Size(50, 20);
            aktualny_czas.TabIndex = 4;
            aktualny_czas.Text = "label1";
            aktualny_czas.Click += label1_Click;
            // 
            // bilet_ulgowy
            // 
            bilet_ulgowy.AutoSize = true;
            bilet_ulgowy.Location = new Point(790, 157);
            bilet_ulgowy.Name = "bilet_ulgowy";
            bilet_ulgowy.Size = new Size(79, 24);
            bilet_ulgowy.TabIndex = 5;
            bilet_ulgowy.Text = "ulgowy";
            bilet_ulgowy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(bilet_ulgowy);
            Controls.Add(aktualny_czas);
            Controls.Add(przycisk_konto);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button przycisk_konto;
        private Label aktualny_czas;
        private CheckBox bilet_ulgowy;
    }
}