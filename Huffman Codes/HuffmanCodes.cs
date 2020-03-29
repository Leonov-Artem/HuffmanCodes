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
        string _text;

        public Dictionary<char, string> CodeTable { get; private set; }

        public HuffmanCodes(string text)
        {
            _text = text;
            Dictionary<char, double> alphabetFrequencies = ComputeFrequencies(text);
            FieldsInitialize(alphabetFrequencies);
        }

        public HuffmanCodes(Dictionary<char, double> alphabetFrequencies)
        {
            FieldsInitialize(alphabetFrequencies);
        }

        public string Encode(string text)
        {
            var encode = new StringBuilder();
            foreach (var symbol in text)
                encode.Append(CodeTable[symbol]);

            return encode.ToString();
        }

        public string Encode()
            => Encode(_text);

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

        private void FieldsInitialize(Dictionary<char, double> alphabetFrequencies)
        {
            _treeRoot = BuildHuffmanTree(alphabetFrequencies);
            CodeTable = new Dictionary<char, string>();
            FillCodeTable(_treeRoot);
        }

        private Dictionary<char, double> ComputeFrequencies(string text)
        {
            var alphabetFrequencies = new Dictionary<char, double>();
            foreach(var symbol in text)
            {
                if (alphabetFrequencies.ContainsKey(symbol))
                    alphabetFrequencies[symbol]++;
                else
                    alphabetFrequencies.Add(symbol, 1);
            }

            return alphabetFrequencies;
        }

        private Node BuildHuffmanTree(Dictionary<char, double> alphabetFrequencies)
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
                    CodeTable[currentNode.Symbol] = bitString;
                    return;
                }

                FillCodeTable(currentNode.LeftChild, bitString + LEFT_BIT_SYMBOL);
                FillCodeTable(currentNode.RightChild, bitString + RIGHT_BIT_SYMBOL);
            }
        }

        private List<Node> ListNodesInit(Dictionary<char, double> alphabetFrequencies)
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
