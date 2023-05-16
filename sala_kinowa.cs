using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino
{
    public partial class sala_kinowa : Form
    {
        Filmy Film;
        public sala_kinowa()
        {
            InitializeComponent();
        }

        public void get_details(string id)
        {
            var seanceID = int.Parse(id);
            Film = new Filmy(seanceID, false);
            Film.setSeanse(DateTime.Now, seanceID);

            sala_kinowa_Load();
        }


        private void sala_kinowa_Load()
        {
            label1.Text = "id: " + Film.seanses[0].SE_SRID +
                          " id miejsca: " + Film.seanses[0].sal.listaMiejsc[0].Seat_ID;// +
                          //" data: " + Film.seanses[0].getDataEmisji();// +
                          //" godzina: " + Film.seanses[0].getGodzinaEmisji();
            label1.Font = new Font("Arial", 16, FontStyle.Bold);
        }


    }
}
