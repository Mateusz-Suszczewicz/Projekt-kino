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
    public partial class OknoDodaniaZdjecia : Form
    {
        int filmid;
        int picId;
        public OknoDodaniaZdjecia()
        {
            InitializeComponent();
        }

        public void ustawID(int filmid, int picId = -1)
        {
            this.filmid = filmid;
            this.picId = picId;
            if (picId != -1)
            {
                var temp = Program.baza.pobranieZdjecia(picId);
                textBox1.Text = temp.Item1;
                checkBox1.Checked = temp.Item2 == 1 ? true : false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                label2.Text = "Ścieżka musi być uzupełniona";
                return;
            }
            int mainPic;
            mainPic = checkBox1.Checked ? 1 : 0;
            label2.Text = komunikaty.komunikat[Program.baza.dodajZdjecie(textBox1.Text, mainPic, filmid)];
        }
    }
}
