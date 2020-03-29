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
            var alphabetFreq = new Dictionary<char, int>()
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
        public void EncondeAndDecode_WithTetxTest()
        {
            string text = "aabbbc";
            var huffmanTree = new HuffmanCodes.HuffmanCodes(text);

            string encode = huffmanTree.Encode(text);
            string decode = huffmanTree.Decode(encode);

            Assert.AreEqual("111100010", encode);
            Assert.AreEqual(text, decode);
        }
    }
}
