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
        public int SE_FilmID { get; set; }
        protected DateTime SE_DataEmisji;
        protected DateTime SE_DataKonca;

        public string getGodzinaEmisji() { return SE_DataEmisji.ToString("hh:mm"); }
    }
}