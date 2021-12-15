using System;

namespace Lists
{
    public class GaryList : BaseLinkedList, ILinkedList
    {
        public GaryList() { }

        private string[] NodeValues = new string[] { };

        public void Add(string value)
        {
            string[] tempArray = new string[this.NodeValues.Length + 1];

            // Copy the old smaller array into the new array.
            for (int i = 0; i < this.NodeValues.Length; i++)
            {
                tempArray[i] = this.NodeValues[i];
            }

            // Finally add the new value.
            tempArray[this.NodeValues.Length] = value;

            this.NodeValues = tempArray;
        }

        /// <summary>
        /// Finds a string in the list given a string value and returns a new node.
        /// </summary>
        public override INode Find(string value)
        {
            foreach(string s in NodeValues)
            {
                if (String.Equals(s,value, StringComparison.InvariantCultureIgnoreCase))
                {
                    return new Node(value);
                }
            }

            return null;
        }

        /// <summary>
        /// Loop the list for a matching node, if found then remove from the list. The node must exist in the list.
        /// </summary>
        /// <returns>True if the node is found and removed.</returns>
        public override bool Delete(INode node)
        {
            string[] tempArray = new string[this.NodeValues.Length - 1];
            int counter = 0;

            // Copy the old smaller array into the new array.
            for (int i = 0; i < this.NodeValues.Length; i++)
            {
                // If we find a match then continue the loop and don't increment the counter.
                if (this.NodeValues[i] == node.Value)
                {
                    continue;
                }
                tempArray[counter] = this.NodeValues[i];
                counter++;
            }

            this.NodeValues = tempArray;

            return true;
        }

        /// <summary>
        /// Return a string array of all the values in the list.
        /// </summary>
        public override string[] Values()
        {
            return this.NodeValues;
        }

        /// <summary>
        /// Return the total strings in the list.
        /// </summary>
        public override long Count()
        {
            return NodeValues.Length;
        }
    }
}
