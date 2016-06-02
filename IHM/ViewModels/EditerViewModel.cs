using IHM.Models;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.ViewModels
{
    public class EditerViewModel : NotifyPropertyChangedBase
    {

        public EditerViewModel(CompositeurIHM c)
        {
            CompoInitial = c;
            CompoModifie = new CompositeurIHM(c);
        }

        #region Propriétés

        private CompositeurIHM _CompoInitial;
        

        private CompositeurIHM _CompoModifie;

        public CompositeurIHM CompoInitial
        {
            get
            {
                return _CompoInitial;
            }

            set
            {
                _CompoInitial = value;
                NotifyPropertyChanged("CompoInitial");
            }
        }

        public CompositeurIHM CompoModifie
        {
            get
            {
                return _CompoModifie;
            }

            set
            {
                _CompoModifie = value;
                NotifyPropertyChanged("CompoModifie");
            }
        }
        #endregion

        #region Boutons



        #endregion
    }
}
