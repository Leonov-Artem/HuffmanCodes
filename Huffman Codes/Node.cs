using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCodes
{
    class Node
    {
        public int Frequency { get; set; }
        public char Symbol { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public bool IsLeaf
        {
            get => LeftChild == null && RightChild == null;
        }

        public Node(char symbol, int frequency)
        {
            Frequency = frequency;
            Symbol = symbol;
        }
    }
}
