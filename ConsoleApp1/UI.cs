using System;
using System.Collections.Generic;
using Sturmer.AircraftCompany.Interfaces;

namespace Sturmer.AircraftCompany.UI
{
    public class UI
    {
        public static void Main(string[] args)
        {
            IBL bl = new BL.BL(Properties.Settings.Default.LibraryName);
            PrintMenu();
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine();
                    PrintPlanes(bl.GetAllPlanes());
                    break;
                case '2':
                    Console.WriteLine();
                    PrintProducers(bl.GetAllProducers());
                    break;
                default:
                    Console.WriteLine("Choose Correct Option");
                    break;
            }
        }

        private static void PrintPlanes(List<IPlane> planes)
        {
            foreach(var plane in planes)
            {
                Console.WriteLine(plane.ToString());
            }
        }

        private static void PrintProducers(List<IProducer> producers)
        {
            foreach(var producer in producers)
            {
                Console.WriteLine(producer.ToString());
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Print all planes");
            Console.WriteLine("2 - Print all producers");
            Console.WriteLine("");
            Console.WriteLine("Choose any option");
        }
    }
}
