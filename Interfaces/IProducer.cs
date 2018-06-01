using System;

namespace Sturmer.AircraftCompany.Interfaces
{
    public interface IProducer: IEquatable<IProducer>
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