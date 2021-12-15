using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class Node : INode
    {
        /// <summary>
        /// The value of the node.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The child node in the tree.
        /// </summary>
        public INode NextNode { get; set; }

        public INode PrevNode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Node() { }
        public Node(string value)
        {
            this.Value = value;
        }
    }
}
