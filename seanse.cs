using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    internal class seanse : Filmy
    {
        protected string? SE_ID;
        protected DateTime? SE_DataEmisji;

        public List<seanse> seanses(DateTime data)
        {
            List<seanse> a;
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
            a = baza.getseance(data);
            foreach (seanse seanse in a)
            {
                seanse.setCategory();
            }
            return a;
        }
    }
}
