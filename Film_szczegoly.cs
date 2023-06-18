using kino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino
{
    public partial class Film_szczegoly : Form
    {
        Filmy Film;
        public Film_szczegoly()
        {
            InitializeComponent();
        }

        public void getFIlmId(string Film_id, DateTime data)
        {
            var FilmId = int.Parse(Film_id);

            Film = new Filmy(FilmId);
            Film.setSeanse(data);
            dodanie_szczegolow();
        }


        public void dodanie_szczegolow()
        {
            #region Film_Title

            label1.Text = Film.Film_Title;
            label1.ForeColor = Color.Black;
            label1.Font = new Font("Arial", 16, FontStyle.Bold);

            #endregion

            #region Film_Content

            label2.Text = Film.Film_Content;
            label2.ForeColor = Color.Black;
            label2.Font = new Font("Arial", 14);
            label2.Size = new Size(800, 400);
            label2.AutoSize = false;
            label2.TextAlign = ContentAlignment.TopLeft;

            #endregion

            #region Film_Duration

            label3.Text = "Czas trwania: " + Film.Film_Duration / 60 + " godz. " + Film.Film_Duration % 60 + " min. (" + Film.Film_Duration + " min)";
            label3.Font = new Font("Arial", 14);

            #endregion

            #region Film_Language

            label4.Text = "           Język: " + Film.Film_Language;
            label4.Font = new Font("Arial", 14);

            #endregion

            #region Film_Production

            label5.Text = "    Produkcja: " + Film.Film_Production;
            label5.Font = new Font("Arial", 14);

            #endregion

            #region Film_Category
            label6.Text = "     Kategoria: ";
            label6.Font = new Font("Arial", 14);
            foreach ((int, string) kat in Film.Film_Cateogry)
            {
                label6.Text += kat.Item2 + ", ";
            }
            label6.Text = label6.Text.Remove(label6.Text.Length - 2);


            #endregion

            //foreach (var seans in Film.seanses)
            //{
            //    seans.getGodzinaEmisji();
            //}
            #region Przycisky godzin

            //List<string> godziny = new List<string> { "9:20", "10:40", "12:15", "15:20", "17:40", "20:15" };

            int w = 300;
            int h = 500;
            foreach (var seans in Film.seanses)
            {
                Button btn = new Button();
                btn.Text = seans.getGodzinaEmisji();
                btn.ForeColor = Color.Black;
                btn.BackColor = Color.Transparent;
                btn.Font = new Font("Arial", 14, FontStyle.Bold);
                btn.Location = new Point(w, h);
                btn.Size = new Size(180, 80);
                btn.Name = seans.SE_ID.ToString();
                Controls.Add(btn);
                if (w < 900)
                    w += 200;
                else { w = 300; h += 100; }

                btn.Click += wywolanie_okna_sali;
            }


            #endregion

            #region zdjęcie 

            pictureBox1.Image = Image.FromFile(Film.Pic_Src[0].Item2);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            #endregion
        }


        private void wywolanie_okna_sali(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string godzina_seansu = button.Text;
            string id = button.Name;

            sala_kinowa sk = new sala_kinowa();
            sk.get_details(id);
            this.Hide();
            sk.ShowDialog(this);
            sk.Close();
            this.Close();
        }

        private void Film_szczegoly_Load(object sender, EventArgs e)
        {

        }


        // tutaj działasz juz na zmiennej Film 

    }
}
