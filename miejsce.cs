using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    public class miejsce
    {
        public int Seat_ID;
        public int Seat_Nr;
        public int Seat_Row;
        public bool status;
        // status -> true -> zajęte

        public miejsce() { }
        public miejsce (int id)
        {
            kinoDB baza = new kinoDB(true);
            miejsce a = baza.pobranieMiejsca(id);
            Seat_ID = a.Seat_ID;
            Seat_Nr = a.Seat_Nr;
            Seat_Row = a.Seat_Row;
            status = a.status;
        }
    }
}
