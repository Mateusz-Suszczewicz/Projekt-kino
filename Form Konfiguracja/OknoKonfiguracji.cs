using kino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoKonfiguracji : Form
    {
        kinoDB baza = new kinoDB(true);
        bool open = true;
        public OknoKonfiguracji()
        {
            InitializeComponent();
            ustTAB();


        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ustTAB();
        }

        private void ustTAB()
        {
            if (tabControl.SelectedTab == tabOper)
            {
                operLoad();
            }
            else if (tabControl.SelectedTab == tabfilmy)
            {
                FilmyLoad();
            }
            else if (tabControl.SelectedTab == tabsale)
            {
                Saleload();
            }
            else if (tabControl.SelectedTab == tabKat)
            {
                KatLoad();
            }
            else if (tabControl.SelectedTab == tabAktorzy)
            {
                AktLoad();
            }
        }
        #region operator
        private void operLoad()
        {
            dgvOper.Rows.Clear();
            dgvOper.Columns.Clear();

            kinoDB baza = new kinoDB(true);
            dgvOper.AllowUserToResizeColumns = false;
            dgvOper.RowHeadersVisible = false;
            dgvOper.BackgroundColor = Color.White;
            dgvOper.AllowUserToResizeRows = false;



            DataGridViewTextBoxColumn idOper = new DataGridViewTextBoxColumn();
            idOper.Name = "ID";
            idOper.HeaderText = "ID";
            idOper.ReadOnly = true;
            idOper.Visible = false;
            dgvOper.Columns.Add(idOper);
            DataGridViewTextBoxColumn NazwaOper = new DataGridViewTextBoxColumn();
            NazwaOper.Name = "Nazwa";
            NazwaOper.HeaderText = "Nazwa";
            NazwaOper.ReadOnly = true;
            dgvOper.Columns.Add(NazwaOper);
            DataGridViewTextBoxColumn TypOper = new DataGridViewTextBoxColumn();
            TypOper.Name = "Typ";
            TypOper.HeaderText = "Typ";
            TypOper.ReadOnly = true;
            dgvOper.Columns.Add(TypOper);

            foreach ((int, string, int) oper in baza.pobranieOper())
            {
                string stat;
                if (oper.Item3 == 0)
                {
                    stat = "Administrator";
                }
                else
                {
                    stat = "Użytkownik";
                }
                DataGridViewRow ROW = (DataGridViewRow)dgvOper.Rows[0].Clone();
                ROW.Cells[0].Value = oper.Item1;
                ROW.Cells[1].Value = oper.Item2;
                ROW.Cells[2].Value = stat;
                dgvOper.Rows.Add(ROW);
            }

        }

        private void addOper(object sender, EventArgs e)
        {
            OknoDodaniaOperatora odo = new OknoDodaniaOperatora();
            int ri = dgvOper.CurrentCell.RowIndex;
            if (dgvOper.Rows.Count == 0) return;
            var a = dgvOper.Rows[ri].Cells[0].Value.ToString();
            odo.ustawienieID(int.Parse(a));
            odo.ShowDialog();
            odo.Close();
            operLoad();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OknoDodaniaOperatora odf = new OknoDodaniaOperatora();
            odf.ustawienieID(-1);
            odf.ShowDialog();
            odf.Close();
            operLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ri = dgvOper.CurrentCell.RowIndex;
            var a = dgvOper.Rows[ri].Cells[0].Value.ToString();

            if (int.Parse(a) != 1)
            {
                Operator.usun(int.Parse(a));
            }
            operLoad();
        }
        #endregion

        #region film
        private void FilmyLoad()
        {
            dgvFilm.Rows.Clear();
            dgvFilm.Columns.Clear();

            kinoDB baza = new kinoDB(true);
            dgvFilm.AllowUserToResizeColumns = false;
            dgvFilm.RowHeadersVisible = false;
            dgvFilm.BackgroundColor = Color.White;
            dgvFilm.AllowUserToResizeRows = false;



            DataGridViewTextBoxColumn idOper = new DataGridViewTextBoxColumn();
            idOper.Name = "ID";
            idOper.HeaderText = "ID";
            idOper.ReadOnly = true;
            idOper.Visible = false;
            dgvFilm.Columns.Add(idOper);
            DataGridViewTextBoxColumn NazwaOper = new DataGridViewTextBoxColumn();
            NazwaOper.Name = "Nazwa";
            NazwaOper.HeaderText = "Nazwa";
            NazwaOper.ReadOnly = true;
            dgvFilm.Columns.Add(NazwaOper);

            foreach ((int, string) oper in baza.pobranieListyFilmow())
            {
                DataGridViewRow ROW = (DataGridViewRow)dgvFilm.Rows[0].Clone();
                ROW.Cells[0].Value = oper.Item1;
                ROW.Cells[1].Value = oper.Item2;
                dgvFilm.Rows.Add(ROW);
            }


        }

        public void addFilm(object sender, EventArgs e)
        {
            OknoDodaniaFilmu odf = new OknoDodaniaFilmu();
            int ri = dgvFilm.CurrentCell.RowIndex;
            if (dgvFilm.Rows.Count == 0) return;
            var a = dgvFilm.Rows[ri].Cells[0].Value.ToString();
            odf.ustawienieID(int.Parse(a));
            odf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO: obsłużyć usuwanie filmu
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OknoDodaniaFilmu odf = new OknoDodaniaFilmu();
            odf.ustawienieID(-1);
            odf.ShowDialog();
        }
        #endregion

        #region sale
        private void Saleload()
        {
            dgvSale.Rows.Clear();
            dgvSale.Columns.Clear();

            dgvSale.AllowUserToResizeColumns = false;
            dgvSale.RowHeadersVisible = false;
            dgvSale.BackgroundColor = Color.White;
            dgvSale.AllowUserToResizeRows = false;

            DataGridViewTextBoxColumn idOper = new DataGridViewTextBoxColumn();
            idOper.Name = "ID";
            idOper.HeaderText = "ID";
            idOper.ReadOnly = true;
            idOper.Visible = false;
            dgvSale.Columns.Add(idOper);

            DataGridViewTextBoxColumn NazwaOper = new DataGridViewTextBoxColumn();
            NazwaOper.Name = "Numer";
            NazwaOper.HeaderText = "Numer";
            NazwaOper.ReadOnly = true;
            dgvSale.Columns.Add(NazwaOper);


            foreach ((int, string) oper in baza.pobranieListySal())
            {

                DataGridViewRow ROW = (DataGridViewRow)dgvSale.Rows[0].Clone();
                ROW.Cells[0].Value = oper.Item1;
                ROW.Cells[1].Value = oper.Item2;
                dgvSale.Rows.Add(ROW);
            }
        }

        private void addSala(object sender, DataGridViewCellEventArgs e)
        {

            OknoDodaniaSali odf = new OknoDodaniaSali();
            int ri = dgvSale.CurrentCell.RowIndex;
            if (dgvSale.Rows.Count == 0) return;
            var a = dgvSale.Rows[ri].Cells[0].Value.ToString();
            dgvSale.CurrentCell = null;
            odf.ustawienieID(int.Parse(a));
            this.Hide();
            odf.ShowDialog();
            this.Show();
            Saleload();
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ri = dgvSale.CurrentCell.RowIndex;
            var a = dgvSale.Rows[ri].Cells[0].Value.ToString();

            if (int.Parse(a) != 0)
            {
                info.Text = komunikaty.komunikat[baza.usunSale(int.Parse(a))];
            }
            Saleload();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OknoDodaniaSali odf = new OknoDodaniaSali();
            odf.ustawienieID(-1);
            this.Hide();
            odf.ShowDialog();
            this.Show();
            odf.Close();
            Saleload();
        }
        #endregion

        #region kategoria
        private void KatLoad()
        {
            dgvKategorie.Rows.Clear();
            dgvKategorie.Columns.Clear();

            kinoDB baza = new kinoDB(true);
            dgvKategorie.AllowUserToResizeColumns = false;
            dgvKategorie.RowHeadersVisible = false;
            dgvKategorie.BackgroundColor = Color.White;
            dgvKategorie.AllowUserToResizeRows = false;



            DataGridViewTextBoxColumn idOper = new DataGridViewTextBoxColumn();
            idOper.Name = "ID";
            idOper.HeaderText = "ID";
            idOper.ReadOnly = true;
            idOper.Visible = false;
            dgvKategorie.Columns.Add(idOper);

            DataGridViewTextBoxColumn NazwaOper = new DataGridViewTextBoxColumn();
            NazwaOper.Name = "Nazwa";
            NazwaOper.HeaderText = "Nazwa";
            NazwaOper.ReadOnly = true;
            dgvKategorie.Columns.Add(NazwaOper);

            dgvKategorie.RowHeadersVisible = false;

            foreach ((int, string) oper in baza.pobranieListyKategori())
            {

                DataGridViewRow ROW = (DataGridViewRow)dgvKategorie.Rows[0].Clone();
                ROW.Cells[0].Value = oper.Item1;
                ROW.Cells[1].Value = oper.Item2;
                dgvKategorie.Rows.Add(ROW);
            }
        }

        private void addKat(object sender, EventArgs e)
        {
            OknoDodanieKategorii odk = new OknoDodanieKategorii();
            int ri = dgvKategorie.CurrentCell.RowIndex;
            if (dgvKategorie.Rows.Count == 0) return;
            var a = dgvKategorie.Rows[ri].Cells[0].Value.ToString();
            odk.ustawienieID(int.Parse(a));
            odk.ShowDialog();
            odk.Close();
            KatLoad();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OknoDodanieKategorii odk = new OknoDodanieKategorii();
            odk.ustawienieID(-1);
            odk.ShowDialog();
            odk.Close();
            KatLoad();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int ri = dgvKategorie.CurrentCell.RowIndex;
            var a = dgvKategorie.Rows[ri].Cells[0].Value.ToString();

            if (int.Parse(a) != 0)
            {
                label1.Text = komunikaty.komunikat[baza.usunKategorie(int.Parse(a))];
            }
            KatLoad();
        }
        #endregion

        #region aktorzy
        private void AktLoad()
        {
            dgvAktorzy.Rows.Clear();
            dgvAktorzy.Columns.Clear();

            dgvAktorzy.AllowUserToResizeColumns = false;
            dgvAktorzy.RowHeadersVisible = false;
            dgvAktorzy.BackgroundColor = Color.White;
            dgvAktorzy.AllowUserToResizeRows = false;

            DataGridViewTextBoxColumn idOper = new DataGridViewTextBoxColumn();
            idOper.Name = "ID";
            idOper.HeaderText = "ID";
            idOper.ReadOnly = true;
            idOper.Visible = false;
            dgvAktorzy.Columns.Add(idOper);

            DataGridViewTextBoxColumn Imie = new DataGridViewTextBoxColumn();
            Imie.Name = "Nazwa";
            Imie.HeaderText = "Imie";
            Imie.ReadOnly = true;
            dgvAktorzy.Columns.Add(Imie);

            DataGridViewTextBoxColumn Nazwisko = new DataGridViewTextBoxColumn();
            Nazwisko.Name = "Nazwisko";
            Nazwisko.HeaderText = "Nazwisko";
            Nazwisko.ReadOnly = true;
            dgvAktorzy.Columns.Add(Nazwisko);

            dgvAktorzy.RowHeadersVisible = false;

            foreach (line_up oper in baza.pobranieListyAktorow())
            {

                DataGridViewRow ROW = (DataGridViewRow)dgvAktorzy.Rows[0].Clone();
                ROW.Cells[0].Value = oper.LU_ID;
                ROW.Cells[1].Value = oper.LU_Name;
                ROW.Cells[2].Value = oper.LU_Surname;
                dgvKategorie.Rows.Add(ROW);
            }
        }

        private void addAkt(object sender, EventArgs e)
        {
            OknoStworzeniaAktora odk = new OknoStworzeniaAktora();
            int ri = dgvAktorzy.CurrentCell.RowIndex;
            if (dgvAktorzy.Rows.Count == 0) return;
            var a = dgvAktorzy.Rows[ri].Cells[0].Value.ToString();
            odk.ustawienieID(int.Parse(a));
            odk.ShowDialog();
            odk.Close();
            AktLoad();
        }

        private void btn_usunAktora_Click(object sender, EventArgs e)
        {
            int ri = dgvAktorzy.CurrentCell.RowIndex;
            var a = dgvAktorzy.Rows[ri].Cells[0].Value.ToString();

            if (int.Parse(a) != 0)
            {
                label2.Text = komunikaty.komunikat[baza.usunAktora(int.Parse(a))];
            }
            AktLoad();
        }

        private void btn_dodajAktora_Click(object sender, EventArgs e)
        {
            OknoStworzeniaAktora odk = new OknoStworzeniaAktora();
            odk.ustawienieID(-1);
            odk.ShowDialog();
            odk.Close();
            AktLoad();
        }
        #endregion

    }
}
