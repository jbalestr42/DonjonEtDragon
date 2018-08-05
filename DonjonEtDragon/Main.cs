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
    public partial class Main : Form
    {
        private SerializeHelper helper = new SerializeHelper();
        private List<Perso> lst = new List<Perso>();
        private ItemGenerator f;
        private Dice fd;
        private bool isSaving = false;

        public Main()
        {
            InitializeComponent();
            InitFirstPage();
            f = ItemGenerator.Instance;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.S)) {
                if (!isSaving) {
                    lst.Clear();
                    try {
                        foreach (TabPage tabPage in tcMain.TabPages) {
                            if (tabPage != tpPlus) {
                                var v = tabPage.Controls[0] as FicPerso;
                                lst.Add(v.perso);
                            }
                        }
                        helper.SaveCurrent(lst);
                    } catch { }
                    isSaving = true;
                }
                return true;
            } else {
                isSaving = false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void msoDes_Click(object sender, EventArgs e)
        {
            fd = new Dice();
            fd.Show();
        }

        private void msoGenerateur_Click(object sender, EventArgs e)
        {
            f = ItemGenerator.Instance;
            f.SetMain(this);
            f.Show();
            f.Focus();
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMain.SelectedTab == tpPlus)
                CreateNewPage();
            var v = tcMain.SelectedTab.Controls[0] as FicPerso;

            v.UpdateObjets();
            if (fd != null) {
                fd.ChangeMultiplicateur(v.attaque, v.multi, v.multiDC);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            tcMain.TabPages.Remove(tcMain.SelectedTab);
        }

        private void CreateNewPage()
        {
            TabPage tab = new TabPage();
            tab.Controls.Add(new FicPerso());
            tab.Controls[0].Dock = DockStyle.Fill;
            var v = tab.Controls[0] as FicPerso;
            v.NomTextChanged += new FicPerso.NomTextChangedEventHandler(TabPage_TextChanged);
            tab.Text = "Joueur " + tcMain.TabPages.Count.ToString();
            tcMain.TabPages.Insert(tcMain.TabPages.Count - 1, tab);
            tcMain.SelectTab(tcMain.TabPages.Count - 2);
        }

        private void AddNewPage(Perso perso)
        {
            TabPage tab = new TabPage();
            FicPerso fic = new FicPerso();
            System.Threading.Thread.Sleep(100);
            fic.perso = perso;
            fic.Init();
            tab.Controls.Add(fic);
            tab.Controls[0].Dock = DockStyle.Fill;
            var v = tab.Controls[0] as FicPerso;
            v.NomTextChanged += new FicPerso.NomTextChangedEventHandler(TabPage_TextChanged);
            tab.Text = perso.Nom;
            tcMain.TabPages.Insert(tcMain.TabPages.Count - 1, tab);
            tcMain.SelectTab(tcMain.TabPages.Count - 2);
        }

        private void InitFirstPage()
        {
            var v = ficPerso1;
            v.NomTextChanged += new FicPerso.NomTextChangedEventHandler(TabPage_TextChanged);
        }

        void TabPage_TextChanged(object sender)
        {
            var v = sender as TextBox;
            tcMain.SelectedTab.Text = v.Text;
        }

        public void ObjetRecu(Objet objet)
        {
            var v = tcMain.SelectedTab as TabPage;
            FicPerso f = v.Controls[0] as FicPerso;
            f.AjouterObjet(objet);
        }

        public void ObjetRecu(string perso, Objet objet) {

            for (int i = 0; i < tcMain.TabPages.Count; i++) {
                if (tcMain.TabPages[i].Text == perso) {
                    FicPerso f = tcMain.TabPages[i].Controls[0] as FicPerso;
                    f.AjouterObjet(objet);
                    break;
                }
            }
        }

        private void msfEnregistrer_Click(object sender, EventArgs e)
        {
            lst.Clear();
            try
            {
                foreach (TabPage tabPage in tcMain.TabPages)
                {
                    if (tabPage != tpPlus)
                    {
                        var v = tabPage.Controls[0] as FicPerso;
                        lst.Add(v.perso);
                    }
                }
                helper.Save(lst);
            }
            catch (Exception){}
        }

        private void msfOuvrir_Click(object sender, EventArgs e)
        {
            try
            {
                lst = helper.Open();
                foreach (Perso perso in lst)
                {
                    AddNewPage(perso);
                }
                tcMain.TabPages.RemoveAt(0);
            }
            catch (Exception){}
        }

        private void btnAjouterObjet_Click(object sender, EventArgs e)
        {
            AddItem f = new AddItem(this);
            f.Show();
        }

        public List<Perso> Persos { get { return lst; } }
    }
}
