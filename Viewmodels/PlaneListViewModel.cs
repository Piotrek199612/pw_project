using Sturmer.AircraftCompany.Core;
using Sturmer.AircraftCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
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
            GetAllPlanes();
            GetAllEngineTypes();

            _editedPlane = new PlaneViewModel(BL.BL.NewPlane());
            _selectedPlane = new PlaneViewModel(BL.BL.NewPlane());
            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Planes);
            _addNewPlaneCommand = new RelayCommand(param => this.AddNewPlane());
            _deletePlaneCommand = new RelayCommand(param => this.DeletePlane());
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

        private PlaneViewModel _selectedPlane;
        public PlaneViewModel SelectedPlane
        {
            get => _selectedPlane;
            set
            {
                _selectedPlane = value;
                OnPropertyChanged(nameof(SelectedPlane));
            }
        }


        private void AddNewPlane()
        {
            if (BL.BL.AddPlane(EditedPlane.GetPlane()))
            {
                Planes.Add(EditedPlane);
                EditedPlane = new PlaneViewModel(BL.BL.NewPlane());
            }
        }

        private RelayCommand _addNewPlaneCommand;

        public RelayCommand AddNewPlaneCommand
        {
            get => _addNewPlaneCommand;
        }

        private RelayCommand _deletePlaneCommand;

        public RelayCommand DeletePlaneCommand
        {
            get => _deletePlaneCommand;
        }

        private void DeletePlane()
        {
            if (SelectedPlane.Name != null && SelectedPlane.Producer != null)
            { 
                string messageText = $"Do you really want to delete {SelectedPlane.Producer.Name} {SelectedPlane.Name}";
                MessageBoxResult result = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (BL.BL.DeletePlane(SelectedPlane.GetPlane()))
                    {
                        Planes.Remove(SelectedPlane);
                    }
                    SelectedPlane = new PlaneViewModel(BL.BL.NewPlane());
                }
            }
        }

    }
}
