using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionariesAndHashmaps;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

//        4
//3 4
//2 1003
//1 16
//3 1

        [TestMethod]
        public void TestFreqQuery()
        {
            // 6 3
            long r = 3;
            List<int[]> input1 = new List<int[]>() {new int[]{3,4}, new int[2]{2,1003},
                                                             new int[2]{1,16},
                                                             new int[2]{3,1}
                                                            };

            //Output:6
            List<int> result = Program.freqQuery(input1);
            for (int i = 0; i < q; i++)
            {
                int[] query = new int[2];

                var p = new Regex("^(\\d+)\\s+(\\d+)\\s*$");
                var m = p.Match(System.Console.ReadLine());
                if (m.Success)
                {
                    query[0] = int.Parse(m.Groups[1].Value);
                    query[1] = int.Parse(m.Groups[2].Value);
                    queries.add(query);
                }

                Assert.AreEqual(new List<int>() { 0, 1 }, result);
            }
        }
}
