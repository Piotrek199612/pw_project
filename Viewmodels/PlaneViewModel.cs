using Sturmer.AircraftCompany.Core;
using Sturmer.AircraftCompany.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sturmer.AircraftCompany.WPFUI.ViewModels
{
    public class PlaneViewModel: ViewModelBase
    {
        private IPlane _plane;
        
        public PlaneViewModel(IPlane plane)
        {
            _plane = plane;
        }

        [Required(ErrorMessage = "Plane must have a producer")]
        public IProducer Producer
        {
            get => _plane.Producer;
            set
            {
                _plane.Producer = value;
                OnPropertyChanged(nameof(Producer));
                Validate();
            }
        }

        public IPlane GetPlane()
        {
            return _plane;
        }

        [Required(ErrorMessage = "Plane must have a name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Plane name length must be less than 100 and greater than 3")]
        public string Name
        {
            get => _plane.Name;
            set
            {
                _plane.Name = value;
                OnPropertyChanged(nameof(Name));
                Validate();
            }
        }

        [Required(ErrorMessage = "Plane range must be set.")]
        [Range(0, int.MaxValue, ErrorMessage = "Range cannot be negative.")]
        public int Range
        {
            get => _plane.Range;
            set
            {
                _plane.Range = value;
                OnPropertyChanged(nameof(Range));
                Validate();
            }
        }

        [Required(ErrorMessage = "Plane must have a engine type")]
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
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            //usunięcie z listy błedów tych właściwości, 
            //dla których już nie ma błędów w validationResults
            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    OnErrorChanged(kv.Key);
                }
            }

            var q = from e in validationResults
                    from m in e.MemberNames
                    group e by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                OnErrorChanged(prop.Key);
            }
        }

    }
}
