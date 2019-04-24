using System;
using System.Collections.Generic;
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
    }
}
