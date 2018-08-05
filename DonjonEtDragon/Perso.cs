using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DonjonEtDragon
{
    [Serializable]
    public class Perso : ISerializable
    {
        public string Nom { get; set; }
        public string Race { get; set; }
        public string Classe { get; set; }
        public int Niveau { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
        public int Force { get; set; }
        public int Endurance { get; set; }
        public int Agilite { get; set; }
        public int Esprit { get; set; }
        public int Initiative { get; set; }
        public int Defense { get; set; }
        public int VieBase { get; set; }
        public int VieActuelle { get; set; }
        private List<Objet> objets = new List<Objet>();

        public Perso ()
        {
            
        }

        public Perso(SerializationInfo info, StreamingContext ctxt)
        {
            Nom = (string)info.GetValue("Nom", typeof(string));
            Race = (string)info.GetValue("Race", typeof(string));
            Classe = (string)info.GetValue("Classe", typeof(string));
            Niveau = (int)info.GetValue("Niveau", typeof(int));
            Exp = (int)info.GetValue("Exp", typeof(int));
            Force = (int)info.GetValue("Force", typeof(int));
            Endurance = (int)info.GetValue("Endurance", typeof(int));
            Agilite = (int)info.GetValue("Agilite", typeof(int));
            Esprit = (int)info.GetValue("Esprit", typeof(int));
            Initiative = (int)info.GetValue("Initiative", typeof(int));
            Defense = (int)info.GetValue("Defense", typeof(int));
            VieBase = (int)info.GetValue("VieBase", typeof(int));
            VieActuelle = (int)info.GetValue("VieActuelle", typeof(int));
            Gold = (int)info.GetValue("Gold", typeof(int));
            objets = (List<Objet>)info.GetValue("Objets", typeof(List<Objet>));
        }

        public List<Objet>  Objets
        {
            get { return objets; }
            set { objets = value; }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Nom", Nom);
            info.AddValue("Race", Race);
            info.AddValue("Classe", Classe);
            info.AddValue("Niveau", Niveau);
            info.AddValue("Exp", Exp);
            info.AddValue("Force", Force);
            info.AddValue("Endurance", Endurance);
            info.AddValue("Agilite", Agilite);
            info.AddValue("Esprit", Esprit);
            info.AddValue("Initiative", Initiative);
            info.AddValue("Defense", Defense);
            info.AddValue("VieBase", VieBase);
            info.AddValue("VieActuelle", VieActuelle);
            info.AddValue("Objets", objets);
            info.AddValue("Gold", Gold);
        }
    }
}
