using Sturmer.AircraftCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Sturmer.AircraftCompany.WPFUI.ViewModels
{
    public class ProducerViewModel : ViewModelBase
    {
        private IProducer _producer;

        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
        }

        public IProducer GetProducer()
        {
            return _producer;
        }

        public override string ToString()
        {
            return Name;
        }

        [Required(ErrorMessage = "Producer must have a name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Producer name length must be less than 100 and greater than 3")]
        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                OnPropertyChanged(nameof(Name));
                Validate();
            }
        }

        [Required(ErrorMessage = "Producer must have a country")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Country length must be less than 100 and greater than 3")]
        public string Country
        {
            get => _producer.Country;
            set
            {
                _producer.Country = value;
                OnPropertyChanged(nameof(Country));
                Validate();
            }
        }

        [Required(ErrorMessage = "Producer must have Employment")]
        [Range(0, int.MaxValue, ErrorMessage = "Employment cannot be negative.")]
        public int Employment
        {
            get => _producer.Employment;
            set
            {
                _producer.Employment = value;
                OnPropertyChanged(nameof(Employment));
                Validate();
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
