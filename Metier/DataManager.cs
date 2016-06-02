using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Metier
{
    public class DataManager
    {
        public DataManager()
        {
            Charger();
        }

        public event EventHandler miseAJour;

        private List<CompositeurMetier> listeCompo;

        public List<CompositeurMetier> ListeCompo
        {
            get
            {
                return listeCompo;
            }

            set
            {
                listeCompo = value;
                miseAJour(this, EventArgs.Empty);
            }
        }

        public void Ajouter(CompositeurMetier c)
        {
            listeCompo.Add(c);
            miseAJour(this, EventArgs.Empty);

        }

        public void Supprimer(CompositeurMetier c)
        {
            listeCompo.Remove(c);
            miseAJour(this, EventArgs.Empty);
        }

        public void Modifier(CompositeurMetier avant, CompositeurMetier apres)
        {
            listeCompo.Remove(avant);
            listeCompo.Add(apres);
            miseAJour(this, EventArgs.Empty);
        }

        public void Enregister()
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            var serialiser = new DataContractSerializer(typeof(List<CompositeurMetier>));
            using (XmlWriter writer = XmlWriter.Create("sauvegarde\\fichier.xml", settings))
            {
                serialiser.WriteObject(writer, ListeCompo);
            }
        }

        public void Charger()
        {
            var serialiser = new DataContractSerializer(typeof(List<CompositeurMetier>));
            using (Stream s = File.OpenRead("sauvegarde\\fichier.xml"))
            {
                ListeCompo = serialiser.ReadObject(s) as List<CompositeurMetier>;
            }
        }
    }
}
