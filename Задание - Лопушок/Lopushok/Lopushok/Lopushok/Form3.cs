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
    public partial class Form3 : Form
    {
        Model1 db = new Model1();
        private Form1 _form1;
        public Form3(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3Edit form = new Form3Edit();
            form.db = db;
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                materialBindingSource.DataSource = db.Materials.ToList();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Material mtr = (Material)materialBindingSource.Current;
            DialogResult dr = MessageBox.Show(
                "Вы действительно хотите удалить номер - " + mtr.ID.ToString(),
                "Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Materials.Remove(mtr);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                materialBindingSource.DataSource = db.Materials.ToList();
            }
        }
    }
}
