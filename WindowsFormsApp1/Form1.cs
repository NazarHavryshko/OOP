using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int x = 5;
            int y = 10;
            this.label1.Text = "5 + 10 = " + (x + y);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
