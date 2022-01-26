using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lopushok.ModelEF;

namespace Lopushok
{
    public partial class Form3Edit : Form
    {
        public Model1 db { get; set; }
        public Form3Edit()
        {
            InitializeComponent();
        }
        private void Form3Edit_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || textBox2.Text == " ")
            {
                MessageBox.Show("Нужно ввести все требуемые данные!");
                return;
            }
            int id;
            bool b = int.TryParse(textBox1.Text, out id);
            if (b == false)
            {
                MessageBox.Show("Неверный формат ID - " + textBox1.Text);
                return;
            }
            int cg;
            bool c = int.TryParse(textBox4.Text, out cg);
            if (b == false)
            {
                MessageBox.Show("Неверно введено кол-во человек - " + textBox3.Text);
                return;
            }
            int age;
            bool a = int.TryParse(textBox5.Text, out age);
            if (a == false)
            {
                MessageBox.Show("Неверно введено количество на складе - " + textBox5.Text);
                return;
            }
            decimal eg;
            bool x = decimal.TryParse(textBox5.Text, out eg);
            if (x == false)
            {
                MessageBox.Show("Неверно введена цена - " + textBox7.Text);
                return;
            }
            double v;
            bool s = double.TryParse(textBox6.Text, out v);
            if (s == false)
            {
                MessageBox.Show("Неверно введена минимальная плата - " + textBox6.Text);
                return;
            }
            Material mtr = new Material();
            mtr.ID = id;
            mtr.Title = textBox2.Text;
            mtr.CountInPack = cg;
            mtr.Unit = textBox4.Text;
            mtr.CountInStock = age;
            mtr.MinCount = v;
            mtr.Cost = eg;
            db.Materials.Add(mtr);
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}