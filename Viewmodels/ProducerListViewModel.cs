using System.Collections.ObjectModel;
using System.Windows.Data;


namespace Sturmer.AircraftCompany.WPFUI.ViewModels
{
    public class ProducerListViewModel : ViewModelBase
    {
        public ObservableCollection<ProducerViewModel> Producers{ get; set; } = new ObservableCollection<ProducerViewModel>();

        private ListCollectionView _view;

        public ProducerListViewModel()
        {
            OnPropertyChanged(nameof(Producers));
            GetAllProducers();
            EditedProducer = new ProducerViewModel(BL.BL.NewProducer());

            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Producers);
            _addNewProducerCommand = new RelayCommand(param => this.AddNewProducer());
        }

        private void GetAllProducers()
        {
            foreach (var producer in BL.BL.GetAllProducers())
            {
                Producers.Add(new ProducerViewModel(producer));
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

        private void AddNewProducer()
        {
            _addNewProducerCommand = new RelayCommand(param => this.AddNewProducer());
            Producers.Add((ProducerViewModel)EditedProducer.Clone());

        }

        private RelayCommand _addNewProducerCommand;

        public RelayCommand AddNewProducerCommand
        {
            get => _addNewProducerCommand;
        }

    }
}
