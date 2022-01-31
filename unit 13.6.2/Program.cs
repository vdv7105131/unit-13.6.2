using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

// Ваша задача — написать программу ,которая позволит понять, какие 10 слов чаще всего встречаются в тексте.

namespace unit_13._6._2
{
    class Program
    {
        public static List<string> list = new List<string>();

        static void Main(string[] args)
        {
            string path = @"D:\CSharp\unit13.6.1\Text1.txt";

            TenWords(path);
        }

        static void TenWords(string path)
        {
            string[] readText = File.ReadAllLines(path);

            string[] newReadText = new string[] { };

            for (int i = 0; i < readText.Length; i++)
            {
                string text = Regex.Replace(readText[i], "[-.?!)(,:]", "");
                string[] subs = text.Split(' ');
                foreach (var sub in subs)
                {
                    list.Add(sub);
                    //Console.WriteLine($"Substring: {sub}");
                }
            }

            list.Sort();

            var result = new Dictionary<string, int>();
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == list[i - 1])
                {
                    if (!result.Keys.Contains(list[i]))
                        result.Add(list[i], 1);
                    else result[list[i]]++;
                }
            }

            IOrderedEnumerable<KeyValuePair<string, int>> orderedEnumerable = result.OrderBy(x => x.Value);

            foreach (var c in orderedEnumerable)
            {
                Console.WriteLine(c);
            }
        }
    }
}
