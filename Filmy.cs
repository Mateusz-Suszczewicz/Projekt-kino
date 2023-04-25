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
        protected string Film_Title { get; set; }
        protected string Film_Content;
        protected DateTime Film_DataDodania;
        protected int Film_Duration;
        protected int Film_ID;
        protected string Film_Language;
        protected string Film_Production;
        protected string Film_Translation;
        protected List<string>? Film_Cateogry = null;
        protected List<seanse>? seanses = null;

        public string getTitle() { return Film_Title; }
        public string getLanguage() { return Film_Language; }
        public int getDuration() { return Film_Duration; }
        //public Filmy(string tytul, string kontent, DateTime data, int katID, int dlugosc, int IDFilm, string jezyk, string produkcja, string tluamczenie)
        //{
        //    Film_Title = tytul;
        //    Film_Content = kontent;
        //    Film_DataDodania = data;
        //    Film_CatID = katID;
        //    Film_Duration = dlugosc;
        //    Film_ID = IDFilm;
        //    Film_Language = jezyk;
        //    Film_Production = produkcja;
        //    Film_Translation = tluamczenie;

        //}

        public string modyfikacjaFilmu(int IDFilm, string? tytul = null, string? kontent = null, DateTime? data = null, int katID = -1, int dlugosc = -1,string? jezyk = null,string? produkcja = null, string? tluamczenie = null)
        {
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
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
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
            Film_Cateogry = baza.getCategory(Film_ID);
        }

        protected void setSeanse(DateTime data)
        {
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
            seanses = baza.getSeanceOnFilmAndDay(data, Film_ID);

        }

        public List<Filmy> getFilmOnDay(DateTime date)
        {
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
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

        public List<seanse> getSeanse() { return seanses; }
    }
}
