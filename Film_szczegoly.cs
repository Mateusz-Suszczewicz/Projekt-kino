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

namespace Projekt_kino
{
    public partial class Film_szczegoly : Form
    {
        Filmy Film;
        public Film_szczegoly()
        {
            InitializeComponent();
        }

        public void getFIlmId(string id)
        {
            var FilmId = int.Parse(id);
            kinoDB baza = new kinoDB(true);
            Film = baza.GetFilmy(FilmId);
            label1.Text = Film.Film_Title;
        }
        // tutaj działasz juz na zmiennej Film 

    }
}
