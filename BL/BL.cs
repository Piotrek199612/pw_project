using System;
using System.Collections.Generic;
using Sturmer.AircraftCompany.Interfaces;
using System.Reflection;

namespace Sturmer.AircraftCompany.BL
{
    public class BL //: IBL
    {
        private static IDAO _dao;

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

        public static List<IPlane> GetAllPlanes()
        {
            if (_dao != null)
            {
                return _dao.GetAllPlanes();
            }
            return new List<IPlane>();
        }

        public static List<IProducer> GetAllProducers()
        {
            if (_dao != null)
            {
                return _dao.GetAllProducers();
            }
            return new List<IProducer>();
        }

        public static bool AddPlane(IPlane plane)
        {
            return _dao.AddPlane(plane);
        }

        public static bool AddProducer(IProducer producer)
        {
            return _dao.AddProducer(producer);
        }

        public static bool DeletePlane(IPlane plane)
        {
            return _dao.DeletePlane(plane);
        }

        public static bool DeleteProducer(IProducer producer)
        {
            return _dao.DeleteProducer(producer);
        }

        public static bool UpdatePlane(IPlane plane)
        {
            return _dao.UpdatePlane(plane);
        }

        public static bool UpdateProducer(IProducer producer)
        {
            return _dao.UpdateProducer(producer);
        }

        public static IPlane NewPlane()
        {
            return _dao.NewPlane();
        }

        public static IProducer NewProducer()
        {
            return _dao.NewProducer();
        }
    }
}
