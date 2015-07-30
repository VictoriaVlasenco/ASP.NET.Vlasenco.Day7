using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4Library;

namespace Task4Test
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void BinarySearch_SortedString()
        {
            string[] array = { "A", "B", "C", "D" };
            int index = Search.SortAndFindBinary(array, "D", string.Compare);
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void BinarySearch_UnsortedString()
        {
            string[] array = {"D", "B", "C", "A"};
            int index = Search.SortAndFindBinary(array, "B", string.Compare);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_Int()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int index = Search.SortAndFindBinary(array, 3, (i, i1) =>
            {
                if (i > i1)
                {
                    return 1;
                }
                if (i < i1)
                {
                    return -1;
                }
                return 0;
            });
            Assert.AreEqual(2, index);
        }
    }
}
