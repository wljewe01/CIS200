using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    public class DescendingZipSort : Comparer<Parcel>
    {
        // Precondition:  None
        // Postcondition: Reverses natural time order, so descending
        //                When p1 < p2, method returns positive #
        //                When p1 == p2, method returns zero
        //                When p1 > p2, method returns negative #
        public override int Compare(Parcel p1, Parcel p2)
        {
            // Ensure correct handling of null values (in .NET, null less than anything)
          
            if (p1.DestinationAddress.Zip.ToString() == null && p2.DestinationAddress.Zip.ToString() == null) // Both null?
                return 0;                 // Equal

            if (p1.DestinationAddress.Zip.ToString() == null) // only p1 is null?
                return -1;  // null is less than any actual time

            if (p2.DestinationAddress.Zip.ToString() == null) // only p2 is null?
                return 1;   // Any actual time is greater than null

            return (-1) * p1.DestinationAddress.Zip.ToString().CompareTo(p2.DestinationAddress.Zip.ToString()); // Reverses natural order, so descending
        }
    }
}
