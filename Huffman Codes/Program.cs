using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTree huffmanTree = new HuffmanTree(new char[] { 'A', 'B', 'C' }, new int[] { 2, 3, 1 });
            string encode = huffmanTree.Encode("BBBBB");
        }
    }
}
