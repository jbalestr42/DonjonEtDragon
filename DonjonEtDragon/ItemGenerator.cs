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
    public partial class ItemGenerator : Form
    {
        private static readonly ItemGenerator MyInstance = new ItemGenerator();
        private FicHelper Helper = new FicHelper();
        private List<string> ListeObjets = new List<string>();

        private List<string> ListeAttributs = new List<string>() {"Force", "Endurance", "Agilité", "Esprit", "Initiative", "Défense"};
        private List<string> ListeTypesArmures = new List<string>() {"Gants", "Bottes", "Casque", "Torse", "Jambières"};
        private List<string> ListeTypesArmes = new List<string>();
        private List<string> ListeTypesBjoux = new List<string>() { "Anneaux", "Amulette" };
        private List<string> ListeTypesArmesLegendaires = new List<string>();
        private List<string> ListeTypesArmuresLegendaires = new List<string>();
        private List<string> ListeTypesBijouxLegendaires = new List<string>();
        private List<string> ListeTypesArtefactsLegendaires = new List<string>();
        private Objet objet = new Objet();
        private static Main main;
        private Random Random = new Random();

        private ItemGenerator()
        {
            InitializeComponent();
            ListeTypesArmes = Helper.ReadFic("Data/TypesArmes");
            ListeTypesArmesLegendaires = Helper.ReadFic("Data/TypesArmesLegendaires");
            ListeTypesArmuresLegendaires = Helper.ReadFic("Data/TypesArmuresLegendaires");
            ListeTypesBijouxLegendaires = Helper.ReadFic("Data/TypesBijouxLegendaires");
            ListeTypesArtefactsLegendaires = Helper.ReadFic("Data/TypesArtefactsLegendaires");
        }

        public void SetMain(Main _main)
        {
            main = _main;
        }

        public static ItemGenerator Instance
        {
            get { return MyInstance; }
        }

        private void btnGenerer_Click(object sender, EventArgs e)
        {
            try
            {
                int RandomQuality = Random.Next(1, 101);
                int niveauMonstre = int.Parse(tbNiveau.Text);
                lblJet.Text = RandomQuality.ToString();
                string NomFic = "";
                string NomCaract = "";
                int quality = 0;
                int multiplicateur = 0;
                int tmp = 0;

                Dictionary<string, int> dico = new Dictionary<string, int>();
                System.Threading.Thread.Sleep(50);
                if (RandomQuality == 100)
                {
                    JouerSon();
                    System.Threading.Thread.Sleep(50);
                    NomFic = "Légendaire";
                    switch (Random.Next(1, 5))
                    {
                        case 1:
                            lbNomObjet.Text = ListeTypesArmesLegendaires[Random.Next(1, ListeTypesArmesLegendaires.Count + 1) - 1];
                            multiplicateur = 5;
                            break;
                        case 2:
                            lbNomObjet.Text = ListeTypesArmuresLegendaires[Random.Next(1, ListeTypesArmuresLegendaires.Count + 1) - 1];
                            multiplicateur = 4;
                            break;
                        case 3:
                            lbNomObjet.Text = ListeTypesBijouxLegendaires[Random.Next(1, ListeTypesBijouxLegendaires.Count + 1) - 1];
                            multiplicateur = 3;
                            break;
                        case 4:
                            lbNomObjet.Text = ListeTypesArtefactsLegendaires[Random.Next(1, ListeTypesArtefactsLegendaires.Count + 1) - 1];
                            multiplicateur = 3;
                            break;
                    }
                }
                else if (RandomQuality >= 45)
                {
                    ListeObjets = Helper.ReadFic("Data/Armures");
                    lbNomObjet.Text = ListeTypesArmures[Random.Next(1, ListeTypesArmures.Count + 1) - 1];
                    lbNomObjet.Text += " " + ListeObjets[Random.Next(1, ListeObjets.Count + 1) - 1];
                    NomFic = "Armures";
                    multiplicateur = 3;
                }
                else if (RandomQuality >= 10)
                {
                    ListeObjets = Helper.ReadFic("Data/Armes");
                    lbNomObjet.Text = ListeTypesArmes[Random.Next(1, ListeTypesArmes.Count + 1) - 1];
                    lbNomObjet.Text += " " + ListeObjets[Random.Next(1, ListeObjets.Count + 1) - 1];
                    NomFic = "Armes";
                    multiplicateur = 4;
                }
                else
                {
                    ListeObjets = Helper.ReadFic("Data/Bijoux");
                    lbNomObjet.Text = ListeTypesBjoux[Random.Next(1, ListeTypesBjoux.Count + 1) - 1];
                    lbNomObjet.Text += " " + ListeObjets[Random.Next(1, ListeObjets.Count + 1) - 1];
                    NomFic = "Bijoux";
                    multiplicateur = 2;
                }

                quality = DefineQuality(RandomQuality);

                for (int i = 0; i < quality; i++)
                {
                    do
                    {
                        if (NomFic == "Armes")
                            tmp = Random.Next(1, 6);
                        else
                            tmp = Random.Next(1, 7);

                        switch (tmp)
                        {
                            case 1:
                                NomCaract = "Force";
                                break;
                            case 2:
                                NomCaract = "Endurance";
                                break;
                            case 3:
                                NomCaract = "Agilité";
                                break;
                            case 4:
                                NomCaract = "Esprit";
                                break;
                            case 5:
                                NomCaract = "Initiative";
                                break;
                            case 6:
                                NomCaract = "Défense";
                                break;
                        }
                    } while (dico.ContainsKey(NomCaract));

                    dico.Add(NomCaract, Random.Next((int)(multiplicateur * niveauMonstre / 2), (int)(multiplicateur * niveauMonstre + 1)));
                }

                rtbAttributs.Text = quality + " attributs.\n";
                objet = new Objet();
                foreach (KeyValuePair<string, int> keyValuePair in dico)
                {
                    if(keyValuePair.Key == "Force")
                    {
                        objet.Force = keyValuePair.Value;
                        string s1 = (multiplicateur * niveauMonstre / 2).ToString();
                        string s2 = (multiplicateur * niveauMonstre).ToString();
                        rtbAttributs.Text += keyValuePair.Value + " " + keyValuePair.Key + " (" + s1 + "-" + s2 + ")\n";
                    }
                    else if (keyValuePair.Key == "Endurance")
                    {
                        objet.Endurance = keyValuePair.Value;
                        string s1 = (multiplicateur * niveauMonstre / 2).ToString();
                        string s2 = (multiplicateur * niveauMonstre).ToString();
                        rtbAttributs.Text += keyValuePair.Value + " " + keyValuePair.Key + " (" + s1 + "-" + s2 + ")\n";
                    }
                    else if (keyValuePair.Key == "Agilité")
                    {
                        objet.Agilite = keyValuePair.Value;
                        string s1 = (multiplicateur * niveauMonstre / 2).ToString();
                        string s2 = (multiplicateur * niveauMonstre).ToString();
                        rtbAttributs.Text += keyValuePair.Value + " " + keyValuePair.Key + " (" + s1 + "-" + s2 + ")\n";
                    }
                    else if (keyValuePair.Key == "Esprit")
                    {
                        objet.Esprit = keyValuePair.Value;
                        string s1 = (multiplicateur * niveauMonstre / 2).ToString();
                        string s2 = (multiplicateur * niveauMonstre).ToString();
                        rtbAttributs.Text += keyValuePair.Value + " " + keyValuePair.Key + " (" + s1 + "-" + s2 + ")\n";
                    }
                    else if (keyValuePair.Key == "Initiative")
                    {
                        objet.Initiative = keyValuePair.Value / 10;
                        string s1 = (multiplicateur * niveauMonstre / 20).ToString();
                        string s2 = (multiplicateur * niveauMonstre / 10).ToString();
                        rtbAttributs.Text += keyValuePair.Value / 10 + " " + keyValuePair.Key + " (" + s1 + "-" + s2 + ")\n";
                    }
                    else if (keyValuePair.Key == "Défense")
                    {
                        objet.Defense = keyValuePair.Value / 10;
                        string s1 = (multiplicateur * niveauMonstre / 20).ToString();
                        string s2 = (multiplicateur * niveauMonstre / 10).ToString();
                        rtbAttributs.Text += keyValuePair.Value / 10 + " " + keyValuePair.Key + " (" + s1 + "-" + s2 + ")\n";
                    }
                }
                objet.Nom = lbNomObjet.Text;

            }
            catch{}
        }

        private int DefineQuality(int value)
        {
            if(value == 100) // 1%
            {
                lbNomObjet.ForeColor = Color.Goldenrod;
                return Random.Next(5, 7);
            }
            else if(value >= 90) // 9%
            {
                lbNomObjet.ForeColor = Color.DarkGreen;
                return 4;
            }
            else if (value >= 50) // 40%
            {
                lbNomObjet.ForeColor = Color.Blue;
                return 3;
            }
            else if (value >= 15) // 35%
            {
                lbNomObjet.ForeColor = Color.Black;
                return 2;
            }
            lbNomObjet.Text = " - ";
            return 0;
        }

        //private int Random(int min, int max)
        //{
        //    Random r = new Random();
        //    //var rnd = new Random(r.Next(Int32.MaxValue));
        //    return r.Next(min,max);
        //}

        private void btnInventaire_Click(object sender, EventArgs e)
        {
            if(objet != null)
                main.ObjetRecu(objet);
        }

        #region Events
        public delegate void SendObjetEvenHandler(Objet objet);
        public event SendObjetEvenHandler SendObjet;

        public void OnSendObjet()
        {
            SendObjetEvenHandler handler = SendObjet;
            if (handler != null) handler(objet);
        }

        private void JouerSon()
        {
            // Create the SoundPlayer object
            System.Media.SoundPlayer s = new System.Media.SoundPlayer();
            s.Stream = Properties.Resources.HOLYGRENADE;
            //s.PlayLooping();
            s.Play();
            //s.Stop();
        }
        #endregion
    }
}
