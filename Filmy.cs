using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    public class Filmy
    {
        public string Film_Title { get; set; }
        public string Film_Content;
        public DateTime Film_DataDodania;
        public int Film_Duration;
        public int Film_ID = 0;
        public string Film_Language;
        public string Film_Production;
        public string Film_Translation;
        public List<(int,string)>? Film_Cateogry = null;
        public List<seanse>? seanses = null;
        public List<(int, string)>? Pic_Src = null;
        public List<line_up> line_up = null;
        public List<line_up> directors = null;

        public Filmy() { }

        public Filmy(int filmID, bool metoda = true)
        {
            Filmy film = new Filmy();
            film = baza.GetFilmy(filmID, metoda);
            Film_Title = film.Film_Title;
            Film_Content = film.Film_Content;
            Film_DataDodania = film.Film_DataDodania;
            Film_Duration = film.Film_Duration;
            Film_ID = film.Film_ID;
            Film_Language = film.Film_Language;
            Film_Production = film.Film_Production;
            Film_Translation = film.Film_Translation;
            setCategory();
            setPic();
            setLine_ups();
            setDirector();
        }

        private kinoDB baza = new kinoDB(true);

        protected void setCategory()
        {
            Film_Cateogry = baza.getCategory(Film_ID);
        }

        public void setSeanse(DateTime data, int id = 0)
        {
            if (id == 0)
            {
                seanses = baza.getSeanceOnFilmAndDay(data, Film_ID);
            }
            else {
                seanses = baza.getOneSeanse(id);
                seanses[0].ustawienieSali();
            }

        }
        
        public void setPic()
        {
            Pic_Src = baza.getPic(Film_ID);
        }

        public void setLine_ups()
        {
            line_up = baza.GetLine_Ups(Film_ID, 0);
        }

        public void setDirector()
        {
            directors = baza.GetLine_Ups(Film_ID, 1);
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
                    film.setPic();
                    film.setLine_ups();
                    film.setDirector();
                }
            }
            return filmy;
        }
    }
}
