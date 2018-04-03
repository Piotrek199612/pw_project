using System.Collections.Generic;

namespace Sturmer.Nazwa.Interfaces
{
    public interface IBL
    {
        List<IPlane> GetAllPlanes();
        List<IProducer> GetAllProducers();
    }
}
