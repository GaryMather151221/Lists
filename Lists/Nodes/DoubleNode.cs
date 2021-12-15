using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    /// <summary>
    /// Implementation of a node to handle prevous and next nodes.
    /// </summary>
    public class DoubleNode : INode
    {
        /// <summary>
        /// The parent node in the tree.
        /// </summary>
        public INode PrevNode { get; set; }

        /// <summary>
        /// The child node in the tree.
        /// </summary>
        public INode NextNode { get; set; }

        /// <summary>
        /// The Node value.
        /// </summary>
        public string Value { get; set; }

        public DoubleNode(string value)
        {
            this.Value = value;
        }

    }
}
