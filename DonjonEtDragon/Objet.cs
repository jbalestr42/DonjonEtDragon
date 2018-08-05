using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DonjonEtDragon
{
    [Serializable]
    public class Objet : ISerializable
    {
        public string Nom { get; set; }
        public int Force { get; set; }
        public int Endurance { get; set; }
        public int Agilite { get; set; }
        public int Esprit { get; set; }
        public int Initiative { get; set; }
        public int Defense { get; set; }

        public Objet ()
        {
            
        }

        public Objet (SerializationInfo info, StreamingContext ctxr)
        {
            Nom = (string)info.GetValue("Nom", typeof(string));
            Force = (int)info.GetValue("Force", typeof(int));
            Endurance = (int)info.GetValue("Endurance", typeof(int));
            Agilite = (int)info.GetValue("Agilite", typeof(int));
            Esprit = (int)info.GetValue("Esprit", typeof(int));
            Initiative = (int)info.GetValue("Initiative", typeof(int));
            Defense = (int)info.GetValue("Defense", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Nom", Nom);
            info.AddValue("Force", Force);
            info.AddValue("Endurance", Endurance);
            info.AddValue("Agilite", Agilite);
            info.AddValue("Esprit", Esprit);
            info.AddValue("Initiative", Initiative);
            info.AddValue("Defense", Defense);
        }
    }
}
