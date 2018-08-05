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
    public partial class AddItem : Form
    {
        private static Main main;

        public AddItem(Main _main)
        {
            InitializeComponent();
            main = _main;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNom.Text != "")
                {
                    Objet objet = new Objet()
                                      {
                                          Nom = tbNom.Text,
                                          Agilite = IsInt(tbAgilite),
                                          Defense = IsInt(tbDefense),
                                          Endurance = IsInt(tbEndurance),
                                          Esprit = IsInt(tbEsprit),
                                          Force = IsInt(tbForce),
                                          Initiative = IsInt(tbInitiative)
                                      };

                    if (objet != null)
                    {
                        main.ObjetRecu(objet);
                        this.Close();
                    }
                }
            }
            catch {}
        }

        private int IsInt(object sender)
        {
            var control = sender as Control;
            int outD;

            if (control.Text == "")
            {
                control.BackColor = Color.White;
                return 0;
            }
            if (int.TryParse(control.Text, out outD))
            {
                control.BackColor = Color.White;
                return (int)outD;
            }
            control.BackColor = Color.Red;
            return 0;
        }
    }
}
