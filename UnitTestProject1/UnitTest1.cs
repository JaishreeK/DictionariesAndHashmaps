using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionariesAndHashmaps;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //}

        //[TestMethod]
        //public void TestCountTriplets()
        //{
        //    //4 2
        //    long r = 2;
        //    List<long> input1 = new List<long>() { 1, 2, 2, 4 };
        // //Output:2
        //    long result = Program.countTriplets(input1,r);
        //    Assert.AreEqual(2,result);
        //}

       
        [TestMethod]
        public void TestCountTriplets2()
        {
            // 6 3
            long r = 3;
            List<long> input1 = new List<long>() { 1,3, 9, 9, 27, 81 };
            //Output:6
            long result = Program.countTriplets2(input1, r);
            Assert.AreEqual(6, result);
        }

        //5 2

        //[TestMethod]
        //public void TestCountTriplets3()
        //{
        //    // 6 3
        //    long r = 2;
        //    List<long> input1 = new List<long>() { 1,2,1,2,4 };
        //    //Output:6
        //    long result = Program.countTriplets2(input1, r);
        //    Assert.AreEqual(6, result);
        //}
    }
}
