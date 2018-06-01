using System.Collections.Generic;
using Sturmer.AircraftCompany.Core;
using Sturmer.AircraftCompany.Interfaces;
using System.Linq;

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

        public bool DeletePlane(IProducer producer, string name)
        {
            var plane = new Plane(producer, name, 0, 0);
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
                if (CountProducersPlanes(producer) == 0)
                {
                    _producers.Remove(producer);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool DeleteProducer(string name)
        {
            var producer = new Producer(name, "", 0);
            if (IfProducerExists(producer))
            {
                if (CountProducersPlanes(producer) == 0)
                {
                    _producers.Remove(producer);
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<IPlane> GetAllPlanes()
        {
            return _planes;
        }

        public List<IProducer> GetAllProducers()
        {
            return _producers;
        }

        private bool IfPlaneExists(IPlane plane)
        {
            return _planes.Contains(plane);
        }

        private bool IfProducerExists(IProducer producer)
        {
            return _producers.Contains(producer);
        }

        private int CountProducersPlanes(IProducer producer)
        {
            return _planes.Where(x => x.Producer.Equals(producer)).Count();
        }

        public bool UpdatePlane(IProducer producer, string name, int newRange, EngineType newEngineType)
        {
            var plane = new Plane(producer, name, 0, 0);
            if (IfPlaneExists(plane))
            {
                _planes.Where(x => x.Equals(plane)).ToList().ForEach(x => { x.Range = newRange; x.EngineType = newEngineType; });
                return true;
            }
            return false;
        }

        public bool UpdateProducer(string name, string newCountry, int newEmployment)
        {
            var producer = new Producer(name, "", 0);
            if (IfProducerExists(producer))
            {
                _producers.Where(x => x.Equals(producer)).ToList().ForEach(x => { x.Country = newCountry; x.Employment = newEmployment; });
                return true;
            }
            return false;
        }
    }
}
