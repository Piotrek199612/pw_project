using System.Collections.Generic;

namespace Sturmer.AircraftCompany.Interfaces
{
    public interface IDAO
    {
        List<IPlane> GetAllPlanes();
        List<IProducer>GetAllProducers();        
    }
}
