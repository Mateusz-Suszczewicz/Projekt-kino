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

        private void dodanie_filmu_do_repertuaru(object sender, EventArgs e,
            string Film_Title,
            //string Film_Content,
            //DateTime Film_DataDodania,
            //int Film_CatID,
            int Film_Duration,
            //int Film_ID,
            string Film_Language
            //string Film_Production,
            //string Film_Translation
            //List<string>? Film_Cateogry = null,
            )
        {
            Panel panel = new Panel();

            panel.BackColor = Color.AliceBlue;
            panel.Size = new Size(flowLayoutPanel_repertuar.ClientSize.Width - 7, 300);

            //TYTUL string Film_Title
            panel.Controls.Add(new LinkLabel
            {
                Text = Film_Title,
                LinkColor = Color.Black,
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
            });

            // JEZYK string Film_Language
            panel.Controls.Add(new Label
            {
                Text = Film_Language,
                ForeColor = Color.Black,
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Left = flowLayoutPanel_repertuar.ClientSize.Width - 300,
                //Left = 1000,

            });

            // CZAS TRWANIA int Film_Duration,
            panel.Controls.Add(new Label
            {
                Text = Film_Duration.ToString() + " " + " MIN",
                ForeColor = Color.Black,
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Left = flowLayoutPanel_repertuar.ClientSize.Width - 160,
                //Left = 1200,
            });

            flowLayoutPanel_repertuar.Controls.Add(panel);

        }

        private void button_repertuar_4_days_later_Click(object sender, EventArgs e)
        {
            zmiana_kolorow_przyciskow_dni();
            button_repertuar_4_days_later.BackColor = Color.LightSalmon;

            dodanie_filmu_do_repertuaru(sender, e, "terminator", 126, "DUB PL");

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
