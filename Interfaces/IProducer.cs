namespace Sturmer.AircraftCompany.Interfaces
{
    public interface IProducer
    {
        string Name
        {
            set;
            get;
        }

        string Country
        {
            set;
            get;
        }

        int Employment
        {
            set;
            get;
        }
    }
}