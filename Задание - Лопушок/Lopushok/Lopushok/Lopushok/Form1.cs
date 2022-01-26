using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lopushok
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this) { Visible = false };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            form2.Visible = true;
        }
        private Form3 form3;
        private void button2_Click(object sender, EventArgs e)
        {
            form3 = new Form3(this) { Visible = false };
            this.Visible = false;
            form3.Visible = true;
        }
    }
}
