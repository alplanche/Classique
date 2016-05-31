using IHM.Models;
using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.Factory
{
    public static class CompositeurFactory
    {
        public static CompositeurIHM ConvertCompositeur(CompositeurMetier c)
        {
            return new CompositeurIHM()
            {
                Nom = c.Nom,
                Prenom = c.Prenom,
                DateNaissance = c.DateNaissance,
                DateDeces = c.DateDeces,
                Description = c.Description,
                Oeuvres = c.Oeuvres,
                CheminImage = c.CheminImage

            };
        }

        public static ObservableCollection<CompositeurIHM> ConvertAllCompositeur(IEnumerable<CompositeurMetier> l)
        {
            ObservableCollection<CompositeurIHM> retour = new ObservableCollection<CompositeurIHM>();
            foreach(CompositeurMetier compo in l)
            {
                retour.Add(ConvertCompositeur(compo));
            }
            return retour;
        }

        public static CompositeurMetier ConvertBackCompositeur(CompositeurIHM c)
        {
            return new CompositeurMetier()
            {
                Nom = c.Nom,
                Prenom = c.Prenom,
                DateNaissance = c.DateNaissance,
                DateDeces = c.DateDeces,
                Description = c.Description,
                Oeuvres = c.Oeuvres,
                CheminImage = c.CheminImage

            };
        }
    }
}