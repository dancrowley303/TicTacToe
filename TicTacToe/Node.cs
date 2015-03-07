using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Node
    {
        private readonly Node parent;
        private List<Node> children;

        public int Score { get; set; }
        public Position Position { get; private set; }
        public ReadOnlyCollection<Node> Children {
            get {
                return new ReadOnlyCollection<Node>(children);
            }
        }

        public Node() : this(null, Position.Undefined) {}
        
        public Node(Node parent, Position position) {
            this.parent = parent;
            this.Position = position;
            children = new List<Node>();
            if (parent != null) {
                parent.AddChild(this);
            }
        }

        public void AddChild(Node node) {
            children.Add(node);
        }
    }
}
