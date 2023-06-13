using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoDodaniaAktora : Form
    {
        Filmy film;
        public OknoDodaniaAktora()
        {
            InitializeComponent();
        }
        public void ustawID(Filmy id)
        {
            film = id;
            AktorzyLoad();
        }

        private void AktorzyLoad()
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();


            #region Kolumny
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.Name = "ID";
            ID.HeaderText = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            dataGridView1.Columns.Add(ID);

            DataGridViewCheckBoxColumn zaznaczenie = new DataGridViewCheckBoxColumn();
            zaznaczenie.Name = "Zaznaczenie";
            zaznaczenie.HeaderText = "Przypisanie";
            dataGridView1.Columns.Add(zaznaczenie);

            DataGridViewTextBoxColumn imie = new DataGridViewTextBoxColumn();
            imie.Name = "Imie";
            imie.HeaderText = "Imię";
            imie.ReadOnly = true;
            dataGridView1.Columns.Add(imie);

            DataGridViewTextBoxColumn nazwisko = new DataGridViewTextBoxColumn();
            nazwisko.Name = "nazwisko";
            nazwisko.HeaderText = "Nazwisko";
            nazwisko.ReadOnly = true;
            dataGridView1.Columns.Add(nazwisko);

            DataGridViewCheckBoxColumn rezyser = new DataGridViewCheckBoxColumn();
            rezyser.Name = "nazwisko";
            rezyser.HeaderText = "Reżyser";
            //rezyser.ReadOnly = true;
            dataGridView1.Columns.Add(rezyser);
            #endregion
            film.setDirector();
            film.setLine_ups();
            foreach (line_up tempAkt in Program.baza.pobranieListyAktorow())
            {
                bool zazna = false;
                bool rez = false;
                if (film.line_up.Exists(x => x.LU_ID == tempAkt.LU_ID))
                {
                    zazna = true;
                }
                if (film.directors != null && film.directors.Exists(x => x.LU_ID == tempAkt.LU_ID))
                {
                    rez = true;
                }
                DataGridViewRow ROW = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                ROW.Cells[0].Value = tempAkt.LU_ID;
                ROW.Cells[1].Value = zazna;
                ROW.Cells[2].Value = tempAkt.LU_Name;
                ROW.Cells[3].Value = tempAkt.LU_Surname;
                ROW.Cells[4].Value = rez;
                dataGridView1.Rows.Add(ROW);
            }
            dataGridView1.AllowUserToAddRows = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<(int, bool)> listaId = new List<(int, bool)>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                if (row.Cells[1].Value != null)
                {
                    var a = row.Cells[1].Value.ToString();
                    if (a == "True")
                    {
                        bool b = false;
                        if (row.Cells[4].Value.ToString() == "True") { b = true; }
                        listaId.Add((int.Parse(row.Cells[0].Value.ToString()), b));
                    }
                }
            }

            label1.Text = komunikaty.komunikat[Program.baza.aktualizacjaAktorow(listaId, film.Film_ID)];
        }


    }
}
