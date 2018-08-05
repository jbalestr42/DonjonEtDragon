using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace DonjonEtDragon
{
    public class SerializeHelper
    {
        private SaveFileDialog _sfd = new SaveFileDialog();
        private OpenFileDialog _ofd = new OpenFileDialog();
        private List<Perso> _lstPerso;
        private string _filename = "";

        public SerializeHelper()
        {
            _sfd.Filter = "Perso |*.pers";
            _ofd.Filter = "Perso |*.pers";
        }

        public void Save(object _object)
        {
            DialogResult rep = _sfd.ShowDialog();
            if (rep == DialogResult.OK)
            {
                try
                {
                    _filename = _sfd.FileName;
                    Stream stream = File.Open(_filename, FileMode.Create);
                    BinaryFormatter bformatter = new BinaryFormatter();

                    bformatter.Serialize(stream, _object);
                    stream.Close();
                    stream.Dispose();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveCurrent(object _object)
        {
            if (string.IsNullOrEmpty(_filename))
            {
                Save(_object);
            } 
            else
            {
                try {
                    Stream stream = File.Open(_filename, FileMode.Create);
                    BinaryFormatter bformatter = new BinaryFormatter();

                    bformatter.Serialize(stream, _object);
                    stream.Close();
                    stream.Dispose();
                } catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public List<Perso> Open()
        {
            DialogResult rep = _ofd.ShowDialog();
            if (rep == DialogResult.OK)
            {
                _filename = _ofd.FileName;

                Stream stream = File.Open(_filename, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();

                _lstPerso = (List<Perso>)bformatter.Deserialize(stream);
                stream.Close();

                return _lstPerso;
            }
            return null;
        }
    }
}
