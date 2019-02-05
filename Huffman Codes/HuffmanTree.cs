using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Codes
{
    class HuffmanTree
    {
        private Node Root;
        private string[] alphabet;
        private int[] frequencies;

        public HuffmanTree(string[] alphabet, int[] frequencies)
        {
            this.alphabet = alphabet;
            this.frequencies = frequencies;
        }

        public void BuildHuffmanTree()
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < frequencies.Length; i++)
                nodes.Add(new Node(alphabet[i], frequencies[i]));

            while (nodes.Count > 1)
            {
                List<Node> OrderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

                if (OrderedNodes.Count >= 2)
                {
                    // Take first two items
                    List<Node> taken = OrderedNodes.Take(2).ToList<Node>();

                    // Create a parent node by combining the frequencies
                    Node parent = new Node("*", taken[0].Frequency + taken[1].Frequency);
                    parent.LeftChild = taken[0];
                    parent.RightChild = taken[1];

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }
            }
            this.Root = nodes.FirstOrDefault();
        }
    }
}
