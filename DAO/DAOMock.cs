using System.Collections.Generic;
using Sturmer.Nazwa.Core;
using Sturmer.Nazwa.Interfaces;
namespace Sturmer.Nazwa.DAO
{
    public class DAOMock : IDAO
    {
        private List<IPlane> _planes;
        private List<IProducer> _producers;

        public DAOMock()
        {
            _producers = new List<IProducer>
            {
                new Producer(ProducerName.Airbus, "UE", 59_000),
                new Producer(ProducerName.Boeing, "USA", 165_500),
                new Producer(ProducerName.Bombardier, "Canada", 27_100),
                new Producer(ProducerName.Cessna, "USA",12_600),
                new Producer(ProducerName.Dassault_Aviation, "France",11_942),
                new Producer(ProducerName.Embraer, "Brasil",19_373),
                new Producer(ProducerName.Iljuszyn, "Russia",90_000),
                new Producer(ProducerName.Lockheed_Martin, "USA",112_000),
                new Producer(ProducerName.Tupolev, "Russia",3_524),
            };

            _planes = new List<IPlane>
            {
                new Plane(_producers.Find(x => x.Name == ProducerName.Airbus), "A380", 15_200),
                new Plane(_producers.Find(x => x.Name == ProducerName.Airbus), "A350-900", 15_00),
                new Plane(_producers.Find(x => x.Name == ProducerName.Boeing), "747-8", 14_815),
                new Plane(_producers.Find(x => x.Name == ProducerName.Boeing), "787-10", 11_910),
                new Plane(_producers.Find(x => x.Name == ProducerName.Bombardier), "Learjet-40", 3_156),
                new Plane(_producers.Find(x => x.Name == ProducerName.Cessna), "206H Stationair", 1_352),
                new Plane(_producers.Find(x => x.Name == ProducerName.Dassault_Aviation), "Falcon 2000LX", 7_400),
                new Plane(_producers.Find(x => x.Name == ProducerName.Embraer), "195", 3_334),
                new Plane(_producers.Find(x => x.Name == ProducerName.Iljuszyn), "Ił-114", 2_100),
                new Plane(_producers.Find(x => x.Name == ProducerName.Lockheed_Martin), "P-3 Orion", 3_835),
                new Plane(_producers.Find(x => x.Name == ProducerName.Tupolev), "Tu-154", 6_000),
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
