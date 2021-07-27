using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CSharpIntro
{
    public static class LogicFunctions
    {
        public static string[] CountWordsFromFile(string path)
        {
            var words = File
                .ReadAllText(path)
                .Split(' ')
                .Select(x => Regex.Replace(x, "[^a-zA-Z]", "")).ToArray();

            return words;
        }

        public static int CountVowels(string input)
        {
            var vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var countVowels = 0;

            foreach (var i in input)
            {
                if (vowels.Contains(i))
                {
                    countVowels++;
                }
            }

            return countVowels;
        }

        public static string CovertToPascal(string input)
        {

            
            var words = input.Split(' ');
            var pascalWords = " ";

            foreach (var w in words)
            {
                pascalWords += w.First().ToString().ToUpper() + w.Substring(1);
            }

            return pascalWords;
        }

        public static string ReverseNumbers(string input)
        {
            var numbers = new List<int>();
            var numsSplit = input.Split(',');

            foreach (var n in numsSplit)
            {
                numbers.Add(Convert.ToInt32(n));
            }

            var nums = numbers.OrderByDescending(x => x).ToArray();

            var reverse = "";

            foreach (var n in nums)
            {
                reverse += Convert.ToString(n) + '-';
            }

            return reverse.Substring(0, reverse.Length - 1);
        }

        public static List<int> DisplayDuplicates(string input)
        {
            var nums = input.Split(',').Select(Int32.Parse).ToList();

            var uniqueNums = new List<int>();
            var dupNums = new List<int>();

            foreach (var n in nums)
            {
                if (!uniqueNums.Contains(n))
                    uniqueNums.Add(n);
            }

            foreach (var n in uniqueNums)
            {
                var count = 0;

                foreach (var i in nums)
                {
                    if (i == n) count++;
                }

                if (count > 1) dupNums.Add(n);
            }

            return dupNums;
        }

        public static void ValidateTimeFormat(String[] chars)
        {

            try
            {
                var hrs = Convert.ToInt32(chars[0]);
                var mins = Convert.ToInt32(chars[1]);

                if (hrs >= 0 && hrs <= 23 && mins >= 0 && mins <= 59)
                    Console.WriteLine("Ok");
                else
                    Console.WriteLine("Invalid Time");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Time");
            }

        }

    }
}