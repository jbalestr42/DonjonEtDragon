using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DonjonEtDragon
{
    public partial class Dice : Form
    {
        private int count = 0;
        private int value = 0;
        private int add = 0;
        private int total = 0;
        private List<int> all = new List<int>();

        public Dice()
        {
            InitializeComponent();
        }

        private void btnLance_Click(object sender, EventArgs e)
        {
            LanceDes();
        }

        public string CheckResult(object sender)
        {
            var control = sender as TextBox;
            string text = control.Text;
            if(!text.Contains("d"))
            {
                control.BackColor = Color.Red;
                return "";
            }
            control.BackColor = Color.White;

            return text;
        }

        public void Random()
        {
            int tmp = 0;
            rtbView.Text = "";
            total = 0;
            all.Clear();
            var rnd = new Random();
            for (int i = 0; i < count; ++i)
            {
                tmp = rnd.Next(1, value+1);
                total += tmp;
                all.Add(tmp);
            }
            all.Sort();
            for (int i = 0; i < all.Count; ++i)
                rtbView.Text += all[all.Count-i-1] + "\n";
            lbTotal.Text = "Total : " + total + " + " + add + " = " + (total+add);

            try
            {
                if (double.Parse(tbMultiplicateur.Text) != 0)
                {
                    lblDegat.Text = "Dégats : " + (total + add) + " x " + tbMultiplicateur.Text + " = " + (total * double.Parse(tbMultiplicateur.Text));
                    lblDegatCritique.Text = "Dégats critique : " + (total * double.Parse(tbMultiplicateur.Text)) + " x " + tbcc.Text + " = " + ((total * double.Parse(tbMultiplicateur.Text)) * double.Parse(tbcc.Text));
                }
            }
            catch {}
        }

        private void tbLance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLance_Click(sender, e);
            }
        }

        public void ChangeMultiplicateur(string attaque, string multi, string multiDC)
        {
            try
            {
                string[] tmp = multi.Split('x');
                tbMultiplicateur.Text = tmp[1];
            }
            catch { }
            try
            {
                string[] tmp = multiDC.Split('x');
                tbcc.Text = tmp[1];
            }
            catch { }
            tbLance.Text = attaque;
        }

        private void LanceDes()
        {
            string text = CheckResult(tbLance);

            if (text != "")
            {
                try
                {
                    string[] tab = text.Split('d');
                    count = int.Parse(tab[0]);
                    if (text.Contains('+'))
                    {
                        tab = tab[1].Split('+');
                        value = int.Parse(tab[0]);
                        add = int.Parse(tab[1]);
                    }
                    else
                    {
                        value = int.Parse(tab[1]);
                    }

                    Random();
                }
                catch (Exception)
                { }
            }
        }
    }
}
