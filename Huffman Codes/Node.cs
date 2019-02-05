using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Codes
{
    class Node
    {
        public int Frequency { get; set; }
        public char Symbol { get; set; }

       public Node LeftChild;
       public Node RightChild;

        public Node(char symbol, int frequency)
        {
            Frequency = frequency;
            Symbol = symbol;
        }
    }
}
