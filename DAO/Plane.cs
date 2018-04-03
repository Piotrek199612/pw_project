namespace Sturmer.Nazwa.DAO
{
    public class Plane : Sturmer.Nazwa.Interfaces.IPlane
    {
        private Interfaces.IProducer _producer;
        private string _name;
        private int _range;

        public Plane (Interfaces.IProducer _producer, string _name, int _range)
        {
            Producer = _producer;
            Name = _name;
            Range = _range;
        }

        public override string ToString()
        {
            return string.Format("Producer: {0,-20} Name: {1, -20} Range: {2}", Producer.Name, Name, Range);
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

    }
}
