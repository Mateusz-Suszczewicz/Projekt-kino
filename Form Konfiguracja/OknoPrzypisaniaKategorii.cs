namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoPrzypisaniaKategorii : Form
    {
        Filmy film;
        public OknoPrzypisaniaKategorii()
        {
            InitializeComponent();
        }
       
        public void ustawienieID(Filmy filmy)
        {
            film = filmy;
            KategorieLoad();
        }

        private void KategorieLoad()
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            #region Kolumny
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.Name = "ID";
            ID.HeaderText = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            dgv.Columns.Add(ID);

            DataGridViewCheckBoxColumn zaznaczenie = new DataGridViewCheckBoxColumn();
            zaznaczenie.Name = "Zaznaczenie";
            zaznaczenie.HeaderText = "";
            dgv.Columns.Add(zaznaczenie);

            DataGridViewTextBoxColumn Nazwa = new DataGridViewTextBoxColumn();
            Nazwa.Name = "Nazwa";
            Nazwa.HeaderText = "Nazwa";
            Nazwa.ReadOnly = true;
            dgv.Columns.Add(Nazwa);
            #endregion

            foreach ((int, string) tempKat in Program.baza.pobranieListyKategori())
            {
                bool zazna = false;

                if (film.Film_Cateogry.Exists(x => x.Item1 == tempKat.Item1))
                {
                    zazna = true;
                }

                DataGridViewRow ROW = (DataGridViewRow)dgv.Rows[0].Clone();
                ROW.Cells[0].Value = tempKat.Item1;
                ROW.Cells[1].Value = zazna;
                ROW.Cells[2].Value = tempKat.Item2;
                dgv.Rows.Add(ROW);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> listaKategorii = new List<int>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    var a = row.Cells[1].Value.ToString();
                    if (a == "True")
                    {
                        listaKategorii.Add(int.Parse(row.Cells[0].Value.ToString()));
                    }
                }
            }

            label1.Text = komunikaty.komunikat[Program.baza.aktualizacjaKategorii(listaKategorii, film.Film_ID)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
