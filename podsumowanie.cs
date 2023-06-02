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
        Filmy Film;
        List<miejsce> listaMiejsc = new List<miejsce>();
        public podsumowanie()
        {
            InitializeComponent();
        }

        public void zaladowanie_danych(List<int> listaMijesc, Filmy film)
        {
            Film = film;
            foreach (int i in listaMijesc)
            {
                miejsce miejsce = new miejsce(i);
                listaMiejsc.Add(miejsce);
            }
            buttons_loads();
        }


        private void buttons_loads()
        {
            label_pods_tytul.Text = "      Tytuł: " + Film.Film_Title;
            label_pods_tytul.ForeColor = Color.Black;
            label_pods_tytul.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_tytul.Location = new Point(50, 30);

            label_pods_dzien.Text = "     Dzień: " + Film.seanses[0].getDataEmisji();
            label_pods_dzien.ForeColor = Color.Black;
            label_pods_dzien.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_dzien.Location = new Point(50, 80);

            label_pods_godzina.Text = "Godzina: " + Film.seanses[0].getGodzinaEmisji();
            label_pods_godzina.ForeColor = Color.Black;
            label_pods_godzina.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_godzina.Location = new Point(50, 130);

            label_pods_sala.Text = "       Sala: " + Film.seanses[0].sal.SR_Nr;
            label_pods_sala.ForeColor = Color.Black;
            label_pods_sala.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_sala.Location = new Point(50, 180);

            label_pods_miejsca.Text = "  Miejsca:";
            label_pods_miejsca.ForeColor = Color.Black;
            label_pods_miejsca.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_miejsca.Location = new Point(50, 230);

            label_koszyk.Text = "Koszyk:";
            label_koszyk.ForeColor = Color.Black;
            label_koszyk.Font = new Font("Arial", 14, FontStyle.Bold);
            label_koszyk.Location = new Point(750, 30);

            #region tabela biletów
            DataGridView tab = new DataGridView();
            tab.DataSource = null;
            tab.Rows.Clear();
            tab.Columns.Clear();


            DataGridViewTextBoxColumn lp = new DataGridViewTextBoxColumn();
            //lp.ValueType = typeof(int);
            lp.Name = "Bilet";
            lp.HeaderText = "Bilet";
            lp.Width = 100;
            lp.ReadOnly = true;
            tab.Columns.Add(lp);

            DataGridViewTextBoxColumn row = new DataGridViewTextBoxColumn();
            row.Name = "Rząd";
            row.HeaderText = "Rząd";
            row.Width = 120;
            row.ReadOnly = true;
            tab.Columns.Add(row);

            DataGridViewTextBoxColumn number = new DataGridViewTextBoxColumn();
            number.Name = "Numer";
            number.HeaderText = "Number";
            number.Width = 120;
            number.ReadOnly = true;
            tab.Columns.Add(number);

            DataGridViewCheckBoxColumn type = new DataGridViewCheckBoxColumn();
            type.Name = "Rodzaj";
            type.HeaderText = "Ulogwy";
            type.Width = 120;
            tab.Columns.Add(type);
            #endregion

            #region tabela_koszyk
            DataGridView koszyk = new DataGridView();
            koszyk.DataSource = null;
            koszyk.Rows.Clear();
            koszyk.Columns.Clear();

            DataGridViewTextBoxColumn koszyk_type = new DataGridViewTextBoxColumn();
            koszyk_type.Name = "Typ biletu";
            koszyk_type.HeaderText = "Typ biletu";
            koszyk_type.Width = 100;
            koszyk_type.ReadOnly = true;
            koszyk.Columns.Add(koszyk_type);

            DataGridViewTextBoxColumn koszyk_ilosc = new DataGridViewTextBoxColumn();
            koszyk_ilosc.Name = "Ilość";
            koszyk_ilosc.HeaderText = "Ilość";
            koszyk_ilosc.Width = 60;
            koszyk_ilosc.ReadOnly = true;
            koszyk.Columns.Add(koszyk_ilosc);

            DataGridViewTextBoxColumn koszyk_kwota = new DataGridViewTextBoxColumn();
            koszyk_kwota.Name = "Kwota";
            koszyk_kwota.HeaderText = "Kwota";
            koszyk_kwota.Width = 100;
            koszyk_kwota.ReadOnly = true;
            koszyk.Columns.Add(koszyk_kwota);

            #endregion

            //tab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tab.AllowUserToResizeColumns = false;
            tab.RowHeadersVisible = false;
            tab.BackgroundColor = Color.White;

            koszyk.AllowUserToResizeColumns = false;
            koszyk.RowHeadersVisible = false;
            koszyk.BackgroundColor = Color.White;
            koszyk.Size = new Size(265, 95);
            koszyk.AllowUserToResizeRows = false;
            koszyk.Location = new Point(750, 80);

            //if (listaMiejsc.Count() > 10)
            //{
            tab.Size = new Size(465, 320);
            //}
            //else
            //{
            //    if (listaMiejsc.Count == 1)
            //    {
            //        tab.Size = new Size(690, 60);
            //    }
            //    else
            //    {
            //        tab.Size = new Size(690, listaMiejsc.Count() * 45);
            //    }
            //}
            int numer_biletu = 1;
            foreach (miejsce i in listaMiejsc)
            {
                DataGridViewRow ROW = (DataGridViewRow)tab.Rows[0].Clone();
                ROW.Cells[0].Value = numer_biletu;
                ROW.Cells[1].Value = (i.Seat_Row - 150) / 70;
                ROW.Cells[2].Value = (i.Seat_Nr - 450) / 55;

                tab.Rows.Add(ROW);
                numer_biletu++;
            }
            tab.AllowUserToAddRows = false;
            tab.AllowUserToResizeRows = false;
            tab.Location = new Point(50, 280);
            this.Controls.Add(tab);
            this.Controls.Add(koszyk);







            //btn.Size = new Size(180, 80);
            //btn.Name = seans.SE_ID.ToString();
        }

        private void button_zatwierdz_Click(object sender, EventArgs e)
        {
            zakup_biletu zak = new zakup_biletu();
            this.Hide();
            zak.ShowDialog();
            zak.Show();

        }

        private void podsumowanie_Load(object sender, EventArgs e)
        {

        }
    }
}
