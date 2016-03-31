using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //SwapElements();
            //MultiplicationTables();
            //UniqueElements();
            //SetIntersection();
            //WordToDigit();
            //HappyNumbers();
            //FizzBuzz();
            //BitPositions();
            //FileSize();
            //RightMostChar();
            //SelfDescribingNumbers();
            //NModM();
            //HexToDecimal();
            //ArmstrongNumbers();
            //BeautifulStrings();
            QueryBoard();
        }

        /// <summary>
        /// There is a board (matrix). Every cell of the board contains one integer, which is 0 initially. 
        /// The next operations can be applied to the Query Board: 
        /// SetRow i x: it means that all values in the cells on row "i" have been changed to value "x" after this operation. 
        /// SetCol j x: it means that all values in the cells on column "j" have been changed to value "x" after this operation. 
        /// QueryRow i: it means that you should output the sum of values on row "i". 
        /// QueryCol j: it means that you should output the sum of values on column "j". 
        /// The board's dimensions are 256x256 
        /// "i" and "j" are integers from 0 to 255 
        /// "x" is an integer from 0 to 31 
        /// 
        /// INPUT SAMPLE:
        /// Your program should accept as its first argument a path to a filename. Each line in this file contains an operation of a query. E.g.
        /// SetCol 32 20
        /// SetRow 15 7
        /// SetRow 16 31 
        /// QueryCol 32
        /// SetCol 2 14
        /// QueryRow 10
        /// SetCol 14 0
        /// QueryRow 15
        /// SetRow 10 1
        /// QueryCol 2
        /// 
        /// OUTPUT SAMPLE:
        /// For each query, output the answer of the query. E.g.
        /// 5118
        /// 34
        /// 1792
        /// 3571
        /// </summary>
        static void QueryBoard()
        {
            int[,] board = new int[256, 256];
            using (StreamReader reader = File.OpenText("C:\\Users\\ngunti\\Documents\\TestFiles\\QueryBoard.txt"))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    
                    //Console.WriteLine("Board");
                    //for (int i = 0; i < 256; i++)
                    //{
                    //    for (int j = 0; j < 256; j++)
                    //    {
                    //        Console.Write(board[i, j] + "\t");
                    //    }
                    //    Console.WriteLine();

                    //}
                    int x = 0;
                    int sum = 0;
                    string[] input = line.Split(' ');
                    string query = input[0];
                    int set = int.Parse(input[1]);
                    if(input.Length > 2){
                        x = int.Parse(input[2]);
                    }
                    Console.WriteLine(query + "  " + set + " " + x);
                    switch(query){
                        case "SetCol":
                            for (int i = 0; i < 256; i++)
			                {
                                board[i, set] = x;			 
			                }
                            
                            break;
                        case "SetRow":
                            for (int i = 0; i < 256; i++)
			                {
                                board[set, i] = x;			 
			                }
                            
                            break;
                        case "QueryCol":
                            for (int i = 0; i < 256; i++)
			                {
                                sum += board[i, set];			 
			                }
                            Console.WriteLine("Sum of Column: " + sum);
                            break;
                        case"QueryRow":
                            for (int i = 0; i < 256; i++)
			                {
                               sum += board[set, i];		                       
			                }
                            Console.WriteLine("Sum of Row : " + sum);
                            break;
                    }
                }
           
        }

        /// <summary>
        /// Credits: This problem appeared in the Facebook Hacker Cup 2013 Hackathon.
        /// When John was a little kid he didn't have much to do. There was no internet, no Facebook, and no programs to hack on. So he did the only thing he could... he evaluated the beauty of strings in a quest to discover the most beautiful string in the world. 
        /// Given a string s, little Johnny defined the beauty of the string as the sum of the beauty of the letters in it. The beauty of each letter is an integer between 1 and 26, inclusive, and no two letters have the same beauty. Johnny doesn't care about whether letters are uppercase or lowercase, so that doesn't affect the beauty of a letter. (Uppercase 'F' is exactly as beautiful as lowercase 'f', for example.) 
        /// You're a student writing a report on the youth of this famous hacker. You found the string that Johnny considered most beautiful. What is the maximum possible beauty of this string?
        /// 
        /// INPUT SAMPLE:
        /// Your program should accept as its first argument a path to a filename. Each line in this file has a sentence. E.g.
        /// ABbCcc
        /// Good luck in the Facebook Hacker Cup this year!
        /// Ignore punctuation, please :)
        /// Sometimes test cases are hard to make up.
        /// So I just go consult Professor Dalves
        /// 
        /// OUTPUT SAMPLE:
        /// Print out the maximum beauty for the string. E.g.
        /// 152
        /// 754
        /// 491
        /// 729
        /// 646
        /// 
        /// This means calculate the maximum possible beauty a string can have. e.g. In test case, "AbBCcC" assign 26 to C, as it occurs the most in the string, followed by 25 to B, and 24 to A. For a maximum beauty of 152.
        /// </summary>
        static void BeautifulStrings()
        {
            string line = "Ignore punctuation, please :)";
            line = line.ToLower();
            int count = 26;
            int beauty = 0;
            Hashtable table = new Hashtable();
            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsLetter(line[i]))
                {
                    if (!table.Contains(line[i]))
                    {
                        table.Add(line[i], 1);
                    }
                    else
                    {
                        table[line[i]] = (int)table[line[i]] + 1;
                    }
                }
            }
            var result = new List<DictionaryEntry>(table.Count);
            foreach (DictionaryEntry entry in table)
            {
                result.Add(entry);
            }
            result.Sort(
                (x, y) =>
                {
                    IComparable comparable = y.Value as IComparable;
                    if (comparable != null)
                    {
                        return comparable.CompareTo(x.Value);
                    }
                    return 0;
                });
            foreach (DictionaryEntry entry in result)
            {
                Console.WriteLine(entry.Key.ToString() + ":" + entry.Value.ToString());
            }
            foreach (DictionaryEntry entry in result)
            {
                beauty += count * (int)entry.Value;
                count--;
            }
            Console.WriteLine("Beauty of String: " + beauty);

        }

        /// <summary>
        /// An Armstrong number is an n-digit number that is equal to the sum of the n'th powers of its digits. Determine if the input numbers are Armstrong numbers.
        /// INPUT SAMPLE:
        /// Your program should accept as its first argument a path to a filename. Each line in this file has a positive integer. E.g.
        /// 6
        /// 153
        /// 351
        /// OUTPUT SAMPLE:
        /// Print out True/False if the number is an Armstrong number or not. E.g.
        /// True
        /// True
        /// False
        /// </summary>
        static void ArmstrongNumbers()
        {
            string line = "6";
            int result = 0;
            for (int i = 0; i < line.Length; i++)
            {
                result += (int)Math.Pow(int.Parse(line[i].ToString()), line.Length);
            }
            if (result == int.Parse(line))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        /// <summary>
        /// You will be given a hexadecimal (base 16) number. Convert it into decimal (base 10).
        /// 
        /// INPUT SAMPLE:
        /// Your program should accept as its first argument a path to a filename. Each line in this file contains a hex number. You may assume that the hex number does not have the leading 'Ox'. Also all alpha characters (a through f) in the input will be in lowercase. E.g.
        /// 9f
        /// 11
        /// 
        /// OUTPUT SAMPLE:
        /// Print out the equivalent decimal number. E.g.
        /// 159
        /// 17
        /// </summary>
        static void HexToDecimal()
        {
            string line = "9f";
            int result = 0;
            for (int i = 0; i < line.Length; i++)
            {
                int num = 0;
                switch (line[i])
                {
                    case 'a':
                        num = 10;
                        break;
                    case 'b':
                        num = 11;
                        break;
                    case 'c':
                        num = 12;
                        break;
                    case 'd':
                        num = 13;
                        break;
                    case 'e':
                        num = 14;
                        break;
                    case 'f':
                        num = 15;
                        break;
                    default:
                        num = int.Parse(line[i].ToString());
                        break;
                }
                result += num * (int)Math.Pow(16, line.Length - 1 - i);
            }

            Console.WriteLine("Hex: " + line + " decimal: " + result);
        }
        /// <summary>
        /// Given two integers N and M, calculate N Mod M (without using any inbuilt modulus operator).
        /// 
        /// INPUT SAMPLE:
        /// Your program should accept as its first argument a path to a filename. Each line in this file contains two comma separated positive integers. E.g.
        /// 20,6
        /// 2,3
        /// You may assume M will never be zero.
        /// 
        /// OUTPUT SAMPLE:
        /// Print out the value of N Mod M
        /// </summary>
        static void NModM()
        {
            string line = "2, 3";
            string[] input = line.Split(',');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int i = 1;
            int count = 0;
            while (count <= n)
            {
                count = i * m;
                i++;
            }
            Console.WriteLine("remaining : " + (n - count + m));
        }

        /// <summary>
        /// A number is a self-describing number when (assuming digit positions are labeled 0 to N-1), 
        /// the digit in each position is equal to the number of times that that digit appears in the number.
        /// 
        /// INPUT SAMPLE:
        /// The first argument is the pathname to a file which contains test data, one test case per line. Each line contains a positive integer. E.g.
        /// 2020
        /// 22
        /// 1210
        /// 
        /// OUTPUT SAMPLE:
        /// If the number is a self-describing number, print out 1. If not, print out 0. E.g.
        /// 1
        /// 0
        /// 1
        /// For the curious, here's how 2020 is a self-describing number: Position '0' has value 2 and there is two 0 in the number. Position '1' has value 0 because there are not 1's in the number. Position '2' has value 2 and there is two 2. And the position '3' has value 0 and there are zero 3's.
        /// </summary>
        static void SelfDescribingNumbers()
        {
            string line = "2120";
            int[] table = new int[10];
            for (int i = 0; i < line.Length; i++)
            {
                int c = int.Parse(line[i].ToString());
                table[c]++;
            }
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine("{0}, {1}", i, table[i]);
            }

            for (int i = 0; i < line.Length; i++)
            {

                if (int.Parse(line[i].ToString()) != table[i])
                {
                    Console.WriteLine("0");
                    return;
                }

            }
            Console.WriteLine("1");

            //string line = "2020";
            //for (int i = 0; i < line.Length; i++)
            //{
            //    string s0 = line[i] + "";
            //    int b = int.Parse(s0); // number of times i-th digit must occur for it to be a self describing number
            //    int count = 0;
            //    for (int j = 0; j < line.Length; j++)
            //    {
            //        int temp = int.Parse(line[j] + "");
            //        if (temp == i)
            //        {
            //            count++;
            //        }
            //        if (count > b)
            //        {
            //            Console.WriteLine("0");
            //            return;
            //        }
            //    }
            //    if (count != b)
            //    {
            //        Console.WriteLine("0");
            //        return;
            //    }
            //}
            //Console.WriteLine("1"); 

        }


        /// <summary>
        /// Print the size of a file in bytes.
        /// INPUT:
        /// The first argument to your program has the path to the file you need to check the size of.
        /// 
        /// OUTPUT SAMPLE:
        /// Print the size of the file in bytes. E.g.
        /// 55
        /// </summary>
        static void FileSize()
        {
            FileInfo file = new FileInfo("C:\\Users\\ngunti\\algs4\\InterviewBit\\Strings\\AddBinary.java");
            Console.WriteLine(file.Name + " " + file.Length);
        }

        /// <summary>
        /// RIGHTMOST CHAR
        /// CHALLENGE DESCRIPTION:
        /// You are given a string 'S' and a character 't'. Print out the position of the rightmost occurrence of 't' (case matters) in 'S' or -1 if there is none. The position to be printed out is zero based.
        ///
        /// INPUT SAMPLE:
        /// The first argument will ba a path to a filename, containing a string and a character, comma delimited, one per line. Ignore all empty lines in the input file. E.g. 
        /// Hello World,r
        /// Hello CodeEval,E
        ///
        /// OUTPUT SAMPLE:
        /// Print out the zero based position of the character 't' in string 'S', one per line. Do NOT print out empty lines between your output. 
        /// E.g.
        /// 8
        /// 10
        /// </summary>
        static void RightMostChar()
        {
            using (StreamReader reader = File.OpenText("C:\\Users\\ngunti\\Documents\\TestFiles\\Test.txt"))
                while (!reader.EndOfStream)
                {
                    //string line = "SN7HVRnQF6ARNByhipheMfDbPIqMzz3a27eiFoxWTvnfREf4rDDPYdyuirC8XnhEf3dG,2";
                    string line = reader.ReadLine();
                    string[] input = line.Split(',');
                    string S = input[0];
                    char t = input[1][0];
                    Console.WriteLine("For S: " + S + " t: " + t);
                    if (S.LastIndexOf(t) != -1)
                    {
                        Console.WriteLine(S.LastIndexOf(t));
                    }

                    //Console.WriteLine("For S: " + S + " t: " + t);

                    //for (int i = S.Length - 1; i >= 0; i--)
                    //{
                    //    if (S[i] == t)
                    //    {
                    //        Console.WriteLine(i);
                    //        break;
                    //    }
                    //}
                }

        }

        /// <summary>
        /// http://stackoverflow.com/questions/5956710/given-a-number-n-and-two-integers-p1-p2-determine-if-the-bits-in-position-p1-and
        /// 
        /// </summary>
        static void BitPositions()
        {
            string line = "125,1,2";
            string[] input = line.Split(',');
            int n = int.Parse(input[0]);
            int p1 = int.Parse(input[1]);
            int p2 = int.Parse(input[2]);

            //shift the interesting bits to the least significant position and then mask of all the other bits with & 1
            int bit1 = (n >> (p1 - 1)) & 1; //p1 is 1 based
            int bit2 = (n >> (p2 - 1)) & 1; //p2 is 1 based
            Console.WriteLine("bit1 : " + bit1 + " bit2: " + bit2);

            //int result = (bit1 ^ bit2);

            if (bit1 == bit2)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
        static void FizzBuzz()
        {
            string line = "2 7 15";
            string[] input = line.Split(' ');
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            int n = int.Parse(input[2]);
            for (int i = 1; i <= n; i++)
            {
                if (i % x == 0 && i % y == 0)
                {
                    Console.Write("FB");
                }
                else if (i % x == 0)
                {
                    Console.Write("F");
                }
                else if (i % y == 0)
                {
                    Console.Write("B");
                }
                else
                {
                    Console.Write(i);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        static void HappyNumbers()
        {
            string line = "22";
            int n = int.Parse(line);
            int x = sumOfDigits(n);
            int i = 0;
            while (x != 1)
            {
                n = sumOfSqaureDigits(n);
                x = sumOfDigits(n);
                i++;
                if (i > 100)
                {
                    Console.WriteLine("0");
                    return;
                }
            }
            Console.WriteLine("1");
        }
        static int sumOfSqaureDigits(int n)
        {
            var result = 0;
            while (n > 0)
            {
                int x = n % 10;
                result += x * x;
                n = n / 10;
            }
            return result;
        }
        static int sumOfDigits(int n)
        {
            var result = 0;
            while (n > 0)
            {
                int x = n % 10;
                result += x;
                n = n / 10;
            }
            return result;
        }
        static void WordToDigit()
        {
            string line = "zero;two;five;seven;eight;four";
            string[] words = line.Split(';');
            string result = "";
            foreach (var item in words)
            {
                switch (item)
                {
                    case "zero":
                        result += "0";
                        break;
                    case "one":
                        result += "1";
                        break;
                    case "two":
                        result += "2";
                        break;
                    case "three":
                        result += "3";
                        break;
                    case "four":
                        result += "4";
                        break;
                    case "five":
                        result += "5";
                        break;
                    case "six":
                        result += "6";
                        break;
                    case "seven":
                        result += "7";
                        break;
                    case "eight":
                        result += "8";
                        break;
                    case "nine":
                        result += "9";
                        break;
                }
            }
            Console.WriteLine(result);
        }

        static void SetIntersection()
        {
            string line = "7,8,9;8,9,10,11,12";
            string[] sets = line.Split(';');
            string[] set1 = sets[0].Split(',');
            string[] set2 = sets[1].Split(',');
            int i = 0;
            int j = 0;
            //Console.WriteLine("Set1: ");
            //foreach (var item in set1)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Set2: ");
            //foreach (var item in set2)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            while (i < set1.Length && j < set2.Length)
            {
                int x = int.Parse(set1[i]);
                int y = int.Parse(set2[j]);
                if (x < y)
                {
                    i++;
                }
                else if (x > y)
                {
                    j++;
                }
                else
                {
                    if (i == set1.Length - 1 || j == set2.Length - 1)
                    {
                        Console.Write(x);
                    }
                    else
                    {
                        Console.Write(x + ",");
                    }
                    i++;
                    j++;
                }
            }

        }
        static void UniqueElements()
        {
            string line = "2, 3, 4, 5, 5";
            string[] arr = line.Split(',');
            int curr = int.Parse(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                if (curr != int.Parse(arr[i]))
                {
                    Console.Write(curr + ", ");
                    curr = int.Parse(arr[i]);
                }
            }
            Console.WriteLine(curr);
        }

        static void MultiplicationTables()
        {
            Console.WriteLine("Multiplication Tables");
            for (int i = 1; i < 13; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    Console.Write((i * j).ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }

        static void SwapElements()
        {
            string line = "81 71 12 63 68 40 92 65 90 98 15 76 71 48 8 48 : 2-7, 15-9, 13-12";

            // do something with line
            string[] input = line.Split(':');
            string[] arr = input[0].Trim().Split(' ');
            string[] swap = input[1].Trim().Split(',');
            Console.WriteLine("array: ");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("swap: ");
            foreach (var item in swap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            for (var i = 0; i < swap.Length; i++)
            {
                string[] swapElems = swap[i].Trim().Split('-');
                string temp = arr[int.Parse(swapElems[0])];
                arr[int.Parse(swapElems[0])] = arr[int.Parse(swapElems[1])];
                arr[int.Parse(swapElems[1])] = temp;
            }

            Console.WriteLine("Array after swapping: ");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
