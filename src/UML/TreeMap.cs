using System;

namespace AgileSoftwareDevelopment.UML {
    public class TreeMap {
        private TreeMapNode topNode = null;

        public void Add(IComparable key, object value) {
            if (topNode is null) {
                topNode = new TreeMapNode(key, value);
            }
            else {
                topNode.Add(key, value);
            }
        }

        public object Get(IComparable key) {
            return topNode?.Find(key);
        }
    }

    internal class TreeMapNode {
        private static readonly int less = 0;
        private static readonly int greater = 1;
        private IComparable key;
        private object value;
        private TreeMapNode[] nodes = new TreeMapNode[2];

        public TreeMapNode(IComparable key, object value) {
            this.key = key;
            this.value = value;
        }

        public object Find(IComparable key) {
            if (key.CompareTo(this.key) == 0) {
                return value;
            }

            return FindSubNodeForKey(SelectSubNode(key), key);
        }

        private int SelectSubNode(IComparable key) {
            return key.CompareTo(this.key) < 0 ? less : greater;
        }

        private object FindSubNodeForKey(int node, IComparable key) {
            return nodes[node]?.Find(key);
        }

        public void Add(IComparable key, object value) {
            if (key.CompareTo(this.key) == 0) {
                this.value = value;
            }
            else {
                AddSubNode(SelectSubNode(key), key, value);
            }
        }

        private void AddSubNode(int node, IComparable key, object value) {
            if (nodes[node] is null) {
                nodes[node] = new TreeMapNode(key, value);
            }
            else {
                nodes[node].Add(key, value);
            }

        }
    }
}
