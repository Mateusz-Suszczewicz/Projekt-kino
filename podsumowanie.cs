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
    public partial class podsumowanie : Form
    {
        public podsumowanie()
        {
            InitializeComponent();
            buttons_loads();
        }


        private void podsumowanie_Load(object sender, EventArgs e)
        {
            



        }


        private void buttons_loads()
        {
            label_pods_tytul.Text = "tytul";
            label_pods_tytul.ForeColor = Color.Black;
            label_pods_tytul.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_tytul.Location = new Point(300, 30);

            label_pods_dzien.Text = "dzien";
            label_pods_dzien.ForeColor = Color.Black;
            label_pods_dzien.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_dzien.Location = new Point(300, 80);

            label_pods_godzina.Text = "godzina";
            label_pods_godzina.ForeColor = Color.Black;
            label_pods_godzina.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_godzina.Location = new Point(300, 130);

            label_pods_sala.Text = "sala";
            label_pods_sala.ForeColor = Color.Black;
            label_pods_sala.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_sala.Location = new Point(300, 180);




            //btn.Size = new Size(180, 80);
            //btn.Name = seans.SE_ID.ToString();
        }

    }
}
