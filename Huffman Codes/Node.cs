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
        public string Symbol { get; set; }

        Node LeftChild;
        Node RightChild;
    }
}
