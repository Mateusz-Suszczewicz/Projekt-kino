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
    public partial class repertuar : Form
    {

        //List<Control> days = new List<Control>;
        List<DateTime> dates = new List<DateTime>();
        public repertuar()
        {
            InitializeComponent();
            ustawienie_aktualnych_dni();
            Filmy film = new Filmy();
            List<Filmy>? ListaFilmow = film.getFilmOnDay(dates[0]);
            if (ListaFilmow != null)
            {
                foreach (var a in ListaFilmow)
                {
                    
                    dodanie_filmu_do_repertuaru(a);
                }
            }
        }


        private void ustawienie_aktualnych_dni()
        {
            DateTime date = DateTime.Now;
            dates.Add(date);
            date = date.AddSeconds(60 - date.Second);
            date = date.AddMinutes(60 - date.Minute);
            date = date.AddHours(24 - date.Hour);
            for (int i = 0; i < 5; i++)
            {
                dates.Add(date);
                date = date.AddDays(1);

            }
            button_repertuar_today.Text = dates[0].Day.ToString() + "." + dates[0].Month.ToString().PadLeft(2, '0') + "\n" + dates[0].DayOfWeek;
            button_repertuar_tommorow.Text = dates[1].Day.ToString() + "." + dates[1].Month.ToString().PadLeft(2, '0') + "\n" + dates[1].DayOfWeek;
            button_repertuar_2_days_later.Text = dates[2].Day.ToString() + "." + dates[2].Month.ToString().PadLeft(2, '0') + "\n" + dates[2].DayOfWeek;
            button_repertuar_3_days_later.Text = dates[3].Day.ToString() + "." + dates[3].Month.ToString().PadLeft(2, '0') + "\n" + dates[3].DayOfWeek;
            button_repertuar_4_days_later.Text = dates[4].Day.ToString() + "." + dates[4].Month.ToString().PadLeft(2, '0') + "\n" + dates[4].DayOfWeek;


        }

        private void button_repertuar_today_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_today.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            Filmy film = new Filmy();
            List<Filmy>? ListaFilmow = film.getFilmOnDay(dates[0]);
            if (ListaFilmow != null)
            {
                foreach (var a in ListaFilmow)
                {
                    dodanie_filmu_do_repertuaru(a);
                }
            }
        }

        private void zmiana_kolorow_przyciskow_dni()
        {
            button_repertuar_today.BackColor = Color.IndianRed;
            button_repertuar_tommorow.BackColor = Color.IndianRed;
            button_repertuar_2_days_later.BackColor = Color.IndianRed;
            button_repertuar_3_days_later.BackColor = Color.IndianRed;
            button_repertuar_4_days_later.BackColor = Color.IndianRed;

        }

        private void button_repertuar_tommorow_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_tommorow.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            Filmy film = new Filmy();
            List<Filmy>? ListaFilmow = film.getFilmOnDay(dates[1]);
            if (ListaFilmow != null)
            {
                foreach (var a in ListaFilmow)
                {
                    dodanie_filmu_do_repertuaru(a);
                }
            }
        }

        private void button_repertuar_2_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_2_days_later.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            Filmy film = new Filmy();
            List<Filmy>? ListaFilmow = film.getFilmOnDay(dates[2]);
            if (ListaFilmow != null)
            {
                foreach (var a in ListaFilmow)
                {
                    dodanie_filmu_do_repertuaru(a);
                }
            }
        }

        private void button_repertuar_3_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_3_days_later.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            Filmy film = new Filmy();
            List<Filmy>? ListaFilmow = film.getFilmOnDay(dates[3]);
            if (ListaFilmow != null)
            {
                foreach (var a in ListaFilmow)
                {
                    dodanie_filmu_do_repertuaru(a);
                }
            }
        }

        private void dodanie_filmu_do_repertuaru(
            Filmy film
            //string Film_Title,
            ////string Film_Content,
            ////DateTime Film_DataDodania,
            ////int Film_CatID,
            //int Film_Duration,
            ////int Film_ID,
            //string Film_Language
            ////string Film_Production,
            ////string Film_Translation
            ////List<string>? Film_Cateogry = null,
            )
        {
            var a = film.getSeanse();
            Panel panel = new Panel();
            panel.BackColor = Color.AliceBlue;
            panel.Size = new Size(flowLayoutPanel_repertuar.ClientSize.Width - 7, 300);

            //TYTUL string Film_Title
            panel.Controls.Add(new LinkLabel
            {
                Text = film.getTitle(),
                LinkColor = Color.Black,
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
            });

            // JEZYK string Film_Language
            panel.Controls.Add(new Label
            {
                Text = film.getLanguage(),
                ForeColor = Color.Black,
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Left = flowLayoutPanel_repertuar.ClientSize.Width - 300,
                //Left = 1000,

            });

            // CZAS TRWANIA int Film_Duration,
            panel.Controls.Add(new Label
            {
                Text = film.getDuration().ToString() + " " + " MIN",
                
                //Text = a[0].getGodzinaEmisji(),
                ForeColor = Color.Black,
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Left = flowLayoutPanel_repertuar.ClientSize.Width - 160,
                //Left = 1200,
            });;

            flowLayoutPanel_repertuar.Controls.Add(panel);

        }

        private void button_repertuar_4_days_later_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(4);
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_4_days_later.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            Filmy film = new Filmy();
            List<Filmy>? ListaFilmow = film.getFilmOnDay(dates[4]);
            if (ListaFilmow != null)
            {
                foreach (var a in ListaFilmow)
                {
                    dodanie_filmu_do_repertuaru(a);
                }
            }

        }

        private void repertuar_Load(object sender, EventArgs e)
        {

        }


        private void flowLayoutPanel_repertuar_Paint(object sender, PaintEventArgs e)
        {

        }


        private void textBox_rep_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_repertuar_film_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_repertuar_film_tytul_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
