using Dapper;
using kino;
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
        List<int> miejscaDoKupienia = new List<int>();
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
            sala_kinowa_dodanie_miejsc(Film.seanses[0].sal);
            button_final.Enabled = false;
        }


        private void sala_kinowa_Load()
        {
            //label1.Text = "id: " + Film.seanses[0].SE_SRID + " id miejsca: " + Film.seanses[0].sal.listaMiejsc[0].Seat_ID;
            //+
            //              " data: " + Film.seanses[0].getDataEmisji() +
            //              " godzina: " + Film.seanses[0].getGodzinaEmisji();
            //label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Text = Film.Film_Title + " | " + Film.seanses[0].getDataEmisji() + " | " + Film.seanses[0].getGodzinaEmisji();
            label1.Font = new Font("Arial", 16, FontStyle.Bold);
        }

        private void sala_kinowa_Load(object sender, EventArgs e)
        {

        }

        private void label_ekran_Click(object sender, EventArgs e)
        {

        }

        private void sala_kinowa_dodanie_miejsc(sala sal)
        {
            sal.SR_maxRowMiejsca = 10;
            sal.SR_maxNrMiejsca = 10;
            int w = Width;
            int h = 220;
            int start_position = Width / 2 - 25 - 55 * (sal.SR_maxNrMiejsca / 2);
            int position = start_position;
            label_ekran.Text = (sal.SR_maxNrMiejsca / 2).ToString() + "  " + start_position.ToString();
            label_ekran.Text = "EKRAN";

            //for (int r = 0; r < sal.SR_maxRowMiejsca; r++)
            //{
            //    for (int n = 0; n < sal.SR_maxNrMiejsca; n++)
            //    {
            //        Button btn = new Button();
            //        btn.Size = new Size(50, 50);
            //        btn.BackColor = Color.Green;
            //        btn.Location = new Point(position, h);
            //        Controls.Add(btn);
            //        position += 55;
            //        btn.Click += dodanie_id_miejsca;
            //        btn.Text = $"{position} -- {h}";
            //        //btn.Text = seans.getGodzinaEmisji();
            //        //btn.ForeColor = Color.Black;
            //        //btn.Font = new Font("Arial", 14, FontStyle.Bold);
            //        //btn.Name = seans.SE_ID.ToString();

            //        //kinoDB baza = new kinoDB(true);
            //        //string query = $"INSERT INTO dbo.seats (Seat_SRID, Seat_Nr, Seat_Row) VALUES (1,{position},{h})";
            //        //try
            //        //{
            //        //    baza.conn.Execute(query);
            //        //}
            //        //catch (Exception ex) { throw ex; }
            //    }
            //    position = start_position;
            //    h += 70;
            //}

            foreach (miejsce miej in sal.listaMiejsc)
            {

                Button btn = new Button();
                btn.Size = new Size(50, 50);
                btn.BackColor = Color.Green;
                if (miej.status)
                {
                    btn.BackColor = Color.Red;
                    btn.Enabled = false;
                }
                btn.Location = new Point(miej.Seat_Nr, miej.Seat_Row);
                Controls.Add(btn);
                btn.Name = miej.Seat_ID.ToString();
                btn.Click += dodanie_id_miejsca;
            }

        }




        private void label_ekran_Click_1(object sender, EventArgs e)
        {

        }

        private void dodanie_id_miejsca(object sender, EventArgs e)
        {
            Control ctrl = ((Control)sender);
            if (ctrl.BackColor == Color.Orange)
            {
                ctrl.BackColor = Color.Green;
                miejscaDoKupienia.Remove(int.Parse(ctrl.Name));
                if (miejscaDoKupienia.Count == 0)
                {
                    button_final.Enabled = false;
                }
            }
            else
            {
                ctrl.BackColor = Color.Orange;
                var a = ctrl.Name;
                var b = int.Parse(a);
                miejscaDoKupienia.Add(b);
                button_final.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_final_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Program.zalogowanyOperator == null)
            {
                Form1 form = new Form1();
                form.logowanie();
                form.ShowDialog();
            }
            podsumowanie pods = new podsumowanie();
            pods.zaladowanie_danych(miejscaDoKupienia, Film);
            pods.ShowDialog();
            this.Close();
        }
    }
}
