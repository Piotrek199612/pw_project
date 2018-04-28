using Sturmer.AircraftCompany.Core;

namespace Sturmer.AircraftCompany.DAO
{
    public class Plane : Sturmer.AircraftCompany.Interfaces.IPlane
    {
        private Interfaces.IProducer _producer;
        private string _name;
        private int _range;
        private EngineType _engineType;

        public Plane (Interfaces.IProducer _producer, string _name, int _range, EngineType _engineType)
        {
            Producer = _producer;
            Name = _name;
            Range = _range;
            EngineType = _engineType;
        }

        public override string ToString()
        {
            return string.Format("Producer: {0,-20} Name: {1, -20} Range: {2, -20} Engine Type: {3}", Producer.Name, Name, Range, EngineType);
        }

        public Interfaces.IProducer Producer
        {
            get => _producer;
            set => _producer = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Range
        {
            get => _range;
            set => _range = value;
        }

        public EngineType EngineType
        {
            get => _engineType;
            set => _engineType = value;
        }
    }
}
