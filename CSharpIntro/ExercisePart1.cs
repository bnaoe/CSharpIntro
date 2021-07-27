using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CSharpIntro
{
    class ExercisePart1
    {
        public static void Ex1()
        {
            //Count how many numbers are divisible by 3 between 1 and 100

            var count = 0;
            for (var xx = 1; xx <= 100; xx++)
            {
                if (xx % 3 == 0)
                    count++;
            }

            Console.WriteLine("There {0} numbers divisible by 3, between 1 and 100",count);
        }

        public static void Ex2()
        {
            //Loop instructions to enter a number or ok to exit. If number
            //display sum of all numbers entered.
            
            var sum = 0;
            
            while (true)
            {
                Console.WriteLine("Enter a number or ok to exit.");
                var input = Console.ReadLine();
                var inputToInt = 0;

                if (input.ToLower() == "ok")
                {
                    break;
                }
                else if (int.TryParse(input, out inputToInt))
                {
                    sum += Convert.ToInt32(inputToInt);
                    Console.WriteLine("Current Total Sum is: {0}",sum);
                }
                else
                {
                    Console.WriteLine("Invalid entry try again.");
                    continue;
                }
                
            }
        }
        public static void Ex3()
        {
            //Enter a single number and compute the factorial that number
            Console.WriteLine("Enter a number");


            var input = Convert.ToInt32( Console.ReadLine());
            var factorial = 1;

            for (var xx = input; xx >= 1; xx--)
            {
                factorial *= xx;
            }

            Console.WriteLine("The of {0}! is {1}",input,factorial);

        }

        public static void Ex4()
        {
            //Logic picks a random number and user guesses that number. 
            //User has 4 turns to guess the number correctly.
            var number = new Random().Next(1, 10);
            var xx = 1;

            while (xx <= 4)
            {
                Console.WriteLine("Guess a number between 1 to 10");
                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());
                    if (input == number)
                    {
                        Console.WriteLine("You guessed it right");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect guess again. You only have {0} turns left.", 4 - xx);
                        xx++;
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong, try again.");
                    continue;
                }
                
            }

        }

        public static void Ex5()
        {
            //User enters a set of numbers and algorithm below picks the highest number.

            Console.Write("Enter any set of numbers separated by commas.");
            var input = Console.ReadLine();

            var numbers = input.Split(',');
            var max = Convert.ToInt32(numbers[0]);

            foreach (var n in numbers)
            {
                var num = Convert.ToInt32(n);
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine("Highest number is {0}",max);
        }

        public static void Ex6()
        {
            //Asks the user up to 3 names and displays them in the console 

            var names = new List<string>();

            while (true)
            {
                Console.WriteLine("Please type a name or type ok to exit");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid entry");
                    continue;
                }
                else if (input.ToLower() == "ok")
                    break;

                names.Add(input);
            }

            switch (names.Count)
            {
                case 3:
                    Console.WriteLine("Names {0}, {1} and {2} posted.", names[0], names[1], names[2]);
                    break;
                case 2:
                    Console.WriteLine("Names {0}, {1} posted.", names[0], names[1]);
                    break;
                case 1:
                    Console.WriteLine("Name {0} posted.", names[0]);
                    break;
                default:
                    Console.WriteLine("No names posted.");
                    break;
            }
        }
        public static void Ex7()
        {
            //Logic asks the user to type a name to reverse the name.
            Console.WriteLine("Enter name to reverse.");
            var input = Console.ReadLine();

            var name = new char[input.Length];
            for (var xx=input.Length; xx > 0; xx--)
            {
                name[input.Length - xx] = input[xx - 1];

            }

            Console.WriteLine(name);

        }

        public static void Ex8()
        {
            //Logic continuously asks user to enter numbers and displays unique numbers.
            var numbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Enter a number or enter to exit.");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                    break;

                numbers.Add(Convert.ToInt32(input));
            }

            var uniqueNum = new List<int>();
            Console.WriteLine("Unique numbers are:");

            foreach (var n in numbers)
            {
                if (!uniqueNum.Contains(n))
                {
                    uniqueNum.Add(n);
                    Console.WriteLine(n);
                }
                    
            }
        }

        public static void Ex9()
        {
            //Asks user to enter up to 5 numbers and displays sorted unique numbers

            var numbers = new List<int>();

            while (numbers.Count != 5)
            {
                Console.WriteLine("Enter a number");
                var input = Convert.ToInt32(Console.ReadLine());

                if (!numbers.Contains(input))
                {
                    numbers.Add(input);
                }
                else
                {
                    Console.WriteLine("This number {0} has been previously entered",input);
                    continue;
                }
            }

            numbers.Sort();
            Console.WriteLine("Unique numbers are:");
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }

        }

        public static void Ex10()
        {
            //Description: User to enter 5 numbers separated by comma
            //logic will determine the lowest 3 numbers

            var numbers = new string[5];

            while (true)
            {
                Console.WriteLine("Enter a set of 5 numbers separated by ','");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid entry, please try again");
                    continue;
                }
                else 
                    numbers = input.Split(',');

                    if (numbers.Length < 5)
                    {
                        Console.WriteLine("Less 5 values entered, please try again.");
                        continue;
                        ;
                    }

                    break;
            }

            var nums = new List<int>();

            foreach (var num in numbers)
            {
                nums.Add(Convert.ToInt32(num));
            }

            var smallestNums = new List<int>();
            
            while (smallestNums.Count < 3)
            {
                var min = nums[0];
                foreach (var n in nums)
                {
                    if (n < min)
                    {
                        min = n;
                    }

                }

                smallestNums.Add(min);
                nums.Remove(min);
                Console.WriteLine(min);
            }

            Console.WriteLine("The 3 smallest numbers are: {0},{1},{2}",
                smallestNums[0],smallestNums[1],smallestNums[2]);
        }

        static void Main(string[] args)
        {

            //========= These are my own solutions to the C# Intro exercises. ===========//
            //========= Uncomment method calls to run the exercises. ===========//

            //Ex1();
            //Ex2();
            //Ex3();
            //Ex4();
            //Ex5();
            //Ex6();
            //Ex7();
            //Ex8();
            //Ex9();
            Ex10();

        }

    }
}
