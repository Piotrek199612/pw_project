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
            _addedPlane = new PlaneViewModel(BL.BL.NewPlane());
            _addedPlane.Validate();
            _selectedPlane = new PlaneViewModel(BL.BL.NewPlane());
            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Planes);
            _addNewPlaneCommand = new RelayCommand(param => this.AddNewPlane(), param => this.CanAddNewPlane());
            _deletePlaneCommand = new RelayCommand(param => this.DeletePlane());
            _editPlaneCommand = new RelayCommand(param => this.EditPlane(), param => this.CanAddEditPlane());
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

        private PlaneViewModel _addedPlane;
        public PlaneViewModel AddedPlane
        {
            get => _addedPlane;
            set
            {
                _addedPlane = value;
                OnPropertyChanged(nameof(AddedPlane));
            }
        }

        private PlaneViewModel _editedPlane;

        private bool CanAddEditPlane()
        {
            return !EditedPlane.HasErrors;
        }

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
                _editedPlane.Producer = value.Producer;
                _editedPlane.Name = value.Name;
                _editedPlane.Range = value.Range;
                _editedPlane.EngineType = value.EngineType;
                _selectedPlane = value;
                OnPropertyChanged(nameof(SelectedPlane));
            }
        }


        private void AddNewPlane()
        {
            if (BL.BL.AddPlane(AddedPlane.GetPlane()))
            {
                Planes.Add(AddedPlane);
                AddedPlane = new PlaneViewModel(BL.BL.NewPlane());
                MessageBox.Show("Plane Added", "Plane Added");
                AddedPlane.Validate();
            }
            else
            {
                MessageBox.Show("Plane Already Exisits", "Plane Exisits");
            }
        }

        private RelayCommand _addNewPlaneCommand;

        private bool CanAddNewPlane()
        {
            return !AddedPlane.HasErrors;
        }

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

        private RelayCommand _editPlaneCommand;

        public RelayCommand EditPlaneCommand
        {
            get => _editPlaneCommand;
        }

        private void EditPlane()
        {
            if (EditedPlane.Name != null && EditedPlane.Producer != null)
            {
                string messageText = $"Do you really want to edit {EditedPlane.Producer.Name} {EditedPlane.Name}";
                MessageBoxResult result = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    BL.BL.UpdatePlane(EditedPlane.GetPlane());
                }
            }
        }

    }
}
