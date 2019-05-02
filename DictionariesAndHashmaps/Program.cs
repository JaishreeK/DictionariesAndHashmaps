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
            Dictionary<int, int> resultDict = new Dictionary<int, int>();
            Dictionary<int, int> freqDict = new Dictionary<int, int>();
            List<int> output = new List<int>();

            for (int i = 0; i < queries.Count; i++)
            {
                int op= queries[i][0];
                int num = queries[i][1];
                int freq, newFreq;
                //switch 1,2,3
                switch (op)
                {
                    case 3:
                        {
                            if (num == 0)
                                output.Add(1);
                            else
                                if (freqDict.ContainsKey(num))
                                output.Add(1);
                            else
                                output.Add(0);

                            break;
                        }
                    case 1:
                        {
                            if (resultDict.ContainsKey(num))
                            {
                                freq = resultDict[num];
                                resultDict[num]++;
                            }
                            else
                            {
                                freq = 0;
                                resultDict.Add(num, 1);
                            }
                            //remove old freq 
                            if (freq > 0)
                            {
                                if (freqDict.ContainsKey(freq))
                                {
                                    if (freqDict[freq] > 1)
                                        freqDict[freq]--;
                                    else
                                        freqDict.Remove(freq);
                                }
                            }
                            //add new freq
                            newFreq = freq + 1;
                            if (freqDict.ContainsKey(newFreq))
                                freqDict[newFreq]++;
                            else
                                freqDict.Add(newFreq, 1);
                            break;
                        }
                    case 2:
                        {
                            if (resultDict.ContainsKey(num))
                            {
                                freq = resultDict[num];
                                if (freq > 1)
                                    resultDict[num]--;
                                else
                                    resultDict.Remove(num);

                                newFreq = freq - 1;
                                if (newFreq > 0)
                                    //add new freq
                                    if (freqDict.ContainsKey(newFreq))
                                        freqDict[newFreq]++;
                                    else
                                        freqDict.Add(newFreq, 1);

                                //remove old freq
                                if (freq > 0)
                                    if (freqDict.ContainsKey(freq))
                                    {
                                        if (freqDict[freq] > 1)
                                            freqDict[freq]--;
                                        else
                                            freqDict.Remove(freq);
                                    }
                            }
                            break;
                        }


                }
            }
            return output;
        }

    }
}
