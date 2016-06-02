using IHM.Models;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.ViewModels
{
    public class AjouterViewModel : NotifyPropertyChangedBase
    {
        CompositeurIHM _Compositeur;

        public CompositeurIHM Compositeur
        {
            get
            {
                return _Compositeur;
            }

            set
            {
                _Compositeur = value;
                NotifyPropertyChanged("Compositeur");
            }
        }


        public AjouterViewModel()
        {
            Compositeur = new CompositeurIHM();
        }

        DelegateCommand ValiderCommand
        {
            get;
            set;
        }

        private void Valider(object o)
        {

        }

        private bool CanValider(object o)
        {
            return (Compositeur.Nom != null) && (Compositeur.Prenom != null) && (Compositeur.DateNaissance != null);
        }

        DelegateCommand AnnulerCommand
        {
            get;
            set;
        }

        private void Annuler(object o)
        {
            
        }
    }
}
