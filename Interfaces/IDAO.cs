using System.Collections.Generic;

namespace Sturmer.Nazwa.Interfaces
{
    public interface IDAO
    {
        List<IPlane> GetAllPlanes();
        List<IProducer>GetAllProducers();        
    }
}
