using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    internal class sala
    {
        public int SR_ID;
        public int SR_maxNrMiejsca;
        public int maxRowMiejsca;
        public int SR_Nr;
        public string SR_Content;
        public string SR_Name;
        public List<miejsce> listaMiejsc;
        private kinoDB baza = new kinoDB(true);

        public sala(int srID, int seid)
        {
            SR_ID = srID;
            baza.pobranieMiejsc(SR_ID, seid);
            baza.pobranieSali(SR_ID);
        }
    }
}
