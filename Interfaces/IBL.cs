using System.Collections.Generic;

namespace Sturmer.AircraftCompany.Interfaces
{
    public interface IBL
    {
        List<IPlane> GetAllPlanes();
        List<IProducer> GetAllProducers();
    }
}
