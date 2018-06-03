using Sturmer.AircraftCompany.Core;
using Sturmer.AircraftCompany.Interfaces;

namespace Sturmer.AircraftCompany.WPFUI.ViewModels
{
    public class PlaneViewModel: ViewModelBase
    {
        private IPlane _plane;

        public PlaneViewModel(IPlane plane)
        {
            _plane = plane;
        }

        public IProducer Producer
        {
            get => _plane.Producer;
            set
            {
                _plane.Producer = value;
                OnPropertyChanged("Producer");
            }
        }

        public IPlane GetPlane()
        {
            return _plane;
        }

        public string Name
        {
            get => _plane.Name;
            set
            {
                _plane.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Range
        {
            get => _plane.Range;
            set
            {
                _plane.Range = value;
                OnPropertyChanged("Range");
            }
        }

        public EngineType EngineType
        {
            get => _plane.EngineType;
            set
            {
                _plane.EngineType = value;
                OnPropertyChanged("EngineType");
            }
        }

        public void Validate()
        {
            RemoveErrors(nameof(Producer));
            RemoveErrors(nameof(Name));
            RemoveErrors(nameof(Range));
            RemoveErrors(nameof(EngineType));

            //TODO Data Validation
        }

    }
}
