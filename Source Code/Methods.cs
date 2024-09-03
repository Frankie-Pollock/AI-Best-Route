using System;
using System.Collections.Generic;

namespace CavernProjectAI
{
    class Methods
    {
        ///Get the distance and return it
        public static double CalcDistance(Caverns cavCurrent, Caverns cavNext)
        {
            /// Euclidean Distance calculation using math
            return Math.Sqrt((Math.Pow(cavNext.ThisX - cavCurrent.ThisX, 2) + Math.Pow(cavNext.ThisY - cavCurrent.ThisY, 2)));   
        }
        /// Method for returning the path that was traversed
        public static List<Caverns> GetPath(Dictionary<Caverns, Caverns> pathTravelled, Caverns cavCur)
        {
            /// Creating a list of pathway that was took using the current cavern passed in by the method
            List<Caverns> pathwayMade = new List<Caverns>
            {
                cavCur
            };
            /// While the Current Cavern has been traversed, add it to the pathwayMade list
            while (pathTravelled.ContainsKey(cavCur))
            {
                cavCur = pathTravelled[cavCur];
                pathwayMade.Add(cavCur);
            }
            /// Return the pathway
            return pathwayMade;

        }
    }

}
