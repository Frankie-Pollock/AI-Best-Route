using System.Collections.Generic;

namespace CavernProjectAI
{
    class Caverns
    {
        /// List to store the paths able to be used from the current cavern
        public List<Caverns> pathways = new List<Caverns>();

        /// List to store the edges 
        public List<int> edges = new List<int>();

        /// Defining the cavern
        public int cavern;

        /// Defining the X position of cavern
        public int Xpos;

        /// Defining the Y position of cavern
        public int Ypos;

        /// Defining the X position of the current cavern
        public int thisX;

        /// Defining the Y position of the current cavern
        public int thisY;

        /// Constructer for the Cavern
        public Caverns(int Xpos, int Ypos, int cavern)
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.cavern = cavern;
        }

        /// Getter and setter for current x
        public int ThisX
        {
            get { return thisX; }
            set { thisX = value; }
        }

        /// Getter and setter for current Y
        public int ThisY
        {
            get { return thisY; }
            set { thisY = value; }
        }

        /// Getter and setter for current cavern
        public int Cavern
        {
            get { return cavern; }
            set { cavern = value; }
        }

        /// Getter and Setter for the edges list for caverns
        public List<int> AvalibleEdges
        {
            get { return edges; }
            set { edges = value; }
        }

        /// Returning the nearest cavern to the current cavern into a list
        public List<Caverns> CloseToCav()
        {
            return this.pathways;
        }
    }
}
