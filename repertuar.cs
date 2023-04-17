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

        //List<Control> days = new List<Control>(5);

        public repertuar()
        {
            InitializeComponent();

            ustawienie_aktualnych_dni();

        }


        private void ustawienie_aktualnych_dni()
        {
            DateTime date = DateTime.Now;


            button_repertuar_today.Text = date.Day.ToString() + "." + date.Month.ToString().PadLeft(2, '0') + "\n" + date.DayOfWeek;
            date = date.AddDays(1);
            button_repertuar_tommorow.Text = date.Day.ToString() + "." + date.Month.ToString().PadLeft(2, '0') + "\n" + date.DayOfWeek;
            date = date.AddDays(1);
            button_repertuar_2_days_later.Text = date.Day.ToString() + "." + date.Month.ToString().PadLeft(2, '0') + "\n" + date.DayOfWeek;
            date = date.AddDays(1);
            button_repertuar_3_days_later.Text = date.Day.ToString() + "." + date.Month.ToString().PadLeft(2, '0') + "\n" + date.DayOfWeek;
            date = date.AddDays(1);
            button_repertuar_4_days_later.Text = date.Day.ToString() + "." + date.Month.ToString().PadLeft(2, '0') + "\n" + date.DayOfWeek;


        }

        private void button_repertuar_today_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_today.BackColor = Color.LightSalmon;
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
        }

        private void button_repertuar_2_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_2_days_later.BackColor = Color.LightSalmon;
        }

        private void button_repertuar_3_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_3_days_later.BackColor = Color.LightSalmon;
        }

        private void button_repertuar_4_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_4_days_later.BackColor = Color.LightSalmon;
            button_repertuar_2_days_later.Text = button_repertuar_4_days_later.Text;   
        }

        private void repertuar_Load(object sender, EventArgs e)
        {

        }
    }
}
