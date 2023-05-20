using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    public class seanse
    {
        public int SE_ID { get; set; }
        public int SE_FilmID { get; set; }
        public DateTime SE_DataEmisji;
        public DateTime SE_DataKonca;
        public int SE_SRID;
        public sala sal;

        public void ustawienieSali()
        {
            if(SE_ID > 0 && SE_SRID > 0) {
                sal = new sala(SE_SRID, SE_ID);
            }
        }

        public string getGodzinaEmisji() { return SE_DataEmisji.ToString("HH:mm"); }
        public string getDataEmisji() { return SE_DataEmisji.ToString("dd.MM.yyyy"); }
    }




    

}