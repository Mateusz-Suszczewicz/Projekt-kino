using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino
{
    public partial class sala_kinowa : Form
    {
        Filmy Film;
        public sala_kinowa()
        {
            InitializeComponent();
        }

        public void get_details(string id , string godzina_seansu)
        {
            var FilmId = int.Parse(id);
            Film = new Filmy(FilmId);
            string godzina = godzina_seansu;
            sala_kinowa_Load(godzina);
        }
        

        private void sala_kinowa_Load(string godzina_seansu)
        {
            label1.Text = "id: " + Film.Film_ID.ToString() +
                          " tytul: " + Film.Film_Title +
                          " data: " + " tutaj data " +
                          " godzina: " + godzina_seansu;
            label1.Font = new Font("Arial", 16, FontStyle.Bold);
        }
    }
}
