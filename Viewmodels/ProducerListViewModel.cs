using Sturmer.AircraftCompany.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;


namespace Sturmer.AircraftCompany.WPFUI.ViewModels
{
    public class ProducerListViewModel : ViewModelBase
    {
        public ObservableCollection<ProducerViewModel> Producers{ get; set; } = new ObservableCollection<ProducerViewModel>();

        public ObservableCollection<IProducer> ProducerSelectList { get; set;} = new ObservableCollection<IProducer>();

        private ListCollectionView _view;

        public ProducerListViewModel()
        {
            GetAllProducers();

            _selectedProducer = new ProducerViewModel(BL.BL.NewProducer());
            _editedProducer = new ProducerViewModel(BL.BL.NewProducer());
            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Producers);
            _addNewProducerCommand = new RelayCommand(param => this.AddNewProducer());
            _deleteProducerCommand = new RelayCommand(param => this.DeleteProducer());
        }

        private void GetAllProducers()
        {
            foreach (var producer in BL.BL.GetAllProducers())
            {
                Producers.Add(new ProducerViewModel(producer));
                ProducerSelectList.Add(producer);
            }
        }

        private ProducerViewModel _editedProducer;
        public ProducerViewModel EditedProducer
        {
            get => _editedProducer;
            set
            {
                _editedProducer = value;
                OnPropertyChanged(nameof(EditedProducer));
            }
        }

        private ProducerViewModel _selectedProducer;
        public ProducerViewModel SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

        private void AddNewProducer()
        {
            if (BL.BL.AddProducer(EditedProducer.GetProducer()))
            {
                Producers.Add(EditedProducer);
                ProducerSelectList.Add(EditedProducer.GetProducer());
                EditedProducer = new ProducerViewModel(BL.BL.NewProducer());
            }
        }

        private RelayCommand _addNewProducerCommand;

        public RelayCommand AddNewProducerCommand
        {
            get => _addNewProducerCommand;
        }


        private void DeleteProducer()
        {
            if (SelectedProducer.Name != null)
            {
                string messageText = $"Do you really want to delete {SelectedProducer.Name}";
                MessageBoxResult result = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (BL.BL.DeleteProducer(SelectedProducer.GetProducer()))
                    {
                        ProducerSelectList.Remove(SelectedProducer.GetProducer());
                        Producers.Remove(SelectedProducer);
                    }
                }
                SelectedProducer = new ProducerViewModel(BL.BL.NewProducer());
            }
        }

        private RelayCommand _deleteProducerCommand;
        public RelayCommand DeleteProducerCommand
        {
            get => _deleteProducerCommand;
        }

    }
}
