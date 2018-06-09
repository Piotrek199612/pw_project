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
            _addedProducer = new ProducerViewModel(BL.BL.NewProducer());
            _addedProducer.Validate();
            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Producers);
            _addNewProducerCommand = new RelayCommand(param => this.AddNewProducer(), param => this.CanAddNewProducer());
            _deleteProducerCommand = new RelayCommand(param => this.DeleteProducer());
            _editProducerCommand = new RelayCommand(param => this.EditProducer(), param => this.CanEditProducer());
        }

        private void GetAllProducers()
        {
            foreach (var producer in BL.BL.GetAllProducers())
            {
                Producers.Add(new ProducerViewModel(producer));
                ProducerSelectList.Add(producer);
            }
        }

        private ProducerViewModel _addedProducer;
        public ProducerViewModel AddedProducer
        {
            get => _addedProducer;
            set
            {
                _addedProducer = value;
                OnPropertyChanged(nameof(AddedProducer));
            }
        }

        private ProducerViewModel _editedProducer;

        private bool CanEditProducer()
        {
            return !EditedProducer.HasErrors;
        }

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
                _editedProducer.Name= value.Name;
                _editedProducer.Country = value.Country;
                _editedProducer.Employment = value.Employment;
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

        private void AddNewProducer()
        {
            if (BL.BL.AddProducer(AddedProducer.GetProducer()))
            {
                Producers.Add(AddedProducer);
                AddedProducer = new ProducerViewModel(BL.BL.NewProducer());
                MessageBox.Show("Producer Added", "Producer Added");
                AddedProducer.Validate();
            }
            else
            {
                MessageBox.Show("Producer Already Exisits", "Producer Exisits");
            }
        }

        private bool CanAddNewProducer()
        {
            return !AddedProducer.HasErrors;
        }

        private RelayCommand _addNewProducerCommand;

        public RelayCommand AddNewProducerCommand
        {
            get => _addNewProducerCommand;
        }

        private RelayCommand _editProducerCommand;

        public RelayCommand EditProducerCommand
        {
            get => _editProducerCommand;
        }

        private void EditProducer()
        {
            if (EditedProducer.Name != null)
            {
                string messageText = $"Do you really want to edit {EditedProducer.Name}";
                MessageBoxResult result = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    BL.BL.UpdateProducer(EditedProducer.GetProducer());
                }
            }
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
                        SelectedProducer = new ProducerViewModel(BL.BL.NewProducer());
                    }
                }
            }
        }

        private RelayCommand _deleteProducerCommand;
        public RelayCommand DeleteProducerCommand
        {
            get => _deleteProducerCommand;
        }

    }
}
