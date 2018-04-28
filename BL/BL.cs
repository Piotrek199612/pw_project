using System;
using System.Collections.Generic;
using Sturmer.AircraftCompany.Interfaces;
using System.Reflection;

namespace Sturmer.AircraftCompany.BL
{
    public class BL : IBL
    {
        private IDAO _dao;

        public BL(string daoName)
        {
            var dao = Assembly.UnsafeLoadFrom(daoName + ".dll");
            Type daoType = GetDBName(dao.GetTypes(), "DAO");
            ConstructorInfo constructorInfo = daoType.GetConstructor(new Type[] { });
            _dao = (IDAO)constructorInfo.Invoke(new Type[] { });
        }

        private static Type GetDBName(Type[] types, string className)
        {
            foreach (var t in types)
            {
                if (t.Name.Contains(className))
                {
                    return t;
                }
            }
            return null;
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
