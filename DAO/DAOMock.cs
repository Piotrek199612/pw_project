using System.Collections.Generic;
using Sturmer.AircraftCompany.Core;
using Sturmer.AircraftCompany.Interfaces;
namespace Sturmer.AircraftCompany.DAO
{
    public class DAOMock : IDAO
    {
        private List<IPlane> _planes;
        private List<IProducer> _producers;

        public DAOMock()
        {
            _producers = new List<IProducer>
            {
                new Producer("Airbus", "UE", 59_000),
                new Producer("Boeing", "USA", 165_500),
                new Producer("Bombardier", "Canada", 27_100),
                new Producer("Cessna", "USA",12_600),
                new Producer("Dassault Aviation", "France",11_942),
                new Producer("Embraer", "Brasil",19_373),
                new Producer("Iljuszyn", "Russia",90_000),
                new Producer("Lockheed_Martin", "USA",112_000),
                new Producer("Tupolev", "Russia",3_524),
            };

            _planes = new List<IPlane>
            {
                new Plane(_producers.Find(x => x.Name == "Airbus"), "A380", 15_200, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Airbus"), "A350-900", 15_00, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Boeing"), "747-8", 14_815, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Boeing"), "787-10", 11_910, EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Bombardier"), "Learjet-40", 3_156, EngineType.Geared_Turbofan),
                new Plane(_producers.Find(x => x.Name == "Cessna"), "206H Stationair", 1_352, EngineType.Boxer),
                new Plane(_producers.Find(x => x.Name == "Dassault Aviation"), "Falcon 2000LX", 7_400,EngineType.Turbofan),
                new Plane(_producers.Find(x => x.Name == "Embraer"), "195", 3_334, EngineType.Geared_Turbofan),
                new Plane(_producers.Find(x => x.Name == "Iljuszyn"), "Ił-114", 2_100, EngineType.Turboprop),
                new Plane(_producers.Find(x => x.Name == "Lockheed_Martin"), "P-3 Orion", 3_835, EngineType.Turboprop),
                new Plane(_producers.Find(x => x.Name == "Tupolev"), "Tu-154", 6_000, EngineType.Turbofan),
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
