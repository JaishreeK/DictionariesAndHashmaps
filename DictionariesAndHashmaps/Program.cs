using System;
using System.Collections.Generic;
using System.Linq;
using Console = System.Diagnostics.Debug;

namespace DictionariesAndHashmaps
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //4 2
        //1 2 2 4
        //Output:2
        // Complete the countTriplets function below.
        public static long countTriplets(List<long> arr, long r)
        {
            long countTriples = 0;
            int first,second,third;
            for (int j = 0; j < arr.Count; j++)
            {
                first = j;
                for (int i = j+1; i < arr.Count; i++)
                {
                    if (arr[first] * r == arr[i])
                    {
                        second = i;
                        for (int k = i + 1; k < arr.Count; k++)
                        {
                            if (arr[second] * r == arr[k])
                            {
                                third = k;
                                Console.WriteLine("First,Second,Third: ", first, second, third);
                                countTriples++;
                            }
                        }                                                   
                    }                   
                }
            }
            return countTriples;
        }

        public static long countTriplets2(List<long> arr, long r)
        {
            var dict2 = new Dictionary<long, long>();
            var dict3 = new Dictionary<long, long>();
            long countTriples = 0;
            foreach (long val in arr)
            {
                if (dict3.ContainsKey(val))
                    countTriples += dict3[val];
                if (dict2.ContainsKey(val))
                    if (dict3.ContainsKey(val * r))
                        dict3[val * r] += dict2[val];
                    else
                        dict3[val * r] = dict2[val];
                if (dict2.ContainsKey(val * r))
                    dict2[val * r]++;
                else
                    dict2[val * r] = 1;
                Console.WriteLine(val.ToString(), dict2.ToString(), dict3.ToString());
            }

            return countTriples;
        }


        // Complete the freqQuery function below.
        public static List<int> freqQuery(List<int[]> queries)
        {
            List<int> resultArray = new List<int>();
            List<int> output = new List<int>();
            for (int i=0;i<queries.Count;i++)
            {
                //switch 1,2,3
                switch(queries[i][0])
                {
                    case 1:
                        {
                            resultArray.Add(queries[i][1]);
                            break;
                        }
                    case 2:
                        {
                            if (resultArray.Contains(queries[i][1]))
                                resultArray.Remove(queries[i][1]);
                            break;
                        }
                    case 3:
                        {
                            var intCount =  from values in resultArray group values by values into g
                                            select new { g.Key, Count = g.Count() };

                            //foreach (var item in intCount)
                            //{
                            //    if (item.Count == queries[i][1])
                            //    {
                            //        flag = true;
                            //        break;
                            //    }
                            //}
                            int cnt = intCount.Take(intCount.Count()).Count(r => r.Count == queries[i][1]);

                            if (cnt > 0)                                
                                output.Add(1);
                            else
                                output.Add(0);
                            break;
                        }
                    default:
                        break;
                }            

            }
            return output;
        }

    }
}
