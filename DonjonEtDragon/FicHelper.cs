using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DonjonEtDragon
{
    public class FicHelper
    {
        public List<string> ReadFic(string s)
        {
            StreamReader fic = new StreamReader(GetCurrentDirectory() + @"\" + s + ".txt");
            List<string> al = new List<string>();

            string lecture = fic.ReadLine();

            while (lecture != null)
            {
                al.Add(lecture);
                lecture = fic.ReadLine();
            }

            return al;
        }

        public string GetCurrentDirectory()
        {
            return Application.StartupPath;
        }
    }
}
