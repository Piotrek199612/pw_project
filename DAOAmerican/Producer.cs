namespace Sturmer.AircraftCompany.DAO
{
    public class Producer : Sturmer.AircraftCompany.Interfaces.IProducer
    {
        private string _name;
        private int _employment;
        private string _country;

        public Producer (string producerName, string country, int employment)
        {
            Name = producerName;
            Country = country;
            Employment = employment;
        }

        public Producer ()
        {

        }

        public override string ToString()
        {
            return string.Format("Name: {0,-20} Country: {1,-20} Employment: {2}", Name, Country, Employment);
        }

        public bool Equals(Interfaces.IProducer other)
        {
            if (Name == other.Name)
            {
                return true;
            }
            return false;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Employment
        {
            get => _employment;
            set => _employment = value;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }
    }
}
