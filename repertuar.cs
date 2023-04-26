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
            dodanie_filmu_do_repertuaru(dates[0]);
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
            dodanie_filmu_do_repertuaru(dates[0]);
        }

        private void button_repertuar_tommorow_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_tommorow.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            dodanie_filmu_do_repertuaru(dates[1]);
        }

        private void button_repertuar_2_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_2_days_later.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            dodanie_filmu_do_repertuaru(dates[2]);
        }

        private void button_repertuar_3_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_3_days_later.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            dodanie_filmu_do_repertuaru(dates[3]);
        }

        private void button_repertuar_4_days_later_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(4);
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_4_days_later.BackColor = Color.LightSalmon;
            flowLayoutPanel_repertuar.Controls.Clear();
            dodanie_filmu_do_repertuaru(dates[4]);

        }
        private void dodanie_filmu_do_repertuaru(DateTime date)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.AliceBlue;
            panel.Size = new Size(flowLayoutPanel_repertuar.ClientSize.Width - 7, 300);
            
            Filmy fm = new Filmy();
            List<Filmy>? ListaFilmow = fm.getFilmOnDay(date);
            
            if (ListaFilmow != null)
            {
                foreach (var film in ListaFilmow)
                {
                    //TYTUL string Film_Title
                    panel.Controls.Add(new LinkLabel
                    {
                        Text = film.Film_Title,
                        LinkColor = Color.Black,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        AutoSize = true,
                    });

                    // JEZYK string Film_Language
                    panel.Controls.Add(new Label
                    {
                        Text = film.Film_Language,
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        AutoSize = true,
                        Left = flowLayoutPanel_repertuar.ClientSize.Width - 300,

                    });

                    // CZAS TRWANIA int Film_Duration,
                    panel.Controls.Add(new Label
                    {
                        Text = film.Film_Duration.ToString() + " " + " MIN",
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        AutoSize = true,
                        Left = flowLayoutPanel_repertuar.ClientSize.Width - 160,
                    });;

                    flowLayoutPanel_repertuar.Controls.Add(panel);
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
    }
}
