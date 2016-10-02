using System; // The program will not function without this. 
using System.Collections.Generic; // The program will not be able to function as lists are part of collections 
using System.Linq; // The LINQ function will not work without this namespace
using System.IO; // Without this namespace it would have difficulty reading files as part of iinput and output

namespace Monarchs
{
    class Program
    {
        public class Monarch
        {
            public int AscensionYear;
            public string Forename;
            public int RegnalNo;

            public static Monarch FromCsv(string csvLine) // Basically from a comma separated value, parse it to a string called "csvLine"
            {
                string[] fields = csvLine.Split(',');
                Monarch m = new Monarch();
                m.AscensionYear = Convert.ToInt32(fields[0]);
                m.Forename = fields[1];
                m.RegnalNo = Convert.ToInt32(fields[2]);
                return m;
            }
        }

        static void Main(string[] args)
        {
            // 1. The longer way
            //List<Monarch> monarchList = new List<Monarch>();

            //// read lines from a CSV file and skip the first line
            //var lines = File.ReadAllLines("Monarchs.csv").Skip(1);

            //Monarch m = new Monarch();
            //foreach (var line in lines)
            //{
            //    m = Monarch.FromCsv(line);
            //    Console.WriteLine(m.Forename);
            //    monarchList.Add(m);
            //}

            // 2. The shorter way
            List<Monarch> monarchList
                = File.ReadAllLines("Monarchs.csv") // read lines from CSV file
                .Skip(1)                            // skip the header line
                .Select(r => Monarch.FromCsv(r))    // from each line, construct a new object
                .ToList();                          // convert results to a list

            // Output list
            foreach (var item in monarchList)
                Console.WriteLine(String.Format("{0}\t{1} {2}", item.AscensionYear, item.Forename, item.RegnalNo));

            // Count the monarchs
            {
                int count = 0;
                foreach (var item in monarchList)
                {
                    count++;
                }
                Console.WriteLine(String.Format("\nThere are {0} monarchs listed", count));
            }

            // STEP A: Not actually LINQ, but can you repeat the block above using just a single statement?
            // STEP A: Insert your solution below

            #region STEP A Solution
            
            Console.WriteLine(monarchList.Count); // This is the actual answer
                                                  // Displays the number of elements (Monarchs) in a list. Using the Console.WriteLine.
                                                  // .count * Allows me to get access to the number of elements within a list
            #endregion

            #region STEP A + String Formattting
            
            var monarchCount = monarchList.Count;

            Console.WriteLine(String.Format("There are {0} monarchs", monarchCount));
            #endregion


            // List the first 3 monarchs
            var limit1 = 3;
            Console.WriteLine(String.Format("\nThe first {0} monarchs are: \n", limit1));
            {
                int i1 = 0;
                foreach (var item in monarchList)
                {
                    if (i1 < limit1)
                        Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo));
                    i1++;
                }
            }

            Console.WriteLine("\n");

            // STEP B: Can you repeat the block above using a LINQ statement?
            // STEP B: Insert your solution below

            #region STEP B Solution

            var results = monarchList // Creates a varaible results and assigns it to monarchList
                         .Take(3); // Takes the  first 3 elements of the list
            foreach (var item in results) // For each item in results
                Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo)); // Display the results in format Forename + RegnalNo
            #endregion

            // List the last 3 monarchs
            var limit2 = 3;
            Console.WriteLine(String.Format("\nThe last {0} monarchs are:\n", limit2));
            {
                int i2 = 0;
                foreach (var item in monarchList)
                {
                    if (i2 >= monarchList.Count - limit2)
                        Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo));
                    i2++;
                }
            }

            Console.WriteLine("\n");

            // STEP C: Can you repeat the block above using a LINQ statement?
            // There's more than one way to do this.
            // STEP C: Insert your solution below 

            #region STEP C Solution       

            var lastThree = monarchList // Creates a varaible called lastThree and assigns it to monarchList
                            .Skip(38) // Skip the first 23 elements of the list
                            .Take(3); // Take the last 3 element of the list
              foreach (var item in lastThree ) // For each varaible item in the lastThree
            Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo)); // Display the results

            #endregion

            // List monarchs whose name starts with "E"
            Console.WriteLine("\nThe monarchs with a name starting with E are:\n");
            {
                int i3 = 0;
                foreach (var item in monarchList)
                {
                    if (item.Forename.StartsWith("E"))
                        Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo));
                    i3++;
                }
            }

            Console.WriteLine("\n");

            // STEP D: Can you repeat the block above using a LINQ statement?
            // STEP D: Insert your solution below

            #region STEP D Solution

            var containsE = monarchList
                            .Where (item => item.Forename.StartsWith("E"));
                 foreach (var item in containsE)
                        Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo));
            #endregion

            // List all the different names
            Console.WriteLine("\nThe different names used are:\n");
            {
                var previousName = "";
                var sortedList = monarchList.OrderBy(r => r.Forename);
                foreach (var item in sortedList)
                {
                    if (item.Forename == previousName)
                    { } // do nothing
                    else
                    {
                        previousName = item.Forename;
                        Console.WriteLine(String.Format("{0}", item.Forename));
                    }
                }
            }

            // STEP E: Can you repeat the block above using a LINQ statement?
            // STEP E: Insert your solution below

            // STEP E Solution

            /*var distinctNames = monarchList.OrderBy(a => a.Forename)
                               .Distinct();
                foreach (var item in distinctNames)
                    Console.WriteLine(String.Format("{0}", item.Forename));*/

            Console.Write("\n");

            #region STEP E Solution

            var distinctNames = monarchList.OrderBy(a => a.Forename)
                                .Select(b => b.Forename)
                                .Distinct();
                foreach (var item in distinctNames)
                    Console.WriteLine(String.Format("{0}", item));
            #endregion

            // Count how many times each different name occurs
            // This is a good example of code that is tough to write correctly
            Console.WriteLine("\nThe number of times each different name occurs are:\n");
            {
                int count5 = 0;
                var previousName5 = "";
                var sortedList5 = monarchList.OrderBy(r => r.Forename);
                foreach (var item in sortedList5)
                {
                    if (item.Forename == previousName5)
                    {
                        count5++;
                    }
                    else
                    {
                        if (count5 > 0)
                            Console.WriteLine(String.Format("{0}: {1}", count5, previousName5));
                        previousName5 = item.Forename;
                        count5 = 1;
                    }
                }
                if (count5 > 0)
                    Console.WriteLine(String.Format("{0}: {1}", count5, previousName5));
            }

            // STEP F: Can you repeat the block above using a LINQ statement?
            // STEP F: Insert your solution below

            Console.Write("\n");

            #region STEP F Solution

            var countNames = monarchList.OrderBy(r => r.Forename)
                .GroupBy(a => a.Forename)
                .Distinct();
            foreach (var item in countNames)
                Console.WriteLine(String.Format("{0}: {1}", item.Count() , item.Key));
            #endregion

            Console.ReadLine();
        }
    }
}
