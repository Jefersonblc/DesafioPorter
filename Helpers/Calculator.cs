using System;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;

namespace DesafioPorter.Helpers
{
    public class Calculator
    {
        public long SumArray(int[] numbers)
        {
            long sum = 0;

            //Two easy ways that work better, but not optimal yet

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    sum += numbers[i];
            //}

            //foreach (int number in numbers)
            //{
            //    sum += number;
            //}

            //Trying to optimize:

            //var isOdd = numbers.Length % 2 != 0;

            //for (int i = 0; i < numbers.Length; i += 2)
            //{
            //    sum += isOdd && i + 1 >= numbers.Length 
            //        ? numbers[i] 
            //        : numbers[i] + numbers[i + 1];
            //}

            //Optimised, at least 2 times faster for big arrays:

            if(numbers != null && numbers.Length > 0) 
            { 
                int index = 0;
                for (int i = 0; i < numbers.Length; index = i += 5)
                {
                    if (index + 4 >= numbers.Length)
                    {
                        break;
                    }
                    sum += numbers[i] + numbers[i + 1] + numbers[i + 2] + numbers[i + 3] + numbers[i + 4];
                }

                for (int i = index; i < numbers.Length; i++)
                {
                    sum += numbers[i];
                }
            } 

            return sum;
        }

    }
}
