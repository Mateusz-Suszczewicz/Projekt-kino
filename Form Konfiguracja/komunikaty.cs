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
            { 4, "Błąd krytyczny. Skontaktuj się z Administratorem ( albo sam napraw :D )" },
            { 5, "zmodyfikowano operatora" },
            { 6, "Kategoria już istnieje" },
            { 7, "Nie ma takiego id kategorii" },
            { 8, "Zmodyfikowano kategorię" },
            { 9, "Dodano kategorię" },
            { 10, "numer sali jest wykorzystywany" },
            { 11, "Sala jest dodana do seansu" },
            { 12, "Miejsce jest już wykupione" },
            { 13, "Błąd usunięcia" },
            { 14, "poprawnie usunięto" },
            { 15, "kategoria jest w użyciu" },
            { 16, "Błąd dodaniwa miejsca" },
            { 17, "Błąd aktualizacji sali" },
            { 18, "Błąd dodania sali" },
            { 19, "poprawnie dodano salę" },
            { 20, "Błąd usunięcia powiązań" },
            { 21, "Poprawnie zaktualizowano kategorię" },
            { 22, "Film ma już zdjęcie główne" },
            { 23, "Poprawnie dodano zdjęcie" },
            { 24, "Błąd dodania zdjęcia" },
            { 24, "Poprawnie zaktualizowano zdjęcie" },
            { 25, "Aktor jest dodany do filmu" },
            { 26, "Podane Id aktora nie istnieje" },
            { 27, "Poprawne usunięcie aktora" },
            { 28, "Aktor o takim imieniu i nazwisku już istnieje" },
            { 29, "Poprawnie dodano aktora" },
            { 30, "Poprawnie zmodyfikowano aktora" },
            { 31, "Sala jest wykorzytywana do seansu" },
            { 32, "Miejsce zostało wykupione" },
        };
    }
}
