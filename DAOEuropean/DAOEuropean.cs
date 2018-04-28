using System.Collections.Generic;
using Sturmer.AircraftCompany.Core;
using Sturmer.AircraftCompany.Interfaces;

namespace Sturmer.AircraftCompany.DAO
{
    public class DAOEuropean : IDAO
    {
        private List<IPlane> _planes;
        private List<IProducer> _producers;

        public DAOEuropean()
        {
            _producers = new List<IProducer>
            {
                new Producer("Airbus", "UE", 59_000),
                new Producer("Dassault Aviation", "France",11_942),
                new Producer("Iljuszyn", "Russia",90_000),
                new Producer("Tupolev", "Russia",3_524),
            };

            _planes = new List<IPlane>
            {
                new Plane(_producers.Find(x => x.Name == "Airbus"), "A380", 15_200, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Airbus"), "A350-900", 15_00, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Dassault Aviation"), "Falcon 2000LX", 7_400,EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Iljuszyn"), "Ił-114", 2_100, EngineType.Turboprop),
                new Plane(_producers.Find(x => x.Name == "Iljuszyn"), "Ił-96M", 11_482, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Tupolev"), "Tu-154", 6_000, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Tupolev"), "Tu-204", 6_500, EngineType.Turbofan)
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
