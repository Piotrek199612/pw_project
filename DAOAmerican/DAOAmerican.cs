using System.Collections.Generic;
using Sturmer.AircraftCompany.Core;
using Sturmer.AircraftCompany.Interfaces;

namespace Sturmer.AircraftCompany.DAO
{
    public class DAOAmerican : IDAO
    {
        private List<IPlane> _planes;
        private List<IProducer> _producers;

        public DAOAmerican()
        {
            _producers = new List<IProducer>
            {
                new Producer("Boeing", "USA", 165_500),
                new Producer("Bombardier", "Canada", 27_100),
                new Producer("Cessna", "USA",12_600),
                new Producer("Embraer", "Brasil",19_373),
                new Producer("Lockheed_Martin", "USA",112_000),
            };

            _planes = new List<IPlane>
            {
                new Plane(_producers.Find(x => x.Name == "Boeing"), "747-8", 14_815, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Boeing"), "787-10", 11_910, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Bombardier"), "Learjet-40", 3_156, EngineType.Geared_Turbofan),
                new Plane(_producers.Find(x => x.Name == "Bombardier"), "Q 200", 1_713, EngineType.Turboprop),
                new Plane(_producers.Find(x => x.Name == "Cessna"), "206H Stationair", 1_352, EngineType.Boxer),
                new Plane(_producers.Find(x => x.Name == "Embraer"), "195", 3_334, EngineType.Geared_Turbofan),
                new Plane(_producers.Find(x => x.Name == "Lockheed_Martin"), "P-3 Orion", 3_835, EngineType.Turboprop),
            };
        }

        public List<IPlane> GetAllPlanes()
        {
            return _planes;
        }

        public List<IProducer> GetAllProducers()
        {
            return _producers;
        }
    }
}
