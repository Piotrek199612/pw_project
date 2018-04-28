namespace Sturmer.AircraftCompany.Interfaces
{
    public interface IPlane
    {
        IProducer Producer
        {
            set;
            get;
        }
        string Name
        {
            set;
            get;
        }

        int Range
        {
            set;
            get;
        }

        Core.EngineType EngineType
        {
            set;
            get;
        }
    }
}