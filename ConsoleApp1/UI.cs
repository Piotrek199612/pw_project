using System;
using System.Collections.Generic;
using Sturmer.Nazwa.BL;
using Sturmer.Nazwa.Interfaces;

namespace ConsoleApp1
{
    class UI
    {
        static void Main(string[] args)
        {
            IBL bl = new BL();
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

        static private void PrintPlanes(List<IPlane> planes)
        {
            foreach(var plane in planes)
            {
                Console.WriteLine(plane.ToString());
            }
        }

        static private void PrintProducers(List<IProducer> producers)
        {
            foreach(var producer in producers)
            {
                Console.WriteLine(producer.ToString());
            }
        }

        static private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Print all planes");
            Console.WriteLine("2 - Print all producers");
            Console.WriteLine("");
            Console.WriteLine("Choose any option");
        }
    }
}
