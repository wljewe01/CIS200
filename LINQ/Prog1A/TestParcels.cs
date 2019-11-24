// Program 1B
// CIS 200-01
// Fall 2018
// Due: 10/03/2018
// By: D8649

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels, uses several LINQ queries to organize them, 
// and outputs the queries.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and selected 
        //                LINQ results are displayed
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
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Charlotte Jones", "123 Maple St. ",
              "Clarksville", "IN", 47129); // Test Address 5
            Address a6 = new Address("Kayla Kay", "989 Chipp Avenue", "Apt. 2",
              "Salem", "IN", 52143); // Test Address 6
            Address a7 = new Address("Hunter Ansleigh", "554 Herrick Way", 
              "Jeffersonville", "IN", 47130); // Test Address 7
            Address a8 = new Address("Mckenzie Caldwell", "2201 Morgan Avenue", 
              "Charlestown", "KY", 42450); // Test Address 8


            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object 1
            Letter letter2 = new Letter(a8, a4, 2.05M);                            // Letter test object 2
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object 1
            GroundPackage gp2 = new GroundPackage(a7, a6, 22, 15, 16, 28);         // Ground test object 2
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object 1
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a6, a5, 50, 20, 15,    // Next Day test object 2
              120, 9.75M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object 1
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a1, a7, 20.75, 16.20, 20.50, // Two Day test object 2
                      120.75, TwoDayAirPackage.Delivery.Early);





            // List of test parcels
            List<Parcel> parcels;      
            parcels = new List<Parcel>();

            // Populate list
            parcels.Add(letter1); 
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            //Output Original List
            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }




            //Output LINQ query sorted by destination zip in descending order 
            Console.WriteLine("Sort By Destination Zip:");
            Console.WriteLine("====================");

            // Holds results of LINQ to sort invoices by destination
            // address zip in descending order 
            var sortByDest = 
                from p in parcels
                orderby p.DestinationAddress.Zip descending 
                select p;

            // foreach loop outputs each parcel selected by query 
            foreach (Parcel p in sortByDest)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }





            // Output LINQ query sorted by cost in ascending order 
            Console.WriteLine("Sorted by Cost:");
            Console.WriteLine("====================");

            // Holds results of LINQ to sort invoices by cost  
            // in ascending order 
            var sortByPrice = 
                from p in parcels
                orderby p.CalcCost()
                select p;

            // foreach loop outputs each parcel selected by query
            foreach (Parcel p in sortByPrice)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }




            //Output LINQ query sorted by type and cost 
            Console.WriteLine("Sorted by Type and Cost List:");
            Console.WriteLine("====================");

            // Holds results of LINQ to sort invoices by Type
            // in ascending order and sorts again by cost in 
            // descending order
            var sortByTypeAndCost =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            // foreach loop outputs each parcel selected by query
            foreach (Parcel p in sortByTypeAndCost)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }





            //Output LINQ query sorted by package type and then by weight 
            Console.WriteLine("Sorted by Airpackage and Weight");
            Console.WriteLine("====================");

            // Holds results of LINQ to select only AirPackages 
            // if they are heavy and then sorts them by weight
            // in descending order
            var sortByWeight = 
               from p in parcels
               let ap = p as AirPackage
               where (ap != null) &&
               ap.IsHeavy()
               orderby ap.Weight descending
               select ap;


            // foreach loop outputs each parcel selected by query
            foreach (Parcel p in sortByWeight)
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
