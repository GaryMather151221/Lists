using System;

namespace Lists
{
    public abstract class BaseLinkedList
    {
        public BaseLinkedList() { }

        /// <summary>
        /// This is the top level node in the tree.
        /// </summary>
        public INode Top { get; set; }

        /// <summary>
        /// Loop the list for a matching node, if found then reset the parents next node to the matched child node to remove from list.
        /// </summary>
        /// <returns>True if the node is found and removed.</returns>
        public virtual bool Delete(INode node)
        {
            INode currentNode = this.Top;
            // Set the previous node here in case we match the first in the list.
            INode previousNode = currentNode;

            while (currentNode != default(Node))
            {
                if (currentNode == node)
                {
                    if (previousNode == currentNode)
                    {
                        // We have matched on the top node, reset the lists top node.
                        this.Top = currentNode.NextNode;
                    }

                    // This just snips out the node from the tree.
                    previousNode.NextNode = currentNode.NextNode;
                    return true;
                }

                // No match so reset the prevous.
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Finds a node in the list given a string value.
        /// </summary>
        public virtual INode Find(string value)
        {
            INode currentNode = this.Top;

            // Loop the tree and if we match then return the current node.
            while (currentNode != default(Node))
            {
                if (String.Equals(currentNode.Value, value, StringComparison.InvariantCultureIgnoreCase))
                {
                    return currentNode;
                }

                currentNode = currentNode.NextNode;
            }

            return null;
        }

        /// <summary>
        /// Return a string array of all the values in the list.
        /// </summary>
        public virtual string[] Values()
        {
            var returnValue = new string[this.Count()];

            INode currentNode = this.Top;
            int i = 0;

            // Loop the tree and add to the array.
            while (currentNode != default(Node))
            {
                returnValue[i] = currentNode.Value;
                i++;
                currentNode = currentNode.NextNode;
            }

            return returnValue;
        }

        /// <summary>
        /// Return the total nodes in the list.
        /// </summary>
        public virtual long Count()
        {
            INode currentNode = this.Top;
            long totalNodes = 0;

            while (currentNode != default(Node))
            {
                totalNodes++;
                currentNode = currentNode.NextNode;
            }

            return totalNodes;
        }

        /// <summary>
        /// Finds and return the last node in the list.
        /// </summary>
        protected INode FindLastNode()
        {
            INode tempNode = this.Top;
            while (tempNode.NextNode != default(INode))
            {
                tempNode = tempNode.NextNode;
            }
            return tempNode;
        }

    }
}
