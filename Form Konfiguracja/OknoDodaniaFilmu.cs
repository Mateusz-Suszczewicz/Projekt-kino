using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoDodaniaFilmu : Form
    {
        Filmy film;
        public OknoDodaniaFilmu()
        {
            InitializeComponent();
        }

        public void ustawienieID(int ID)
        {
            film = new Filmy(ID, true);
            tb_duration.Text = film.Film_Duration.ToString();
            tb_language.Text = film.Film_Language.ToString();
            tb_name.Text = film.Film_Title.ToString();
            tb_production.Text = film.Film_Production.ToString();
            tb_translate.Text = film.Film_Translation.ToString();
            rtb_opis.Text = film.Film_Content.ToString();
            ustTAB();
            //TODO: tłumaczenia i produkcje można zrobić jako n:n
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ustTAB();
        }

        private void ustTAB()
        {
            if (tabControl1.SelectedTab == tabPage_kategorie)
            {
                kategorieLoad();
            }
            else if (tabControl1.SelectedTab == tabPage_zdjecia)
            {
                zdjeciaLoad();
            }
            else if (tabControl1.SelectedTab == tabPage_seanse)
            {
                senaseLoad();
            }
            else if (tabControl1.SelectedTab == tp_aktorzy)
            {
                aktorzyLoad();
            }
        }

        #region kategoria
        private void kategorieLoad()
        {
            dgv_kategoria.Columns.Clear();
            dgv_kategoria.Rows.Clear();

            #region Kolumny
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.Name = "ID";
            ID.HeaderText = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            dgv_kategoria.Columns.Add(ID);

            DataGridViewTextBoxColumn Nazwa = new DataGridViewTextBoxColumn();
            Nazwa.Name = "Nazwa";
            Nazwa.HeaderText = "Nazwa";
            Nazwa.ReadOnly = true;
            dgv_kategoria.Columns.Add(Nazwa);
            #endregion

            foreach ((int, string) tempKat in Program.baza.getCategory(film.Film_ID))
            {
                DataGridViewRow ROW = (DataGridViewRow)dgv_kategoria.Rows[0].Clone();
                ROW.Cells[0].Value = tempKat.Item1;
                ROW.Cells[1].Value = tempKat.Item2;
                dgv_kategoria.Rows.Add(ROW);
            }
            film.Film_Cateogry = Program.baza.getCategory(film.Film_ID);

        }

        private void editKat(object sender, EventArgs e)
        {
            OknoPrzypisaniaKategorii opk = new OknoPrzypisaniaKategorii();
            opk.ustawienieID(film);
            opk.ShowDialog();
            kategorieLoad();
        }

        #endregion

        #region zdjęcia
        private void zdjeciaLoad()
        {
            dgv_zdjecia.Columns.Clear();
            dgv_zdjecia.Rows.Clear();


            #region Kolumny
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.Name = "ID";
            ID.HeaderText = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            dgv_zdjecia.Columns.Add(ID);

            DataGridViewTextBoxColumn Nazwa = new DataGridViewTextBoxColumn();
            Nazwa.Name = "SRC";
            Nazwa.HeaderText = "SRC";
            Nazwa.ReadOnly = true;
            dgv_zdjecia.Columns.Add(Nazwa);
            #endregion

            foreach ((int, string) tempKat in Program.baza.getPic(film.Film_ID))
            {
                DataGridViewRow ROW = (DataGridViewRow)dgv_zdjecia.Rows[0].Clone();
                ROW.Cells[0].Value = tempKat.Item1;
                ROW.Cells[1].Value = tempKat.Item2;
                dgv_zdjecia.Rows.Add(ROW);
            }
            film.Pic_Src = Program.baza.getPic(film.Film_ID);

        }

        private void btn_dodajZdjecia_Click(object sender, EventArgs e)
        {
            OknoDodaniaZdjecia odz = new OknoDodaniaZdjecia();
            odz.ustawID(film.Film_ID);
            odz.ShowDialog();
            film.Pic_Src = null;
            film.setPic();
            zdjeciaLoad();
        }

        private void btn_usunZdjecia_Click(object sender, EventArgs e)
        {
            if (dgv_zdjecia.CurrentCell == null) { return; }
            int zdjecie;
            zdjecie = int.Parse(dgv_zdjecia.CurrentRow.Cells[0].Value.ToString());
            Program.baza.usunZdjecie(zdjecie);
            zdjeciaLoad();

        }

        private void edytujZdjecie(object sender, EventArgs e)
        {
            OknoDodaniaZdjecia odz = new OknoDodaniaZdjecia();
            odz.ustawID(film.Film_ID, int.Parse(dgv_zdjecia.CurrentRow.Cells[0].Value.ToString()));
            odz.ShowDialog();
            zdjeciaLoad();
        }
        #endregion

        #region Seanse
        private void senaseLoad()
        {
            dgv_seanse.Columns.Clear();
            dgv_seanse.Rows.Clear();

            #region Kolumny
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.Name = "ID";
            ID.HeaderText = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            dgv_seanse.Columns.Add(ID);

            DataGridViewTextBoxColumn LP = new DataGridViewTextBoxColumn();
            LP.Name = "LP";
            LP.HeaderText = "LP";
            LP.ReadOnly = true;
            dgv_seanse.Columns.Add(LP);

            DataGridViewTextBoxColumn dataStart = new DataGridViewTextBoxColumn();
            dataStart.Name = "Data rozpoczęcia";
            dataStart.HeaderText = "Data rozpoczęcia";
            dataStart.ReadOnly = true;
            dgv_seanse.Columns.Add(dataStart);

            DataGridViewTextBoxColumn dataEnd = new DataGridViewTextBoxColumn();
            dataEnd.Name = "Data zakończenia";
            dataEnd.HeaderText = "Data zakończenia";
            dataEnd.ReadOnly = true;
            dgv_seanse.Columns.Add(dataEnd);
            #endregion
            int tempLP = 1;
            foreach (seanse tempSence in Program.baza.pobranieListySeansowDoFIlmu(film.Film_ID))
            {
                DataGridViewRow ROW = (DataGridViewRow)dgv_seanse.Rows[0].Clone();
                ROW.Cells[0].Value = tempSence.SE_ID;
                ROW.Cells[1].Value = tempLP;
                ROW.Cells[2].Value = tempSence.SE_DataEmisji.ToString();
                ROW.Cells[3].Value = tempSence.SE_DataKonca.ToString();
                dgv_seanse.Rows.Add(ROW);
                tempLP++;
            }
            film.seanses = Program.baza.pobranieListySeansowDoFIlmu(film.Film_ID);
        }

        private void edytujSeans(object sender, EventArgs e)
        {
            OknoDodaniaSeansu ods = new OknoDodaniaSeansu();
            ods.ustawID(film, int.Parse(dgv_seanse.CurrentRow.Cells[0].Value.ToString()));
            ods.ShowDialog();
            film.seanses = null;
            film.seanses = Program.baza.pobranieListySeansowDoFIlmu(film.Film_ID);
            senaseLoad();
        }

        private void btn_dodajSeans_Click(object sender, EventArgs e)
        {
            OknoDodaniaSeansu ods = new OknoDodaniaSeansu();
            ods.ustawID(film, 0);
            ods.ShowDialog();
            film.seanses = null;
            film.seanses = Program.baza.pobranieListySeansowDoFIlmu(film.Film_ID);
            senaseLoad();
        }

        private void btn_usunSeans_Click(object sender, EventArgs e)
        {
            if (dgv_zdjecia.CurrentCell == null) { return; }
            int seansId;
            seansId = int.Parse(dgv_zdjecia.CurrentRow.Cells[0].Value.ToString());
            Program.baza.usunSeans(seansId);
            senaseLoad();
        }
        #endregion

        #region aktorzy
        private void aktorzyLoad()
        {
            dgv_aktorzy.Columns.Clear();
            dgv_aktorzy.Rows.Clear();


            #region Kolumny
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.Name = "ID";
            ID.HeaderText = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            dgv_aktorzy.Columns.Add(ID);

            DataGridViewTextBoxColumn Imie = new DataGridViewTextBoxColumn();
            Imie.Name = "SRC";
            Imie.HeaderText = "Imie";
            Imie.ReadOnly = true;
            dgv_aktorzy.Columns.Add(Imie);

            DataGridViewTextBoxColumn Nazwisko = new DataGridViewTextBoxColumn();
            Nazwisko.Name = "SRC";
            Nazwisko.HeaderText = "Nazwisko";
            Nazwisko.ReadOnly = true;
            dgv_aktorzy.Columns.Add(Nazwisko);

            DataGridViewTextBoxColumn Rezyser = new DataGridViewTextBoxColumn();
            Rezyser.Name = "SRC";
            Rezyser.HeaderText = "Reżyser";
            Rezyser.ReadOnly = true;
            dgv_aktorzy.Columns.Add(Rezyser);
            #endregion

            foreach (line_up temp in Program.baza.pobranieListyAktorow(film.Film_ID))
            {
                DataGridViewRow ROW = (DataGridViewRow)dgv_zdjecia.Rows[0].Clone();
                ROW.Cells[0].Value = temp.LU_ID;
                ROW.Cells[1].Value = temp.LU_Name;
                ROW.Cells[2].Value = temp.LU_Surname;
                ROW.Cells[3].Value = temp.LF_Status == 1 ? true : false;
                dgv_zdjecia.Rows.Add(ROW);
            }

        }

        private void edytujAktora(object sender, EventArgs e)
        {
            OknoDodaniaAktora ods = new OknoDodaniaAktora();
            ods.ustawID(1);
            ods.ShowDialog();
            aktorzyLoad();
        }

        private void btn_dodajAktora_Click(object sender, EventArgs e)
        {
            OknoDodaniaSeansu ods = new OknoDodaniaSeansu();
            ods.ustawID(film, 0);
            ods.ShowDialog();
            aktorzyLoad();
        }

        private void btn_usunAktora_Click(object sender, EventArgs e)
        {
            if (dgv_aktorzy.CurrentCell == null) { return; }
            int seansId;
            seansId = int.Parse(dgv_aktorzy.CurrentRow.Cells[0].Value.ToString());
            Program.baza.usunAktora(seansId);
            senaseLoad();
        }
        #endregion

        private void btn_zamknij_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_zapiszFilm_Click(object sender, EventArgs e)
        {
            Program.baza.zapiszFilm(film);
        }
    }
}
