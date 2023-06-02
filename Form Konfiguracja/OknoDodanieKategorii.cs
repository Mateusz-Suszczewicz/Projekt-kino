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

namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoDodanieKategorii : Form
    {
        kinoDB baza = new kinoDB(true);
        int id;

        public OknoDodanieKategorii()
        {
            InitializeComponent();
        }

        public void ustawienieID(int id)
        {
            if (id > 0)
            {
                var a = baza.pobranieKategori(id);
                textBox1.Text = a.Item2;
            }
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox1.Text == null) 
            {
                label2.Text = "Nazwa kategorii nie może by c pusta";
                return;
            }
            var a = baza.dodanieKategorii(textBox1.Text, id);

            label2.Text = komunikaty.komunikat[a.Item1];
            id = a.Item2;
        }

    }
}
