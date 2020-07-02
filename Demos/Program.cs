using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputString = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[] myArray = new int[inputString.Length];

            for (int i = 0; i < inputString.Length; i++)
            {
                myArray[i] = int.Parse(inputString[i]);
            }

            while (true)
            {
                string inputCommand = Console.ReadLine();

                if (inputCommand == "end")
                {
                    break;
                }

                string[] inputCommandArray = inputCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (inputCommandArray[0])
                {
                    case "exchange":
                        int index = int.Parse(inputCommandArray[1]);
                        if (index < 0 || index >= myArray.Length)
                        {
                            Console.WriteLine($"Invalid index");
                        }
                        else
                        {
                            myArray = ExchangeByIndex(myArray, index);
                        }
                        break;
                    case "max":
                        int resultMax = ReturnMaxEvenOrOddIndex(myArray, inputCommandArray[1]);
                        if (resultMax < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(resultMax);
                        }                        
                        break;
                    case "min":
                        int resultMin = ReturnMinEvenOrOddIndex(myArray, inputCommandArray[1]);
                        if (resultMin < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(resultMin);
                        }
                        break;
                    case "first":                        
                    case "last":
                        string firstOrLast = inputCommandArray[0];
                        int count = int.Parse(inputCommandArray[1]);
                        string evenOrOdd = inputCommandArray[2];

                        if (count > myArray.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        if (firstOrLast == "first")
                        {
                            Console.WriteLine(ReturnFirstEvenOrOddValues(myArray, count, evenOrOdd));
                        }
                        else if (firstOrLast == "last")
                        {
                            Console.WriteLine(ReturnLastEvenOrOddValues(myArray, count, evenOrOdd));
                        }
                        break;
                }
            }

            Console.WriteLine($"[{String.Join(", ", myArray)}]");
        }

        static int[] ExchangeByIndex(int[] someArray, int someIndex)
        {
            if (someIndex == someArray.Length)
            {
                return someArray;
            }
            else
            {
                int[] myExchangedArray = new int[someArray.Length];

                int helpNum = 0;

                for (int i = someIndex + 1; i < someArray.Length; i++)
                {
                    myExchangedArray[helpNum] = someArray[i];
                    helpNum++;
                }

                int helpNum1 = someArray.Length - someIndex - 1;

                for (int j = 0; j <= someIndex; j++)
                {
                    myExchangedArray[helpNum1] = someArray[j];
                    helpNum1++;
                }
                return myExchangedArray;
            }            
        }

        static int ReturnMaxEvenOrOddIndex(int[] myArray, string evenOrOdd)
        {
            int indexToReturn = -1;
            int maxValue = int.MinValue;

            if (evenOrOdd == "even")
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 == 0 && myArray[i] >= maxValue)
                    {
                        indexToReturn = i;
                        maxValue = myArray[i];
                    }
                }                
            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 != 0 && myArray[i] >= maxValue)
                    {
                        indexToReturn = i;
                        maxValue = myArray[i];
                    }
                }
            }
            return indexToReturn;
        }

        static int ReturnMinEvenOrOddIndex(int[] myArray, string evenOrOdd)
        {
            int indexToReturn = -1;
            int minValue = int.MaxValue;

            if (evenOrOdd == "even")
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 == 0 && myArray[i] <= minValue)
                    {
                        indexToReturn = i;
                        minValue = myArray[i];
                    }
                }
            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 != 0 && myArray[i] <= minValue)
                    {
                        indexToReturn = i;
                        minValue = myArray[i];
                    }
                }
            }
            return indexToReturn;
        }

        static string ReturnFirstEvenOrOddValues(int[] myArray, int count, string evenOrOdd)
        {
            List<int> myResultList = new List<int>();

            if (evenOrOdd == "even")
            {                
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 == 0)
                    {
                        myResultList.Add(myArray[i]);

                        if (myResultList.Count == count)
                        {
                            break;
                        }
                    }
                }
            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 != 0)
                    {
                        myResultList.Add(myArray[i]);

                        if (myResultList.Count == count)
                        {
                            break;
                        }
                    }
                }
            }

            return $"[{String.Join(", ", myResultList)}]";
        }

        static string ReturnLastEvenOrOddValues(int[] myArray, int count, string evenOrOdd)
        {
            List<int> myResultList = new List<int>();
                     
            if (evenOrOdd == "even")
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 == 0)
                    {
                        myResultList.Add(myArray[i]);                        
                    }
                }
            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] % 2 != 0)
                    {
                        myResultList.Add(myArray[i]);
                    }
                }
            }

            var listToReturn = myResultList.TakeLast(count);

            return $"[{String.Join(", ", listToReturn)}]";
        }
    }
}
