using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCodes
{
    public class HuffmanCodes
    {
        const char LEFT_BIT_SYMBOL = '0';
        const char RIGHT_BIT_SYMBOL = '1';
        readonly int LEFT_NODE = 0;
        readonly int RIGHT_NODE = 1;

        Node _treeRoot;
        readonly char[] _alphabet;
        readonly int[] _frequencies;
        Dictionary<char, string> _codeTable = new Dictionary<char, string>();

        public HuffmanCodes(Dictionary<char, int> alphabetFrequencies)
        {
            _alphabet = alphabetFrequencies.Keys.ToArray();
            _frequencies = alphabetFrequencies.Values.ToArray();
            _treeRoot = BuildHuffmanTree(alphabetFrequencies);
            FillCodeTable(_treeRoot);
        }

        public HuffmanCodes(string text)
        {
            Dictionary<char, int> alphabetFrequencies = ComputeFrequencies(text);
            _alphabet = alphabetFrequencies.Keys.ToArray();
            _frequencies = alphabetFrequencies.Values.ToArray();
            _treeRoot = BuildHuffmanTree(alphabetFrequencies);
            FillCodeTable(_treeRoot);
        }

        public string Encode(string text)
        {
            var encode = new StringBuilder();
            foreach (var symbol in text)
                encode.Append(_codeTable[symbol]);

            return encode.ToString();
        }

        public string Decode(string huffmanCode)
        {
            var currentNode = _treeRoot;
            StringBuilder decode = new StringBuilder();

            foreach (var bit in huffmanCode)
            {
                if (bit == LEFT_BIT_SYMBOL)
                    currentNode = currentNode.LeftChild;
                else if (bit == RIGHT_BIT_SYMBOL)
                    currentNode = currentNode.RightChild;
                else
                    throw new ArgumentException("Код Хаффмана должен содержать только 0 или 1.");

                if (currentNode.IsLeaf)
                {
                    decode.Append(currentNode.Symbol);
                    currentNode = _treeRoot;
                }
            }

            return decode.ToString();
        }

        private Dictionary<char, int> ComputeFrequencies(string text)
        {
            var alphabetFrequencies = new Dictionary<char, int>();
            foreach(var symbol in text)
            {
                if (alphabetFrequencies.ContainsKey(symbol))
                    alphabetFrequencies[symbol]++;
                else
                    alphabetFrequencies.Add(symbol, 1);
            }

            return alphabetFrequencies;
        }

        private Node BuildHuffmanTree(Dictionary<char, int> alphabetFrequencies)
        {
            List<Node> nodes = ListNodesInit(alphabetFrequencies);

            while (nodes.Count >= 2)
            {
                List<Node> orderedNodes = SortAscending(nodes);
                List<Node> taken = orderedNodes.Take(2).ToList();
                Node parent = CreateParentNode(taken);
                nodes.Remove(taken[LEFT_NODE]);
                nodes.Remove(taken[RIGHT_NODE]);
                nodes.Add(parent);
            }

            return nodes.FirstOrDefault();
        }

        private void FillCodeTable(Node currentNode, string bitString = "")
        {
            if (currentNode != null)
            {
                if (currentNode.IsLeaf)
                {
                    _codeTable[currentNode.Symbol] = bitString;
                    return;
                }

                FillCodeTable(currentNode.LeftChild, bitString + LEFT_BIT_SYMBOL);
                FillCodeTable(currentNode.RightChild, bitString + RIGHT_BIT_SYMBOL);
            }
        }

        private List<Node> ListNodesInit(Dictionary<char, int> alphabetFrequencies)
        {
            var nodes = new List<Node>();
            foreach (var pair in alphabetFrequencies)
                nodes.Add(new Node(pair.Key, pair.Value));

            return nodes;
        }

        private List<Node> SortAscending(List<Node> nodes)
            => nodes.OrderBy(node => node.Frequency).ToList<Node>();

        private Node CreateParentNode(List<Node> taken)
        {
            return new Node('*', taken[LEFT_NODE].Frequency + taken[RIGHT_NODE].Frequency)
            {
                LeftChild = taken[LEFT_NODE],
                RightChild = taken[RIGHT_NODE]
            };
        }
    }
}
