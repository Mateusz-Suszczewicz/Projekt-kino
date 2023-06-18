using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoDodaniaSali : Form
    {
        sala sal = new sala();
        bool zmianaMiejsc = false;
        public OknoDodaniaSali()
        {
            InitializeComponent();
        }

        public void ustawienieID(int ID)
        {
            if (ID > 0)
            {
                sala a = new sala(ID, 0);
                sal = a;
                tb_iloscMijesc.Text = sal.SR_maxNrMiejsca.ToString();
                tb_iloscRzedow.Text = sal.SR_maxRowMiejsca.ToString();
                tb_numerSali.Text = sal.SR_Nr.ToString();
                tb_opis.Text = sal.SR_Content;
                zaladowanieMiejsc();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generowanieMiejsc()
        {
            zmianaMiejsc = true;
            panel1.Controls.Clear();
            sal.listaMiejsc = null;
            int maxRowMiejsca = int.Parse(tb_iloscRzedow.Text);
            int maxIloscMijesc = int.Parse(tb_iloscMijesc.Text);
            if (maxRowMiejsca > 15)
            {
                return;
            }
            if (maxRowMiejsca > 10)
            {
                return;
            }
            int start_position = Width / 2 - 25 - 55 * (maxIloscMijesc / 2);
            int position = start_position;
            int h = 220;
            List<miejsce> noweMiejsca = new List<miejsce>();
            for (int r = 0; r < maxRowMiejsca; r++)
            {
                for (int n = 0; n < maxIloscMijesc; n++)
                {
                    miejsce tempMijesce = new miejsce();
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    btn.BackColor = Color.Green;
                    btn.Location = new Point(position, h);
                    panel1.Controls.Add(btn);
                    tempMijesce.Seat_Row = h;
                    tempMijesce.Seat_Nr = position;
                    tempMijesce.status = false;
                    position += 55;
                    noweMiejsca.Add(tempMijesce);

                    //TODO: tutaj jest jakiś problem 
                }
                position = start_position;
                h += 70;
            }
            sal.listaMiejsc = noweMiejsca;
        }

        private void zaladowanieMiejsc()
        {
            panel1.Controls.Clear();
            foreach (miejsce miej in sal.listaMiejsc)
            {
                Button btn = new Button();
                btn.Size = new Size(50, 50);
                btn.Location = new Point(miej.Seat_Nr, miej.Seat_Row);
                panel1.Controls.Add(btn);
                btn.Name = miej.Seat_ID.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generowanieMiejsc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tb_iloscMijesc.Text == "" || tb_iloscMijesc == null)
            {
                label5.Text = "Podaj ilość miejsc";
                return;
            }
            if (tb_iloscRzedow.Text == "" || tb_iloscRzedow == null)
            {
                label5.Text = "Podaj ilość rzędów";
                return;
            }
            if (tb_numerSali.Text == "" || tb_numerSali == null)
            {
                label5.Text = "Podaj numer sali";
                return;
            }
            if (sal.listaMiejsc.Count == 0)
            {
                label5.Text = "wygeneruj miejsca";
                return;
            }
            sal.SR_maxRowMiejsca = int.Parse(tb_iloscRzedow.Text);
            sal.SR_maxNrMiejsca = int.Parse(tb_iloscMijesc.Text);
            sal.SR_Nr = int.Parse(tb_numerSali.Text);
            sal.SR_Content = tb_opis.Text;
            var a = Program.baza.modyfikacjaSali(sal, zmianaMiejsc);
            label5.Text = komunikaty.komunikat[a.Item1];
            sal.SR_ID = a.Item2;

            zaladowanieMiejsc();

        }

        private void tb_iloscRzedow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
