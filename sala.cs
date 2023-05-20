using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    public class sala
    {
        public int SR_ID;
        public int SR_maxNrMiejsca;
        public int SR_maxRowMiejsca;
        public int SR_Nr;
        public string SR_Content;
        public string SR_Name;
        public List<miejsce> listaMiejsc;
        private kinoDB baza = new kinoDB(true);
        
        public sala() {}
        public sala(int srID, int seid)
        {
            SR_ID = srID;
            listaMiejsc = baza.pobranieMiejsc(SR_ID, seid);
            sala a = baza.pobranieSali(SR_ID);
            this.SR_maxNrMiejsca = a.SR_maxNrMiejsca;
            this.SR_maxRowMiejsca = a.SR_maxRowMiejsca;
            this.SR_Nr = a.SR_Nr;
            this.SR_Content = a.SR_Content;
            this.SR_Name = a.SR_Name;
        }
    }
}
