namespace Projekt_kino.Form_Konfiguracja
{
    partial class OknoDodaniaSeansu
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
            sala = new Label();
            listBox1 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            dtp_dataRoz = new DateTimePicker();
            label4 = new Label();
            dtp_godzZak = new DateTimePicker();
            dtp_dataZak = new DateTimePicker();
            dtp_godzRozp = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // sala
            // 
            sala.AutoSize = true;
            sala.Location = new Point(41, 42);
            sala.Name = "sala";
            sala.Size = new Size(69, 15);
            sala.TabIndex = 0;
            sala.Text = "Sala kinowa";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(116, 42);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 19);
            listBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(322, 9);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "FIlm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 97);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 3;
            label3.Text = "Data rozpoczęcia";
            // 
            // dtp_dataRoz
            // 
            dtp_dataRoz.Location = new Point(116, 91);
            dtp_dataRoz.Name = "dtp_dataRoz";
            dtp_dataRoz.Size = new Size(200, 23);
            dtp_dataRoz.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 5;
            label4.Text = "Data zakończenia";
            // 
            // dtp_godzZak
            // 
            dtp_godzZak.Enabled = false;
            dtp_godzZak.Format = DateTimePickerFormat.Time;
            dtp_godzZak.Location = new Point(445, 132);
            dtp_godzZak.Name = "dtp_godzZak";
            dtp_godzZak.Size = new Size(84, 23);
            dtp_godzZak.TabIndex = 6;
            // 
            // dtp_dataZak
            // 
            dtp_dataZak.Enabled = false;
            dtp_dataZak.Location = new Point(116, 132);
            dtp_dataZak.Name = "dtp_dataZak";
            dtp_dataZak.Size = new Size(200, 23);
            dtp_dataZak.TabIndex = 7;
            // 
            // dtp_godzRozp
            // 
            dtp_godzRozp.Format = DateTimePickerFormat.Time;
            dtp_godzRozp.Location = new Point(443, 91);
            dtp_godzRozp.Name = "dtp_godzRozp";
            dtp_godzRozp.Size = new Size(84, 23);
            dtp_godzRozp.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 97);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 9;
            label5.Text = "Godzina rozpoczęcia";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(322, 138);
            label6.Name = "label6";
            label6.Size = new Size(117, 15);
            label6.TabIndex = 10;
            label6.Text = "Godzina zakończenia";
            // 
            // button1
            // 
            button1.Location = new Point(713, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Zamknij";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(632, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "Zapisz";
            button2.UseVisualStyleBackColor = true;
            // 
            // OknoDodaniaSeansu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtp_godzRozp);
            Controls.Add(dtp_dataZak);
            Controls.Add(dtp_godzZak);
            Controls.Add(label4);
            Controls.Add(dtp_dataRoz);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(sala);
            Name = "OknoDodaniaSeansu";
            Text = "OknoDodaniaSeansu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label sala;
        private ListBox listBox1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtp_dataRoz;
        private Label label4;
        private DateTimePicker dtp_godzZak;
        private DateTimePicker dtp_dataZak;
        private DateTimePicker dtp_godzRozp;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
    }
}