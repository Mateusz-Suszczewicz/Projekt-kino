using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    internal class bilet
    {
        public int seance_ID = 0;
        public List<int> Seat_ID = null;
        public Operator Operator = null;
        
        public bool kupBilet()
        {
            // weryfikacja danych 
            if(Operator == null) { return false; }
            if(seance_ID == 0) { return false; }
            if(Seat_ID == null) { return false; }

            // sprawdznie miejsca

            // dodanie biletu
            // sprawdzenie dodania biletu
            return true;
        }
    }
}
