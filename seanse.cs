using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    internal class seanse
    {
        protected int SE_ID;
        protected int SE_FilmID;
        protected DateTime SE_DataEmisji;
        protected DateTime SE_DataKonca;

        public int getFilmdID() { return SE_FilmID; }
        public string getGodzinaEmisji() { return SE_DataEmisji.ToString("hh:mm"); }

    }
}