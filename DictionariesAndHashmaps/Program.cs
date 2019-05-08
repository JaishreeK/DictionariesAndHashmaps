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

        //The substrings  and  are common to both strings.
        // Complete the twoStrings function below.
        public static string twoStrings(string s1, string s2)
        {
            var returnStr = "NO";
            Dictionary<char, int> s1CharDict = new Dictionary<char, int>();
            foreach (var char1 in s1)
            {
                if (s1CharDict.ContainsKey(char1))
                    s1CharDict[char1] += 1;
                else
                    s1CharDict.Add(char1, 1);

            }
            foreach (var char2 in s2)
            {
                if (s1CharDict.ContainsKey(char2))
                {
                    returnStr = "YES";
                    break;
                }
            }
            return returnStr;
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

        //    from collections import Counter
        //    def sherlockAndAnagrams(s):
        //    count = 0
        //    for i in range(1, len(s)+1) :
        //        a = ["".join(sorted(s[j: j + i])) for j in range(len(s) - i + 1)]
        //        b = Counter(a)
        //        for j in b:
        //            count+=b[j]*(b[j]-1)/2
        //    return int (count)


//        static int sherlockAndAnagrams(string s)
//        {
//            var matches = 0;

//            for (int i = 1; i <= s.Length - 1; i++)
//            {
//                var a = new List<string>();

//                for (int j = 0; j <= s.Length - i; j++)
//                {
//                    a.Add(new string(s.Substring(j, i).OrderBy(c => c).ToArray()));
//                }

//                var b = (from c in a
//                         group c by c into g
//                         select
//new { Key = g.Key, Count = g.Count() })
//                        .ToDictionary(g => g.Key, g => g.Count);

//                foreach (var v in b.Values)
//                {
//                    matches += v * (v - 1) / 2;
//                }
//            }

//            return matches;
//        }

        //        1
        //cdcd
        // Complete the sherlockAndAnagrams function below.
        public static int sherlockAndAnagrams(string s)
        {
            int AnagramCount = 0;
            int strLength = s.Length;           
           
                       
            for (int cnt = 1; cnt < strLength; cnt++)
            {
                List<string> strCuts = new List<string>();

                for (int k = 0; k < strLength; k++)
                {        
                    strCuts.Add(new string(s.Substring(k, cnt).OrderBy(c => c).ToArray()));                    
                }


                var b = (from c in strCuts
                         group c by c into g
                         select new { g.Key, Count = g.Count() })
                            .ToDictionary(g => g.Key, g => g.Count);
               
                foreach (var value in b.Values)
                {
                    AnagramCount += value * (value - 1) / 2;
                }
            }
            return AnagramCount;
        }

        // Complete the sherlockAndAnagrams function below.
        static int sherlockAndAnagrams(string s)
        {
            int AnagramCount = 0;
            int strLength = s.Length;
            string temp2, temp;
            Dictionary<string, string> strCuts = new Dictionary<string, string>();
            for (int cnt = 1; cnt < strLength; cnt++)
            {
                string indexes = "";
                for (int k = 0; k < strLength; k++)
                {
                    if (strLength - k >= cnt)
                    {
                        temp = s.Substring(k, cnt);
                        indexes = k.ToString() + "," + cnt.ToString();
                        strCuts.Add(indexes, temp);
                    }
                }
            }
            foreach (var key in strCuts.Keys)
            {
                string[] IndexnCnt = key.Split(',');
                int cnt = Int32.Parse(IndexnCnt[1]);
                int stIndex = Int32.Parse(IndexnCnt[0]);
                for (int i = stIndex + 1; i < strLength; i++)
                {
                    if (strLength - i >= cnt)
                    {
                        temp = strCuts[key]; ;
                        temp2 = s.Substring(i, cnt);
                        if (Check_Anagram(temp, temp2))
                            AnagramCount++;
                    }
                    else
                        break;
                }
            }
            return AnagramCount;
        }

        public static bool Check_Anagram(string temp, string temp2)
        {
            if (temp.Length != temp2.Length)
                return false;

            
            List<char> tempList1 = new List<char>(temp.ToCharArray());
            List<char> tempList2 = new List<char>(temp2.ToCharArray());
                       
            return tempList1.OrderBy(x => x).SequenceEqual(tempList2.OrderBy(y => y));

            //string resultTemp = new string(tempChars);
            //string resultTemp2 = new string(temp2Chars);

            //if (resultTemp == resultTemp2)
            //return true;
            //else
            //    return false;
        }


      //Hacker Rank Code for FreqQuery, final one which worked and passed all the tests
      // Complete the freqQuery function below.
        //static List<int> freqQuery(int[,] queries)
        //{
        //    Dictionary<int, int> resultDict = new Dictionary<int, int>();
        //    Dictionary<int, int> freqDict = new Dictionary<int, int>();
        //    List<int> output = new List<int>();
        //    int rowCount = queries.GetLength(0);
        //    for (int i = 0; i < rowCount; i++)
        //    {
        //        int op = queries[i, 0];
        //        int num = queries[i, 1];
        //        int freq = 0, newFreq;
        //        //switch 1,2,3
        //        switch (op)
        //        {
        //            case 3:
        //                {
        //                    if (num == 0)
        //                        output.Add(1);
        //                    else
        //                        if (freqDict.ContainsKey(num))
        //                        output.Add(1);
        //                    else
        //                        output.Add(0);

        //                    break;
        //                }
        //            case 1:
        //                {
        //                    if (resultDict.ContainsKey(num))
        //                    {
        //                        freq = resultDict[num];
        //                        resultDict[num]++;
        //                    }
        //                    else
        //                    {
        //                        resultDict.Add(num, 1);
        //                    }
        //                    //remove old freq 
        //                    if (freq > 0)
        //                    {
        //                        if (freqDict.ContainsKey(freq))
        //                        {
        //                            if (freqDict[freq] > 1)
        //                                freqDict[freq]--;
        //                            else
        //                                freqDict.Remove(freq);
        //                        }
        //                    }
        //                    //add new freq
        //                    newFreq = freq + 1;
        //                    if (freqDict.ContainsKey(newFreq))
        //                        freqDict[newFreq]++;
        //                    else
        //                        freqDict.Add(newFreq, 1);
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    if (resultDict.ContainsKey(num))
        //                    {
        //                        freq = resultDict[num];
        //                        if (freq > 1)
        //                            resultDict[num]--;
        //                        else
        //                            resultDict.Remove(num);

        //                        newFreq = freq - 1;
        //                        if (newFreq > 0)
        //                            //add new freq
        //                            if (freqDict.ContainsKey(newFreq))
        //                                freqDict[newFreq]++;
        //                            else
        //                                freqDict.Add(newFreq, 1);

        //                        //remove old freq
        //                        if (freq > 0)
        //                            if (freqDict.ContainsKey(freq))
        //                            {
        //                                if (freqDict[freq] > 1)
        //                                    freqDict[freq]--;
        //                                else
        //                                    freqDict.Remove(freq);
        //                            }
        //                    }
        //                    break;
        //                }

        //        }
        //    }
        //    return output;
        //}

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //    int q = Convert.ToInt32(Console.ReadLine().Trim());

        //    int[,] queries = new int[q, 2];
        //    /*var p  = new Regex("^(\\d+)\\s+(\\d+)\\s*$");
        //    for (int i = 0; i < q; i++) 
        //    {
        //        int[] query = new int[2];
        //        var m = p.Match(Console.ReadLine());
        //        if (m.Success) 
        //        {
        //            query[0] = int.Parse(m.Groups[1].Value);
        //            query[1] = int.Parse(m.Groups[2].Value);
        //            queries.Add(query);
        //        }
        //    } */

        //    string[] queryTemp = new string[q];
        //    for (int i = 0; i < q; i++)
        //    {
        //        queryTemp = Console.ReadLine().Split(' ');
        //        for (int j = 0; j < 2; j++)
        //        {
        //            queries[i, j] = Convert.ToInt32(queryTemp[j]);
        //        }
        //    }
        //    List<int> ans = freqQuery(queries);

        //    textWriter.WriteLine(String.Join("\n", ans));

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
    }
}
