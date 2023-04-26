using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    internal class Filmy
    {
        public string Film_Title { get; set; }
        public string Film_Content;
        public DateTime Film_DataDodania;
        public int Film_Duration;
        public int Film_ID;
        public string Film_Language;
        public string Film_Production;
        public string Film_Translation;
        public List<string>? Film_Cateogry = null;
        public List<seanse>? seanses = null;
        private kinoDB baza = new kinoDB(true);
        
        public string modyfikacjaFilmu(int IDFilm, string? tytul = null, string? kontent = null, DateTime? data = null, int katID = -1, int dlugosc = -1,string? jezyk = null,string? produkcja = null, string? tluamczenie = null)
        {
            var a = baza.GetFilmy(IDFilm);
            if(a != null)
            {
                string? filmtitle = tytul == null ? a.Film_Title : tytul;
                string? filmcontent = kontent == null ? a.Film_Content : tytul;
                DateTime? filmdata = data == null ? a.Film_DataDodania : data;
                int filmdlugosc = dlugosc == -1 ? a.Film_Duration : dlugosc;
                string? filmjezyk = jezyk == null ? a.Film_Language : tytul;
                string? filmprodukcja = produkcja == null ? a.Film_Production : produkcja;
                string? filmtlumacznie = tluamczenie == null ? a.Film_Translation : tluamczenie;
                return baza.DodanieFilmu(filmtitle, filmcontent, filmdata, filmdlugosc, filmjezyk, filmprodukcja, filmtlumacznie, IDFilm);
            }
            else
            {
                return "Film nie istnieje";
            }
        }

        protected void setCategory()
        {
            Film_Cateogry = baza.getCategory(Film_ID);
        }

        protected void setSeanse(DateTime data)
        {
           seanses = baza.getSeanceOnFilmAndDay(data, Film_ID);

        }

        public List<Filmy> getFilmOnDay(DateTime date)
        {
            List<Filmy>? filmy = baza.getFilmList(date);
            if (filmy != null)
            {
                foreach (var film in filmy)
                {
                    film.setCategory();
                    film.setSeanse(date);
                }
            }
            return filmy;
        }

    }
}
