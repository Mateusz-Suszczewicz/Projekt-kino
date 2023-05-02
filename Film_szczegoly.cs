using kino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Film = new Filmy(FilmId);
            dodanie_szczegolow();



            



        }


        public void dodanie_szczegolow()
        {
            #region Film_Title
            label1.Text = Film.Film_Title;
            label1.ForeColor = Color.Black;
            label1.Font = new Font("Arial", 16, FontStyle.Bold);

            #endregion

            #region Film_Content
            label2.Text = Film.Film_Content;
            label2.ForeColor = Color.Black;
            label2.Font = new Font("Arial", 14);
            label2.Size = new Size(800, 400);
            label2.AutoSize = false;

            label2.TextAlign = ContentAlignment.TopLeft;
            #endregion

            #region Film_Duration
            label3.Text = "Czas trwania: " + Film.Film_Duration / 60 + " godz. " + Film.Film_Duration % 60 + " min. (" + Film.Film_Duration + " min)";
            label3.Font = new Font("Arial", 14);
            #endregion

            #region Film_Language
            label4.Text = "           Język: " + Film.Film_Language;
            label4.Font = new Font("Arial", 14);
            #endregion

            #region Film_Language
            label5.Text = "    Produkcja: " + Film.Film_Production;
            label5.Font = new Font("Arial", 14);
            #endregion

            #region Film_Category

            #endregion

            //foreach (var seans in Film.seanses)
            //{
            //    seans.getGodzinaEmisji();
            //}

            List<string> godziny = new List<string> { "10:20", "15:40", "20:15" };

            foreach (var seans in godziny)
            {
                Button btn = new Button();
                btn.Text = seans;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("Arial", 14);
                btn.Location = new Point(300, 505);
                btn.Size = new Size(180, 80);
                btn.Show();
            }
        }





        // tutaj działasz juz na zmiennej Film 

    }
}
