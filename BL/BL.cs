using System.Collections.Generic;
using Sturmer.Nazwa.Interfaces;
using Sturmer.Nazwa.DAO;

namespace Sturmer.Nazwa.BL
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
