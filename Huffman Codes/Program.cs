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
            string message = "ABCB";
            HuffmanTree huffmanTree = new HuffmanTree(new char[] { 'A', 'B', 'C' }, new int[] { 2, 3, 1 });

            string encode = huffmanTree.Encode(message);
            string decode = huffmanTree.Decode(encode);
        }
    }
}
