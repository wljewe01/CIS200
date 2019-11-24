// Program 4
// CIS 200-01
// Fall 2018
// Due: 11/26/2018
// By:D8649

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 02101); // Test Address 4

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test 1
            Letter letter2 = new Letter(a2, a3, 5.50M);                            // Letter test 2
            Letter letter3 = new Letter(a4, a1, 2.20M);                            // Letter test 3
            GroundPackage gp1 = new GroundPackage(a3, a2, 11, 9, 8, 7.5);        // Ground test object 1
            GroundPackage gp2 = new GroundPackage(a1, a4, 9, 5, 5, 10.5);        // Ground test object 2
            GroundPackage gp3 = new GroundPackage(a4, a3, 2, 3, 4, 6.3);        // Ground test object 3
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object 1
                65, 5.40M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a2, a1, 15, 13, 17,    // Next Day test object 2
                25, 2.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object 1
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a2, a3, 22.5, 35.7, 14.0, // Two Day test object 2
              30.2, TwoDayAirPackage.Delivery.Early);


            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(gp3);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            Console.WriteLine("Original List:"); // outputs original list
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");

            }
            Pause();




            parcels.Sort(); // Sort - uses natural order
            Console.WriteLine("Sorted by Cost (ascending order):");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();



            parcels.Sort(new DescendingZipSort()); // Sort - uses specified Comparer class
            Console.WriteLine("Sorted by zip (descending natural order) using Comparer:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();


        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
