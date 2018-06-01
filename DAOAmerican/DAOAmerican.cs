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

        public bool AddPlane(IPlane plane)
        {
            if (IfPlaneExists(plane))
            {
                return false;
            }
            else
            {
                _planes.Add(plane);
                return true;
            }
        }

        public bool AddPlane(IProducer producer, string name, int range, EngineType engineType)
        {
            var plane = new Plane(producer, name, range, engineType);
            if (IfPlaneExists(plane))
            {
                return false;
            }
            else
            {
                _planes.Add(plane);
                return true;
            }
        }

        public bool AddProducer(IProducer producer)
        {
            if (IfProducerExists(producer))
            {
                return false;
            }
            else
            {
                _producers.Add(producer);
                return true;
            }
        }

        public bool AddProducer(string name, string country, int employment)
        {

            var producer = new Producer(name, country, employment);
            if (IfProducerExists(producer))
            {
                return false;
            }
            else
            {
                _producers.Add(producer);
                return true;
            }
        }

        public bool DeletePlane(IPlane plane)
        {
            if (IfPlaneExists(plane))
            {
                _planes.Remove(plane);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletePlane(IProducer producer, string name, int range, EngineType engineType)
        {
            var plane = new Plane(producer, name, range, engineType);
            if (IfPlaneExists(plane))
            {
                _planes.Remove(plane);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProducer(IProducer producer)
        {
            if (IfProducerExists(producer))
            {
                _producers.Remove(producer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProducer(string name, string country, int employment)
        {
            var producer = new Producer(name, country, employment);
            if (IfProducerExists(producer))
            {
                _producers.Remove(producer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<IPlane> GetAllPlanes()
        {
            return _planes;
        }

        public List<IProducer> GetAllProducers()
        {
            return _producers;
        }

        public bool UpdatePlane(IPlane plane)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdatePlane(IProducer producer, string name, int range, EngineType engineType)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateProducer(IProducer producer)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateProducer(string name, string country, int employment)
        {
            throw new System.NotImplementedException();
        }

        private bool IfPlaneExists(IPlane plane)
        {
            return _planes.Contains(plane);
        }

        private bool IfProducerExists(IProducer producer)
        {
            return _producers.Contains(producer);
        }
    }
}
