using Sturmer.AircraftCompany.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace Sturmer.AircraftCompany.WPFUI.ViewModels
{
    public class PlaneListViewModel : ViewModelBase
    {
        public ObservableCollection<PlaneViewModel> Planes { get; set; } = new ObservableCollection<PlaneViewModel>();
        public List<EngineType> EngineTypes { get; } = new List<EngineType>();
        private ListCollectionView _view;

        public PlaneListViewModel()
        {
            OnPropertyChanged("Planes");
            GetAllPlanes();
            GetAllEngineTypes();
            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Planes);
            _addNewPlaneCommand = new RelayCommand(param => this.AddNewPlane());
        }

        private void GetAllPlanes()
        {
            foreach (var plane in BL.BL.GetAllPlanes())
            {
                Planes.Add(new PlaneViewModel(plane));
            }
        }

        private void GetAllEngineTypes()
        {
            foreach (var engine in Enum.GetValues(typeof(EngineType)))
            {
                EngineTypes.Add((EngineType)engine);
            }
        }

        private PlaneViewModel _editedPlane;
        public PlaneViewModel EditedPlane
        {
            get => _editedPlane;
            set
            {
                _editedPlane = value;
                OnPropertyChanged(nameof(EditedPlane));
            }
        }

        private void AddNewPlane()
        {
            EditedPlane = new PlaneViewModel(BL.BL.NewPlane());
        }

        private RelayCommand _addNewPlaneCommand;

        public RelayCommand AddNewPlaneCommand
        {
            get => _addNewPlaneCommand;
        }

    }
}
