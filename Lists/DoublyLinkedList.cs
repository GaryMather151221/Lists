using System;

namespace Lists
{
    public class DoublyLinkedList : BaseLinkedList, ILinkedList
    {
        public DoublyLinkedList() { }

        /// <summary>
        /// Adds a string as a doubly linked node to the list.
        /// </summary>
        public void Add(string value)
        {
            // Create the new node
            DoubleNode node = new DoubleNode(value);

            // This is the first so just set.
            if (this.Top == default(DoubleNode))
            {
                this.Top = node;
                return;
            }

            // Find the last and set the next/prev nodes.
            var lastNode = base.FindLastNode();
            node.PrevNode = lastNode;
            lastNode.NextNode = node;
        }

        /// <summary>
        /// Loop the list for a matching node, if found then reset the parents next node to the matches child node to remove from list.
        /// </summary>
        /// <returns>True if the node is found and removed.</returns>
        public override bool Delete(INode node)
        {
            INode currentNode = this.Top;
            // Set the previous node here in case we match the first in the list.
            INode previousNode = currentNode;

            while (currentNode != default(INode))
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

                    // Check we are not at the end of the list.
                    if (currentNode.NextNode != default(INode))
                    {
                        currentNode.NextNode.PrevNode = previousNode;

                        if (previousNode == node)
                        {
                            // Remove the link if the node matches the previous node.
                            currentNode.NextNode.PrevNode = null;
                        }
                    }

                    return true;
                }

                // No match so reset the prevous.
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            return false;
        }
    }
}
