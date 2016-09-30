using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Monarchs
{
    class Program
    {
        public class Monarch
        {
            public int AscensionYear;
            public string Forename;
            public int RegnalNo;

            public static Monarch FromCsv(string csvLine)
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


            // List the first 3 monarchs
            var limit1 = 3;
            Console.WriteLine(String.Format("\nThe first {0} monarchs are:", limit1));
            {
                int i1 = 0;
                foreach (var item in monarchList)
                {
                    if (i1 < limit1)
                        Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo));
                    i1++;
                }
            }

            // STEP B: Can you repeat the block above using a LINQ statement?
            // STEP B: Insert your solution below


            // List the last 3 monarchs
            var limit2 = 3;
            Console.WriteLine(String.Format("\nThe last {0} monarchs are:", limit2));
            {
                int i2 = 0;
                foreach (var item in monarchList)
                {
                    if (i2 >= monarchList.Count - limit2)
                        Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo));
                    i2++;
                }
            }

            // STEP C: Can you repeat the block above using a LINQ statement?
            // There's more than one way to do this.
            // STEP C: Insert your solution below            


            // List monarchs whose name starts with "E"
            Console.WriteLine("\nThe monarchs with a name starting with E are:");
            {
                int i3 = 0;
                foreach (var item in monarchList)
                {
                    if (item.Forename.StartsWith("E"))
                        Console.WriteLine(String.Format("{0} {1}", item.Forename, item.RegnalNo));
                    i3++;
                }
            }

            // STEP D: Can you repeat the block above using a LINQ statement?
            // STEP D: Insert your solution below


            // List all the different names
            Console.WriteLine("\nThe different names used are:");
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


            // Count how many times each different name occurs
            // This is a good example of code that is tough to write correctly
            Console.WriteLine("\nThe number of times each different name occurs are:");
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


            Console.ReadLine();
        }
    }
}
