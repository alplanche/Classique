using IHM.Factory;
using IHM.Models;
using IHM.Views;
using Library;
using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        #region Propriétés

        private ObservableCollection<CompositeurIHM> _listeCompo;
        public ObservableCollection<CompositeurIHM> ListeCompo
        {
            get
            {
                return _listeCompo;
            }

            set
            {
                _listeCompo = value;
                NotifyPropertyChanged("ListeCompo");
            }
        }

        private CompositeurIHM _SelectedCompositeur;
        public CompositeurIHM SelectedCompositeur
        {
            get
            {
                return _SelectedCompositeur;
            }

            set
            {
                _SelectedCompositeur = value;
                NotifyPropertyChanged("ListeCompo");
                NotifyPropertyChanged("SelectedCompositeur");
                EditerCommand.RaiseCanExecuteChanged();
                SupprimerCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commandes

        #region Ajouter
        public DelegateCommand AjouterCommand
        {
            get;
            set;
        }

        private void Ajouter(object o)
        {

        }
        #endregion

        #region Editer

        public DelegateCommand EditerCommand
        {
            get;
            set;
        }

        private void Editer(object o)
        {
            EditerView fen = new EditerView(SelectedCompositeur);
            fen.ShowDialog();
            
        }

        private bool CanEditer(object o)
        {
            return _SelectedCompositeur != null;
        }

        #endregion

        #region Supprimer

        public DelegateCommand SupprimerCommand
        {
            get;
            set;
        }

        private void Supprimer(object o)
        {

        }

        private bool CanSupprimer(object o)
        {
            return _SelectedCompositeur != null;
        }

        #endregion

        #endregion

        private DataManager dataManager;

        public MainWindowViewModel()
        {
            dataManager = new DataManager();
            ListeCompo = CompositeurFactory.ConvertAllCompositeur(dataManager.ListeCompo);
            AjouterCommand = new DelegateCommand(Ajouter);
            EditerCommand = new DelegateCommand(Editer, CanEditer);
            SupprimerCommand = new DelegateCommand(Supprimer, CanSupprimer);
        }
    }
}
