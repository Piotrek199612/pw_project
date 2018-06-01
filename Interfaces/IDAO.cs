using System.Collections.Generic;

namespace Sturmer.AircraftCompany.Interfaces
{
    public interface IDAO
    {
        List<IPlane> GetAllPlanes();
        List<IProducer>GetAllProducers();

        bool AddPlane(IPlane plane);
        bool AddPlane(IProducer producer, string name, int range, Core.EngineType engineType);
        bool AddProducer(IProducer producer);
        bool AddProducer(string name, string country, int employment);

        bool DeletePlane(IPlane plane);
        bool DeletePlane(IProducer producer, string name, int range, Core.EngineType engineType);
        bool DeleteProducer(IProducer producer);
        bool DeleteProducer(string name, string country, int employment);

        bool UpdatePlane(IPlane plane);
        bool UpdatePlane(IProducer producer, string name, int range, Core.EngineType engineType);
        bool UpdateProducer(IProducer producer);
        bool UpdateProducer(string name, string country, int employment);
    }
}
