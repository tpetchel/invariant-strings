using System;
using System.Globalization;

namespace invariant_strings
{
    class Program
    { 
        static void Main(string[] args)
        {
            // Lake Sammamish Park
            double currentLat = 47.555698;
            double currentLon = -122.065996;
            // Marymoor Park
            double destinationLat = 47.663747;
            double destinationLon = -122.120879;

            int longest = 0;
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                longest = Math.Max(longest, ci.Name.Length);
            }

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                CultureInfo.CurrentCulture = CultureInfo.ReadOnly(ci);
                string s = FormattableString.Invariant($"{currentLat},{currentLon}:{destinationLat},{destinationLon}");
                Console.WriteLine($"{ci.Name}:{new string(' ', (longest-ci.Name.Length+2))}{s}");
            }
        }
    }
}
