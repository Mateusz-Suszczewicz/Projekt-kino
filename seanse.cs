﻿using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    internal class seanse
    {
        public int SE_ID;
        public int SE_FilmID { get; set; }
        public DateTime SE_DataEmisji;
        public DateTime SE_DataKonca;
        public int SE_SRID;

        public string getGodzinaEmisji() { return SE_DataEmisji.ToString("hh:mm"); }
    }
}