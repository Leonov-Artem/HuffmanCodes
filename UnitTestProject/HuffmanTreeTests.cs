using System.Collections.Generic;
using HuffmanCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class HuffmanTreeTests
    {
        [TestMethod]
        public void EncondeAndDecode_WithGivenFrequenciesTest()
        {
            string message = "aabbbc";
            var alphabetFreq = new Dictionary<char, double>()
            {
                ['a'] = 2,
                ['b'] = 3,
                ['c'] = 1
            };
            var huffmanTree = new HuffmanCodes.HuffmanCodes(alphabetFreq);

            string encode = huffmanTree.Encode(message);
            string decode = huffmanTree.Decode(encode);

            Assert.AreEqual("111100010", encode);
            Assert.AreEqual(message, decode);
        }

        [TestMethod]
        public void EncondeAndDecode_WithTextTest()
        {
            string text = "aabbbc";
            var huffmanTree = new HuffmanCodes.HuffmanCodes(text);

            string encode = huffmanTree.Encode(text);
            string decode = huffmanTree.Decode(encode);

            Assert.AreEqual("111100010", encode);
            Assert.AreEqual(text, decode);
        }

        [TestMethod]
        public void EncondeAndDecode_WithPropabilitiesTest()
        {
            var alphabetProbabilities = new Dictionary<char, double>()
            {
                ['1'] = 0.4,
                ['2'] = 0.3,  
                ['3'] = 0.2, 
                ['4'] = 0.04, 
                ['5'] = 0.03, 
                ['6'] = 0.015,
                ['7'] = 0.015
            };
            var huffmanTree = new HuffmanCodes.HuffmanCodes(alphabetProbabilities);
            var b = huffmanTree.CodeTable;
        }
    }
}
