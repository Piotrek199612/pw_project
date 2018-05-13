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
            try
            {
                var dao = Assembly.UnsafeLoadFrom(daoName + ".dll");
                Type daoType = GetDaoType(dao.GetTypes(), "IDAO");
                ConstructorInfo constructorInfo = daoType.GetConstructor(new Type[] { });
                _dao = (IDAO)constructorInfo.Invoke(new Type[] { });
            }
            catch(Exception)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while loading library");
                Console.ResetColor();
            }
        }

        private static Type GetDaoType(Type[] types, string interfaceName)
        {
            foreach (var t in types)
            {
                foreach (var i in t.GetInterfaces())
                {
                    if (i.Name == interfaceName)
                        return t;
                }
            }
            return null;
        }

        public List<IPlane> GetAllPlanes()
        {
            if (_dao != null)
            {
                return _dao.GetAllPlanes();
            }
            return new List<IPlane>();
        }

        public List<IProducer> GetAllProducers()
        {
            if (_dao != null)
            {
                return _dao.GetAllProducers();
            }
            return new List<IProducer>();
        }
    }
}
