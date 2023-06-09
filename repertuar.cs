﻿using kino;
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
        //private System.Windows.Forms.LinkLabel LinkLabel1;
        DateTime data;

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


        //private void Tytul_Click(object? sender, EventArgs e)
        //{
        //    string title = sender.ToString();
        //    textBox_rep.Text = title.Split(':', 2).Last();
        //}


        private void dodanie_filmu_do_repertuaru(DateTime date)
        {
            data = date;

            Filmy fm = new Filmy();
            List<Filmy>? ListaFilmow = fm.getFilmOnDay(date);

            if (ListaFilmow != null)
            {
                foreach (var film in ListaFilmow)
                {

                    Panel panel = new Panel();
                    panel.BackColor = Color.AliceBlue;
                    panel.Size = new Size(1334, 400);

                    //TYTUL string Film_Title
                    panel.Controls.Add(new Label
                    {
                        Text = film.Film_Title,
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        AutoSize = true
                    });


                    // KRAJ PRODUKCJI string Film_Production
                    panel.Controls.Add(new Label
                    {
                        Text = film.Film_Production,
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        AutoSize = true,
                        Top = 40,
                        //Left = flowLayoutPanel_repertuar.ClientSize.Width - 300,
                        Left = 320,

                    });

                    // JEZYK string Film_Language
                    panel.Controls.Add(new Label
                    {
                        Text = film.Film_Language,
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        AutoSize = true,
                        Top = 40,
                        Left = 600

                    });

                    // CZAS TRWANIA int Film_Duration,
                    panel.Controls.Add(new Label
                    {
                        Text = film.Film_Duration.ToString() + " " + " MIN",
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        AutoSize = true,
                        Top = 40,
                        Left = 500
                    }); ;

                    // OPIS string Film_Content
                    panel.Controls.Add(new Label
                    {
                        Text = film.Film_Content,
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 14),
                        //AutoSize = true,
                        Size = new Size(flowLayoutPanel_repertuar.ClientSize.Width - 350, 200),
                        TextAlign = ContentAlignment.TopLeft,
                        Top = 80,
                        Left = 320,
                    });

                    // PRZYCISK REZERWACJA
                    Button btn = new Button
                    {
                        Text = "REZERWUJ",
                        ForeColor = Color.Black,
                        BackColor = Color.LightSalmon,
                        Font = new Font("Arial", 16),
                        //Location = new Point(flowLayoutPanel_repertuar.Width - 200, 405),
                        Left = flowLayoutPanel_repertuar.Width - 220,
                        Top = 305,
                        Size = new Size(180, 80),
                        Name = film.Film_ID.ToString(),

                    };



                    btn.Click += wywołanie_okna_szczegolow;

                    panel.Controls.Add(btn);
                    // Obrazek :D -> pierwszy na liście jest obrazkiem nagłówkowym w bazie danych dodalem kolumnę z kolejnością po której sortuje
                    if (film.Pic_Src.Count != 0)
                    {
                        panel.Controls.Add(new PictureBox
                        {
                            Image = Image.FromFile(film.Pic_Src[0].Item2),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Top = 40,
                            Left = 5,
                            Size = new Size(280, 350),
                        });
                    }

                    //dodawanie seansów
                    //foreach(var a in film.seanses)
                    //{
                    //    textBox_rep.Text = a.getGodzinaEmisji();
                    //}

                    flowLayoutPanel_repertuar.Controls.Add(panel);
                }
            }
        }
        private void wywołanie_okna_szczegolow(object sender, EventArgs eventArgs)
        {

            Button button = (Button)sender;
            string film_id = button.Name;

            Film_szczegoly fs = new Film_szczegoly();
            fs.getFIlmId(film_id, data);
            this.Hide();
            fs.ShowDialog(this);
            fs.Close();
            this.Close();
        }


        private void zmiana_kolorow_przyciskow_dni()
        {
            button_repertuar_today.BackColor = Color.IndianRed;
            button_repertuar_tommorow.BackColor = Color.IndianRed;
            button_repertuar_2_days_later.BackColor = Color.IndianRed;
            button_repertuar_3_days_later.BackColor = Color.IndianRed;
            button_repertuar_4_days_later.BackColor = Color.IndianRed;
        }

        private void flowLayoutPanel_repertuar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
