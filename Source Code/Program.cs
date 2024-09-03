using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CavernProjectAI
{
    /// <summary>
    ///  Author: Francis Pollock
    ///  Student ID: 40618059
    ///  Cavern Coursework Option A
    /// </summary>
    class Program
    {
        /// List to store all of the edges in a list
        public static List<int> Edges = new List<int>();
        /// List to store all caverns
        public static List<Caverns> AllCavs = new List<Caverns>();
        /// List to store a list of temp caverns for comparison when finding best path
        public static List<Caverns> TempCavs = new List<Caverns>();
        /// List to store all caverns that have been traversed
        public static List<Caverns> ListOfCavs = new List<Caverns>();
        /// Dictionary of caverns and its cost
        public static Dictionary<Caverns, double> firstOption = new Dictionary<Caverns, double>();
        /// Dictionary of caverns and its cost to compare to first option to find best path
        public static Dictionary<Caverns, double> secOption = new Dictionary<Caverns, double>();
        /// A dictionary of all Edges, containing the cavern from and to
        public static Dictionary<Caverns, Caverns> Paths = new Dictionary<Caverns, Caverns>();

        static void Main(string[] args)
        {
            /// Input file with cavs, args[0] being the cavern file name taken from commandline
            string inputFile = Path.GetFileName(args[0] + ".cav");
            /// reading in all text from file
            string cavData = File.ReadAllText(inputFile);
            /// Where the file locations are, where the exe is launched from
            string fileLocation = Environment.CurrentDirectory;
            /// Bool to determine if path is found
            bool pathFound = false;
            /// All data from the file, enumarated, split and parsed to int
            List<int> cavDataFormat = ((IEnumerable<string>)cavData.Split(',')).Select<string, int>(new Func<string, int>(int.Parse)).ToList<int>();
            /// The current cavern being explored
            Caverns CurrentCavern = (Caverns)null;
            /// Cavern count is the total amount of caverns, which is the first number in the file
            int cavernCount = cavDataFormat[0];
            /// Cavern range is the range of X, Y coords
            int cavernRange = cavernCount * 2 + 1;
            /// From position 1, assign the cavern, x and y coords to cavern object and assign it to all caverns
            for (int position = 1, ID = 1; position < cavernRange; position = position + 2, ID++)
            {
                Caverns newCav2 = new Caverns(cavDataFormat[position], cavDataFormat[position + 1], ID);
                AllCavs.Add(newCav2);
            }
            /// Adding the first cavern to the firstOption Dictionary
            firstOption.Add(AllCavs[0], 0);
            /// Adding the second cavern to the secondOption Dictionary with the cost to the end cavern
            secOption.Add(AllCavs[0], Methods.CalcDistance(AllCavs[0], AllCavs[AllCavs.Count<Caverns>() - 1]));
            /// assigning the final cavern to a cavern object
            Caverns finalCav = AllCavs.Last();
            /// Add the first cavern to tempCavs
            TempCavs.Add(AllCavs[0]);
            /// Assinging i the cavern rount doubled plus 1, up until the end of cavDataFormat, add the 0 and 1s to edges
            for( int i = cavernCount * 2 + 1; i < cavDataFormat.Count<int>(); i++)
            {
                int edges = cavDataFormat[i];
                Edges.Add(edges);
            }
            /// For all the caverns in the file
            for(int i = 0; i < cavernCount; i++)
            {
                /// For all the caverns currently in AllCavs
                for(int j = 0; j < AllCavs.Count<Caverns>(); j++)
                {
                    /// Create a new cavern file to hold all caverns that contain an edge
                    Caverns newCav3 = AllCavs[i];
                    if(Edges[j + AllCavs.Count * i] == 1)
                    {
                        /// Add caverns with edges to AllCavs
                        AllCavs[j].CloseToCav().Add(newCav3);
                    }
                }
            }
            /// While there is something populating tempCavs
            while(TempCavs.Count<Caverns>() > 0)
            {
                /// Assigning a temp value to result
                double result = double.MaxValue;
                /// For ever caern in tempCavs
                foreach(Caverns newCav4 in TempCavs)
                {
                    /// For every path in the secOption Dictionary
                    foreach(KeyValuePair<Caverns, double> paths in secOption)
                    {
                        /// Assign the cavern and the distance value to a cav object
                        Caverns cav = paths.Key;
                        double tempResult = paths.Value;
                        /// if the current cavern is the same as previous cavern, and the result is more than tempResult
                        if(newCav4 == cav && result > tempResult)
                        {
                            /// Result assigned the tempResult value
                            result = tempResult;
                            /// Current cavern is assigned to cav
                            CurrentCavern = cav;
                        }
                    }
                }
                /// When the currentCavern has reached finalCav
                if(CurrentCavern == finalCav)
                {
                    ///Path has been found, proceed
                    pathFound = true;
                    break;
                }
                /// Removing current cavern from tempCavs
                TempCavs.Remove(CurrentCavern);
                /// Adding the currentCavern to a list of all currently traversed caverns
                ListOfCavs.Add(CurrentCavern);
                ///For every new cavern close to the current cavern
                foreach(Caverns newCav5 in CurrentCavern.CloseToCav())
                {
                    /// if the ListOfCavs does not contain the current caverns close edge
                    if (!ListOfCavs.Contains(newCav5))
                    {
                        /// A new result that holds the cost of going to the new edge
                        double newResult = firstOption[CurrentCavern] + Methods.CalcDistance(CurrentCavern, newCav5);
                        /// If tempCavs does not contain the current cavern being looked at, add to tempList
                        if (!TempCavs.Contains(newCav5))
                        {
                            TempCavs.Add(newCav5);
                        }
                        /// If the new result is more than the old result, proceed to next
                        else if (newResult >= firstOption[newCav5])
                        {
                            continue;
                        }
                        /// Add the path took to the new cavern from the old cavern to the path dictionary
                        if (!Paths.ContainsKey(newCav5))
                        {
                            Paths.Add(newCav5, CurrentCavern);
                            /// Add the new cavern and its cost to the firsOption dictionary
                            firstOption.Add(newCav5, newResult);
                            /// Add the new cavern and the total distance traversed so far
                            secOption.Add(newCav5, firstOption[newCav5] + Methods.CalcDistance(newCav5, finalCav));
                        }
                    }
                }
            }
            /// If a path has been found
            if(pathFound == true)
            {
                /// Create a list of caverns to store the final path that was made
                List<Caverns> finalPathMade = new List<Caverns>();
                /// Calling method to retrive the path took
                finalPathMade = Methods.GetPath(Paths, CurrentCavern);
                /// Empty string to add caverns to for file storing
                string result = "";
                /// for every cavern in the final path, add to the string result in descending order to make it go chronologically
                for (int i = finalPathMade.Count(); i != 0; i--)
                {
                    Caverns finalResult = finalPathMade[i - 1];
                    result = result + finalResult.cavern + " ";
                }
                
                /// Write all the results to a file
                File.WriteAllText(fileLocation + "/" + args[0] + ".csn", result);
            }
            /// If no path was found
            if (pathFound == false)
            {
                /// Returning a 0 in the file if there is no path
                File.WriteAllText(fileLocation + "/" + args[0] + ".csn", "0");
            }

        }
    }
}
