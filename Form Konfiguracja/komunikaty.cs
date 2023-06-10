using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_kino
{
    public class komunikaty
    {
        public static Dictionary<int, string> komunikat = new Dictionary<int, string>()
        {
            { 1, "Login juz istnieje w bazie" },
            { 2, "Nie ma takiego id operatora" },
            { 3, "Dodano operatora" },
            { 4, "Błąd krytyczny" },
            { 5, "zmodyfikowano operatora" },
            { 6, "Kategoria już istanieje" },
            { 7, "Nie ma takiego id kategorii" },
            { 8, "Zmodyfikowano kategorię" },
            { 9, "Dodano kategorię" },
        };
    }
}
