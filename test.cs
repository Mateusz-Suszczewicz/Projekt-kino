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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        public void c (DataGridView d)
        {
            dataGridView1 = d;
            dataGridView1.Refresh();
            dataGridView1.Update();
        }
    }
}
