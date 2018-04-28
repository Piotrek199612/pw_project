using System.Collections.Generic;
using Sturmer.AircraftCompany.Interfaces;
using Sturmer.AircraftCompany.DAO;

namespace Sturmer.AircraftCompany.BL
{
    public class BL : IBL
    {
        private IDAO _dao;

        public BL()
        {
            _dao = new DAOMock();
        }

        public List<IPlane> GetAllPlanes()
        {
            return _dao.GetAllPlanes();
        }

        public List<IProducer> GetAllProducers()
        {
            return _dao.GetAllProducers();
        }
    }
}
