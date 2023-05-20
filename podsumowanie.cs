using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino
{
    public partial class podsumowanie : Form
    {
        public podsumowanie()
        {
            InitializeComponent();
            buttons_loads();
        }


        private void podsumowanie_Load(object sender, EventArgs e)
        {
            



        }


        private void buttons_loads()
        {
            label_pods_tytul.Text = "tytul";
            label_pods_tytul.ForeColor = Color.Black;
            label_pods_tytul.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_tytul.Location = new Point(300, 30);

            label_pods_dzien.Text = "dzien";
            label_pods_dzien.ForeColor = Color.Black;
            label_pods_dzien.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_dzien.Location = new Point(300, 80);

            label_pods_godzina.Text = "godzina";
            label_pods_godzina.ForeColor = Color.Black;
            label_pods_godzina.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_godzina.Location = new Point(300, 130);

            label_pods_sala.Text = "sala";
            label_pods_sala.ForeColor = Color.Black;
            label_pods_sala.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_sala.Location = new Point(300, 180);

            label_pods_miejsca.Text = "Wybrane miejsca:";
            label_pods_miejsca.ForeColor = Color.Black;
            label_pods_miejsca.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_miejsca.Location = new Point(300, 230);

            DataGridView tab = new DataGridView();
            tab.DataSource = null;
            tab.Rows.Clear();
            tab.Columns.Clear();

            DataGridViewTextBoxColumn lp = new DataGridViewTextBoxColumn();
            lp.Name = "Bilet";
            lp.HeaderText = "Bilet";
            lp.Width = 80;
            tab.Columns.Add(lp);

            DataGridViewTextBoxColumn row = new DataGridViewTextBoxColumn();
            row.Name = "Rząd";
            row.HeaderText = "Rząd";
            row.Width = 150;
            tab.Columns.Add(row);

            DataGridViewTextBoxColumn number = new DataGridViewTextBoxColumn();
            number.Name = "Numer";
            number.HeaderText = "Number";
            number.Width = 150;
            tab.Columns.Add(number);

            DataGridViewTextBoxColumn type = new DataGridViewTextBoxColumn();
            type.Name = "Rodzaj";
            type.HeaderText = "Type";
            type.Width = 300;
            tab.Columns.Add(type);

            //tab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tab.AllowUserToResizeColumns = false;    
            tab.RowHeadersVisible = false;
            tab.BackgroundColor = Color.White;
            tab.ReadOnly = true;
            
            tab.Size = new Size(710, 200);
            tab.Location = new Point(300, 280);
            this.Controls.Add(tab);

            






            //btn.Size = new Size(180, 80);
            //btn.Name = seans.SE_ID.ToString();
        }

    }
}
