using System;

namespace Lists
{
    public class SinglyLinkedList : BaseLinkedList, ILinkedList
    {
        public SinglyLinkedList() { }

        /// <summary>
        /// Adds a string as a node to the list.
        /// </summary>
        public void Add(string value)
        {
            // Create the new node.
            Node node = new Node(value);

            // This is the first so just set.
            if (this.Top == default(Node))
            {
                this.Top = node;
                return;
            }

            var lastNode = base.FindLastNode();
            lastNode.NextNode = node;
        }
    }
}
