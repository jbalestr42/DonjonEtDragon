using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DonjonEtDragon
{
    public partial class FicPerso : UserControl
    {
        public Perso perso = new Perso();
        List<Objet> l = new List<Objet>();
        private int[] tabExp = new int[51];
        private bool init = false;
        public string multi = "";
        public string multiDC = "";
        public string attaque = "";

        public FicPerso() {
            InitializeComponent();
            Experience();
            bindingSourceObjets.DataSource = l;
        }

        #region Events
        public delegate void NomTextChangedEventHandler(object sender);
        public event NomTextChangedEventHandler NomTextChanged;

        public void OnTextChanged()
        {
            NomTextChangedEventHandler handler = NomTextChanged;
            if (handler != null) handler(tbNom);
        }
        #endregion

        #region Events GUI
        private void dgvInventaire_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateObjets();
        }

        private void dgvInventaire_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateObjets();
        }

        // Nom
        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            perso.Nom = tbNom.Text;
            OnTextChanged();
        }

        // Race
        private void cbRace_TextChanged(object sender, EventArgs e)
        {
            perso.Race = cbRace.Text;
        }

        // Classe
        private void cbClasse_TextChanged(object sender, EventArgs e)
        {
            if (cbClasse.Text == "Soldat" || cbClasse.Text == "Guerrier" || cbClasse.Text == "Barbare" ||
                cbClasse.Text == "Fourbe" || cbClasse.Text == "Voleur" || cbClasse.Text == "Assassin" ||
                     cbClasse.Text == "Saint" || cbClasse.Text == "Diacre" || cbClasse.Text == "Prêtre")
            {
                lblForce.ForeColor = Color.Red;
                lblEsprit.ForeColor = Color.Black;
                lblDegatEsprit.Visible = false;
                lblDegatEspritArrow.Visible = false;
                lblDegatEspritTxt.Visible = false;
                lblDegatForce.Visible = true;
                lblDegatForceArrow.Visible = true;
                lblDegatForceTxt.Visible = true;
                multi = lblDegatForce.Text;
            }
            else if (cbClasse.Text == "Enchanteur" || cbClasse.Text == "Magicien" || cbClasse.Text == "Sorcier" ||
                     cbClasse.Text == "Soigneur" || cbClasse.Text == "Chaman" || cbClasse.Text == "Druide")
            {
                lblForce.ForeColor = Color.Black;
                lblEsprit.ForeColor = Color.Red;
                lblDegatEsprit.Visible = true;
                lblDegatEspritArrow.Visible = true;
                lblDegatEspritTxt.Visible = true;
                lblDegatForce.Visible = false;
                lblDegatForceArrow.Visible = false;
                lblDegatForceTxt.Visible = false;
                multi = lblDegatEsprit.Text;
            }
            else
            {
                lblForce.ForeColor = Color.Black;
                lblEsprit.ForeColor = Color.Black;
                lblDegatEsprit.Visible = true;
                lblDegatEspritArrow.Visible = true;
                lblDegatEspritTxt.Visible = true;
                lblDegatForce.Visible = true;
                lblDegatForceArrow.Visible = true;
                lblDegatForceTxt.Visible = true;
            }
            perso.Classe = cbClasse.Text;
            multiDC = lblDegatCritique.Text;
        }

        // Expérience
        private void btnExpPlus_Click(object sender, EventArgs e)
        {
            if (sender == btnExpPlus)
            {
                perso.Exp += IsInt(tbExp);
            }
            else if (sender == btnExpMoins)
            {
                perso.Exp -= IsInt(tbExp);
            }

            if (perso.Exp < 0)
            {
                perso.Exp = 0;
            }
            else if (perso.Exp > tabExp[perso.Niveau])
            {
                int tmp = perso.Exp - tabExp[perso.Niveau];
                perso.Exp = tmp;
                perso.Niveau++;
                tbNiveau.Text = perso.Niveau.ToString();
            }
            Experience(perso.Niveau);
        }

        // Caractéristiques : Force, Agilité, Endurance, Esprit, Initiative, Défense
        private void tbCaract_TextChanged(object sender, EventArgs e)
        {
            var v = sender as TextBox;
            int i = IsInt(sender);
            v.Text = i == 0 ? v.Text : i.ToString();

            try
            {
                perso.Force = IsInt(tbForce);
                perso.Agilite = IsInt(tbAgilite);
                perso.Endurance = IsInt(tbEndurance);
                perso.Esprit = IsInt(tbEsprit);
                perso.Initiative = IsInt(tbInitiative);
                perso.Defense = IsInt(tbDefense);

                tbForceTotal.Text = (int.Parse(tbForce.Text == "" ? "0" : tbForce.Text) + int.Parse(tbForceObjet.Text)).ToString();
                tbAgiliteTotal.Text = (int.Parse(tbAgilite.Text == "" ? "0" : tbAgilite.Text) + int.Parse(tbAgiliteObjet.Text)).ToString();
                tbEnduranceTotal.Text = (int.Parse(tbEndurance.Text == "" ? "0" : tbEndurance.Text) + int.Parse(tbEnduranceObjet.Text)).ToString();
                tbEspritTotal.Text = (int.Parse(tbEsprit.Text == "" ? "0" : tbEsprit.Text) + int.Parse(tbEspritObjet.Text)).ToString();
                tbInitiativeTotal.Text = (int.Parse(tbInitiative.Text == "" ? "0" : tbInitiative.Text) + int.Parse(tbInitiativeObjet.Text)).ToString();
                tbDefenseTotal.Text = (int.Parse(tbDefense.Text == "" ? "0" : tbDefense.Text) + int.Parse(tbDefenseObjet.Text)).ToString();
            }
            catch{}

            try
            {
                lblDegatForce.Text = "x" + (double.Parse(tbForceTotal.Text) / 100 + 1).ToString();
                lblDegatEsprit.Text = "x" + (double.Parse(tbEspritTotal.Text) / 100 + 1).ToString();
                lblDegatCritique.Text = "x" + (double.Parse(tbAgiliteTotal.Text) / 100 + 1).ToString();

                lblDegatAttaque.Text = (3 + int.Parse(tbNiveau.Text) / 10).ToString() + "d" + (6 + int.Parse(tbNiveau.Text) / 5).ToString() + "+" + IsInt(tbDegatBonus);
            }
            catch{}
            CalculVie();
            DefinirMultiplicateur();
        }

        // Niveau
        private void tbNiveau_TextChanged(object sender, EventArgs e)
        {
            var v = sender as TextBox;
            int i = IsInt(sender);
            v.Text = i == 0 ? v.Text : i.ToString();
            perso.Niveau = i;
            try
            {
                lblDegatAttaque.Text = (3 + int.Parse(tbNiveau.Text) / 10).ToString() + "d" + (6 + int.Parse(tbNiveau.Text) / 5).ToString() + "+" + IsInt(tbDegatBonus);
                DefinirMultiplicateur();
            }
            catch { }
        }

        // Dégats Bonus
        private void tbDegatBonus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDegatAttaque.Text = (3 + int.Parse(tbNiveau.Text) / 10).ToString() + "d" + (6 + int.Parse(tbNiveau.Text) / 5).ToString() + "+" + IsInt(tbDegatBonus);
                DefinirMultiplicateur();
            }
            catch { }
        }

        // Vie de base
        private void tbPvBase_TextChanged(object sender, EventArgs e)
        {
            CalculVie();
        }

        // Vie actuelle
        private void btnViePlus_Click(object sender, EventArgs e)
        {
            if (sender == btnViePlus)
            {
                perso.VieActuelle += IsInt(tbVieActuelle);
            }
            else if (sender == btnVieMoins)
            {
                perso.VieActuelle -= IsInt(tbVieActuelle);
            }

            CalculVie();
        }

        // Gold
        private void tbGold_TextChanged(object sender, EventArgs e)
        {
            perso.Gold = IsInt(tbGold);
        }
        #endregion

        #region Methode
        private void CalculCaract()
        {
            int force = 0;
            int endurance = 0;
            int agilite = 0;
            int esprit = 0;
            int initiative = 0;
            int defense = 0;

            var s = bindingSourceObjets.DataSource as List<Objet>;
            foreach (Objet objet in s)
            {
                force += objet.Force;
                agilite += objet.Agilite;
                endurance += objet.Endurance;
                esprit += objet.Esprit;
                initiative += objet.Initiative;
                defense += objet.Defense;
            }
            init = true;
            tbForceObjet.Text = force.ToString();
            tbAgiliteObjet.Text = agilite.ToString();
            tbEnduranceObjet.Text = endurance.ToString();
            tbEspritObjet.Text = esprit.ToString();
            tbInitiativeObjet.Text = initiative.ToString();
            tbDefenseObjet.Text = defense.ToString();
            init = false;
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

        private void Experience()
        {
            tabExp[0] = 0;
            tabExp[1] = 40;
            tabExp[2] = 105;
            tabExp[3] = 204;
            tabExp[4] = 346;
            tabExp[5] = 541;
            tabExp[6] = 800;
            tabExp[7] = 1136;
            tabExp[8] = 1561;
            tabExp[9] = 2088;
            tabExp[10] = 2732;
            tabExp[11] = 3508;
            tabExp[12] = 4432;
            tabExp[13] = 5521;
            tabExp[14] = 6791;
            tabExp[15] = 8261;
            tabExp[16] = 9949;
            tabExp[17] = 11875;
            tabExp[18] = 14059;
            tabExp[19] = 16522;
            tabExp[20] = 19285;
            tabExp[21] = 22370;
            tabExp[22] = 25799;
            tabExp[23] = 29596;
            tabExp[24] = 33785;
            tabExp[25] = 38390;
            tabExp[26] = 43437;
            tabExp[27] = 48951;
            tabExp[28] = 54959;
            tabExp[29] = 61487;
            tabExp[30] = 68563;
            tabExp[31] = 76215;
            tabExp[32] = 84472;
            tabExp[33] = 93363;
            tabExp[34] = 102918;
            tabExp[35] = 113167;
            tabExp[36] = 124141;
            tabExp[37] = 135872;
            tabExp[38] = 148392;
            tabExp[39] = 161733;
            tabExp[40] = 175928;
            tabExp[41] = 191011;
            tabExp[42] = 207017;
            tabExp[43] = 223980;
            tabExp[44] = 241935;
            tabExp[45] = 260918;
            tabExp[46] = 280965;
            tabExp[47] = 302113;
            tabExp[48] = 324399;
            tabExp[49] = 347862;
            tabExp[50] = 372539;
        }

        private void Experience(int niveau)
        {
            pbExp.Minimum = 0;
            pbExp.Maximum = tabExp[niveau];
            pbExp.Value = perso.Exp;
            lblExp.Text = perso.Exp + " / " + pbExp.Maximum;
        }

        private void CalculVie()
        {
            perso.VieBase = IsInt(tbPvBase);

            if (perso.VieActuelle < 0)
            {
                perso.VieActuelle = 0;
            }
            else if (perso.VieActuelle > (perso.VieBase + (IsInt(tbEnduranceTotal) * 2)) && init == false)
            {
                perso.VieActuelle = perso.VieBase + (IsInt(tbEnduranceTotal) * 2);
            }

            lblVitalite.Text = (IsInt(tbEnduranceTotal) * 2).ToString();
            lblVieActuelle.Text = perso.VieActuelle + " / " + (perso.VieBase + (IsInt(tbEnduranceTotal) * 2));
        }

        public void Init()
        {
            init = true;
            tbAgilite.TextChanged -= tbCaract_TextChanged;
            tbEndurance.TextChanged-= tbCaract_TextChanged;
            tbForce.TextChanged-= tbCaract_TextChanged;
            tbEsprit.TextChanged-= tbCaract_TextChanged;
            tbInitiative.TextChanged-= tbCaract_TextChanged;
            tbDefense.TextChanged -= tbCaract_TextChanged;
            tbPvBase.TextChanged -= tbPvBase_TextChanged;

            tbAgiliteObjet.TextChanged -= tbCaract_TextChanged;
            tbEnduranceObjet.TextChanged -= tbCaract_TextChanged;
            tbForceObjet.TextChanged -= tbCaract_TextChanged;
            tbEspritObjet.TextChanged -= tbCaract_TextChanged;
            tbInitiativeObjet.TextChanged -= tbCaract_TextChanged;
            tbDefenseObjet.TextChanged -= tbCaract_TextChanged;
            tbExp.TextChanged -= tbCaract_TextChanged;
            tbVieActuelle.TextChanged -= tbCaract_TextChanged;
            dgvInventaire.RowsAdded -= dgvInventaire_RowsAdded;
            dgvInventaire.RowsRemoved -= dgvInventaire_RowsRemoved;

            tbNom.Text = perso.Nom;
            tbGold.Text = perso.Gold.ToString();
            cbClasse.Text = perso.Classe;
            cbRace.Text = perso.Race;
            tbNiveau.Text = perso.Niveau.ToString();
            tbForce.Text = perso.Force.ToString();
            tbAgilite.Text = perso.Agilite.ToString();
            tbEndurance.Text = perso.Endurance.ToString();
            tbEsprit.Text = perso.Esprit.ToString();
            tbInitiative.Text = perso.Initiative.ToString();
            tbDefense.Text = perso.Defense.ToString();
            tbPvBase.Text = perso.VieBase.ToString();

            bindingSourceObjets.DataSource = perso.Objets;
            dgvInventaire.Refresh();

            Experience(perso.Niveau);

            tbAgilite.TextChanged += tbCaract_TextChanged;
            tbEndurance.TextChanged += tbCaract_TextChanged;
            tbForce.TextChanged += tbCaract_TextChanged;
            tbEsprit.TextChanged += tbCaract_TextChanged;
            tbInitiative.TextChanged += tbCaract_TextChanged;
            tbDefense.TextChanged += tbCaract_TextChanged;
            tbPvBase.TextChanged += tbPvBase_TextChanged;


            tbAgiliteObjet.TextChanged += tbCaract_TextChanged;
            tbEnduranceObjet.TextChanged += tbCaract_TextChanged;
            tbForceObjet.TextChanged += tbCaract_TextChanged;
            tbEspritObjet.TextChanged += tbCaract_TextChanged;
            tbInitiativeObjet.TextChanged += tbCaract_TextChanged;
            tbDefenseObjet.TextChanged += tbCaract_TextChanged;
            tbExp.TextChanged += tbCaract_TextChanged;
            tbVieActuelle.TextChanged += tbCaract_TextChanged;
            dgvInventaire.RowsAdded += dgvInventaire_RowsAdded;
            dgvInventaire.RowsRemoved += dgvInventaire_RowsRemoved;
            init = false;
        }

        public void AjouterObjet(Objet objet)
        {
            bindingSourceObjets.Add(objet);
            dgvInventaire.Refresh();
        }

        public void DefinirMultiplicateur()
        {
            if (cbClasse.Text == "Soldat" || cbClasse.Text == "Guerrier" || cbClasse.Text == "Barbare" ||
                cbClasse.Text == "Fourbe" || cbClasse.Text == "Voleur" || cbClasse.Text == "Assassin" ||
                     cbClasse.Text == "Saint" || cbClasse.Text == "Diacre" || cbClasse.Text == "Prêtre")
            {
                multi = lblDegatForce.Text;
            }
            else if (cbClasse.Text == "Enchanteur" || cbClasse.Text == "Magicien" || cbClasse.Text == "Sorcier" ||
                     cbClasse.Text == "Soigneur" || cbClasse.Text == "Chaman" || cbClasse.Text == "Druide")
            {
                multi = lblDegatEsprit.Text;
            }
            multiDC = lblDegatCritique.Text;
            attaque = lblDegatAttaque.Text;
        }

        public void UpdateObjets() {
            CalculCaract();
            perso.Objets = bindingSourceObjets.DataSource as List<Objet>;
        }
        #endregion

        private void dgvInventaire_MouseClick(object sender, MouseEventArgs e) {

            DonjonEtDragon.Main main = this.Parent.Parent.Parent as DonjonEtDragon.Main;
            int currentMouseOverRow = dgvInventaire.HitTest(e.X, e.Y).RowIndex;
            if (currentMouseOverRow >= 0 && currentMouseOverRow < perso.Objets.Count && main != null) {
                if (e.Button == MouseButtons.Right) {
                    dgvInventaire.ClearSelection();
                    dgvInventaire.Rows[currentMouseOverRow].Selected = true;
                    ContextMenu m = new ContextMenu();

                    MenuItem trade = new MenuItem("Echange");
                    m.MenuItems.Add(trade);

                    foreach (var p in main.Persos) {
                        if (perso.Nom != p.Nom) {
                            MenuItem item = new MenuItem(p.Nom);
                            item.Click += new EventHandler(delegate (Object o, EventArgs a)
                            {
                                Objet objet = perso.Objets[currentMouseOverRow];
                                main.ObjetRecu(p.Nom, objet);
                                dgvInventaire.Rows.RemoveAt(currentMouseOverRow);
                                UpdateObjets();
                            });
                            trade.MenuItems.Add(item);
                        }
                    }
                    m.Show(dgvInventaire, new Point(e.X, e.Y));
                }
            }
        }
    }
}
