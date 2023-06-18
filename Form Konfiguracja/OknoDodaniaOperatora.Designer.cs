namespace Projekt_kino.Form_Konfiguracja
{
    partial class OknoDodaniaOperatora
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
            label2 = new Label();
            checkBoxAdmin = new CheckBox();
            textBoxNazwa = new TextBox();
            textBoxhaslo = new TextBox();
            button1 = new Button();
            button2 = new Button();
            info = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 21);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Nazwa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 56);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Hasło";
            // 
            // checkBoxAdmin
            // 
            checkBoxAdmin.AutoSize = true;
            checkBoxAdmin.Location = new Point(625, 29);
            checkBoxAdmin.Name = "checkBoxAdmin";
            checkBoxAdmin.Size = new Size(99, 19);
            checkBoxAdmin.TabIndex = 3;
            checkBoxAdmin.Text = "Administrator";
            checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // textBoxNazwa
            // 
            textBoxNazwa.Location = new Point(101, 17);
            textBoxNazwa.Name = "textBoxNazwa";
            textBoxNazwa.Size = new Size(288, 23);
            textBoxNazwa.TabIndex = 4;
            // 
            // textBoxhaslo
            // 
            textBoxhaslo.Location = new Point(99, 53);
            textBoxhaslo.Name = "textBoxhaslo";
            textBoxhaslo.Size = new Size(290, 23);
            textBoxhaslo.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(713, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Zamknij";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(625, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Zapisz";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Location = new Point(14, 418);
            info.Name = "info";
            info.Size = new Size(0, 15);
            info.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 350);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 9;
            // 
            // OknoDodaniaOperatora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(info);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxhaslo);
            Controls.Add(textBoxNazwa);
            Controls.Add(checkBoxAdmin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OknoDodaniaOperatora";
            Text = "Dodanie Operatora";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox checkBoxAdmin;
        private TextBox textBoxNazwa;
        private TextBox textBoxhaslo;
        private Button button1;
        private Button button2;
        private Label info;
        private Label label3;
    }
}