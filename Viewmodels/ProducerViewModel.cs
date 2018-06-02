using Sturmer.AircraftCompany.Interfaces;
using System;


namespace Sturmer.AircraftCompany.WPFUI.ViewModels
{
    public class ProducerViewModel : ViewModelBase, ICloneable
    {
        private IProducer _producer;

        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Country
        {
            get => _producer.Country;
            set
            {
                _producer.Country = value;
                OnPropertyChanged("Country");
            }
        }

        public int Employment
        {
            get => _producer.Employment;
            set
            {
                _producer.Employment = value;
                OnPropertyChanged("Employment");
            }
        }

        public void Validate()
        {
            RemoveErrors(nameof(Name));
            RemoveErrors(nameof(Country));
            RemoveErrors(nameof(Employment));

            //TODO Data Validation
        }

        public object Clone()
        {
            var tmp = new ProducerViewModel(BL.BL.NewProducer());
            tmp.Name = Name;
            tmp.Country = Country;
            tmp.Employment = Employment;
            return tmp;
        }
    }
}
