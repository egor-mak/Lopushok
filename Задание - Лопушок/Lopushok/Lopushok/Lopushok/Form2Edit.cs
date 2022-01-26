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
    public partial class Form2Edit : Form
    {
        public Model1 db { get; set; }
        public Form2Edit()
        {
            InitializeComponent();
        }
        private void Form2Edit_Load(object sender, EventArgs e)
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
                MessageBox.Show("Неверно введено кол-во человек - " + textBox4.Text);
                return;
            }
            int age;
            bool a = int.TryParse(textBox5.Text, out age);
            if (a == false)
            {
                MessageBox.Show("Неверно введено число цехов - " + textBox5.Text);
                return;
            }
            decimal eg;
            bool x = decimal.TryParse(textBox5.Text, out eg);
            if (x == false)
            {
                MessageBox.Show("Неверно введена минимальная плата - " + textBox5.Text);
                return;
            }
            Product prod = new Product();
            prod.ID = id;
            prod.Title = textBox2.Text;
            prod.ArticleNumber = textBox3.Text;
            prod.ProductionPersonCount = cg;
            prod.ProductionWorkshopNumber = age;
            prod.MinCostForAgent = eg;
            db.Products.Add(prod);
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
        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
