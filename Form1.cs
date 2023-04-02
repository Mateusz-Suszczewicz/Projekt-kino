using kino;
using Microsoft.VisualBasic.Logging;
using System.Data.SqlClient;
using System.Data;
using System;
using static System.Net.Mime.MediaTypeNames;


namespace Projekt_kino
{
    public partial class Form1 : Form
    {
        kinoDB a = new kinoDB();

        public Form1()
        {
            InitializeComponent();
            if (!a.ConnectionString("LAPTOP-VHVG8IJE", 1, "KINO", "sa", ""))
            {
                textBox1.Text = "nie dzia³a";
            }
            a.PolaczenieDoBazyZRejestru();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = a.CreateTable();

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void przycisk_konto_Click(object sender, EventArgs e)
        {

        }
    }
}