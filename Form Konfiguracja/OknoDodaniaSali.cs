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
            int start_position = Width / 2 - 25 - 55 * (maxIloscMijesc / 2);
            int position = start_position;
            int h = 220;
            List<miejsce> noweMiejsca = new List<miejsce>();
            miejsce tempMijesce = new miejsce();
            for (int r = 0; r < maxRowMiejsca; r++)
            {
                for (int n = 0; n < maxRowMiejsca; n++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    btn.BackColor = Color.Green;
                    btn.Location = new Point(position, h);
                    panel1.Controls.Add(btn);
                    position += 55;
                    tempMijesce.Seat_Row = h;
                    tempMijesce.Seat_Nr = position;
                    tempMijesce.status = false;
                }
                noweMiejsca.Add(tempMijesce);
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
            sal.SR_maxRowMiejsca = int.Parse(tb_iloscRzedow.Text);
            sal.SR_maxNrMiejsca = int.Parse(tb_iloscMijesc.Text);
            sal.SR_Nr = int.Parse(tb_numerSali.Text);
            sal.SR_Content = tb_opis.Text;
            if(sal.listaMiejsc.Count == 0) { return; }
            Program.baza.modyfikacjaSali(sal, zmianaMiejsc);
            zaladowanieMiejsc();
            
        }
    }
}
