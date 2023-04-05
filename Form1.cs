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
            if (!a.ConnectionString("DESKTOP-I45S3D6", 1, "kino", "sa", "123"))
            {
                textBox1.Text = "nie dzia³a";
            }
            //a.PolaczenieDoBazyZRejestru();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = a.CreateTable();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}